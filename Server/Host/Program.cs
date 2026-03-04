using EslOnline.Application.Configurations;
using EslOnline.Application.Handlers.Auth;
using EslOnline.Application.Interfaces;
using EslOnline.Domain.Extensions;
using EslOnline.Domain.Factory;
using EslOnline.Domain.Interfaces;
using EslOnline.Domain.Services;
using EslOnline.Host;
using EslOnline.Host.Views;
using EslOnline.Infrastructure.Authorization;
using EslOnline.Infrastructure.Configuration;
using EslOnline.Infrastructure.Data;
using EslOnline.Infrastructure.Repositories;
using EslOnline.SharedKernel.Application;
using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Application.Requests;
using EslOnline.SharedKernel.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

// --- РЕГИСТРАЦИЯ СЕРВИСОВ ---
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddHttpClient();

// Ркгистрация конфигов
builder.Services.Configure<GoogleAuthOptions>(builder.Configuration.GetSection(GoogleAuthOptions.SectionName));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.SectionName));
builder.Services.Configure<GameBalance>(builder.Configuration.GetSection(GameBalance.SectionName));

builder.Services.AddDbContext<EslOnlineDbContext>((sp, options) =>
{
    var dbOptions = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;
    options.UseSqlServer(dbOptions.Default, sqlOptions => sqlOptions.CommandTimeout(10));
});

// Авто-регистрация UseCase
builder.Services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(GetAuthorizationUrlHandler).Assembly));

builder.Services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EslOnlineDbContext>());
builder.Services.AddScoped<IAuthProvider, GoogleAuthProvider>();
builder.Services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<BuildingFactory>();
builder.Services.AddScoped<CityFactory>();
builder.Services.AddScoped<CitizenFactory>();
builder.Services.AddScoped<UserFactory>();
builder.Services.AddScoped<JobPositionFactory>();
builder.Services.AddScoped<CitizenLocationFactory>();
builder.Services.AddScoped<UserRegistrationService>();
builder.Services.AddScoped<UpdateStateService>();

// Регистрируем открытый дженерик
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

// Регистрация Dapper
builder.Services.AddScoped<IDbConnection>(o =>
{
    var dbOptions = o.GetRequiredService<IOptions<DatabaseOptions>>().Value;
    return new SqlConnection(dbOptions.Default);
});

// Добавляем конвертер для Enum
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
var key = Encoding.ASCII.GetBytes(jwtOptions?.BearerKey ?? throw new Exception("JWT ключ не найден"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });
builder.Services.AddAuthorization();

// --- КОНВЕЙЕР ОБРАБОТКИ (PIPELINE) ---
var app = builder.Build();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

var googleAuthOptions = builder.Configuration.GetSection(GoogleAuthOptions.SectionName).Get<GoogleAuthOptions>();
string endpoint = googleAuthOptions?.Endpoint ?? throw new Exception("Endpoint не найден");
app.MapGet(endpoint, async (string code, IMediator mediator) =>
{
    var request = new LoginWithGoogleRequest(code);
    var result = await mediator.Send(request);
    var json = JsonSerializer.Serialize(result);
    var response = TokenPage.GetHtmlCode(json);
    return Results.Content(response, "text/html");
});

app.MapPost(Routes.Anonymous + "{actionName}",
    (string actionName, HttpContext context) => ActionDispatcher(actionName, context, ApiRegistry.AnonymousRequestTypes));

app.MapPost(Routes.Authorization + "{actionName}",
    (string actionName, HttpContext context) => ActionDispatcher(actionName, context, ApiRegistry.RequestTypes))
    .RequireAuthorization();

static async Task<IResult> ActionDispatcher(string actionName, HttpContext context, Dictionary<string, Type> whitelist)
{
    if (!whitelist.TryGetValue(actionName, out var requestType))
        throw new BadHttpRequestException($"{actionName} нет в белом списке");

    var request = (IBaseRequest)(await context.Request.ReadFromJsonAsync(requestType)
        ?? throw new BadHttpRequestException("Тело запроса не может быть пустым"));

    if (request is ICitizenRequest citizenRequest && citizenRequest.CitizenId != context.User.CitizenId())
        throw new BadHttpRequestException("CitizenId не совпадает");

    var mediator = context.RequestServices.GetRequiredService<IMediator>();
    var result = await mediator.Send(request);
    return Results.Ok(result);
}

app.Run();