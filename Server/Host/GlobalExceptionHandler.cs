using EslOnline.Domain.Exceptions;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EslOnline.Host;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // Логика определения "кто виноват"
        var (statusCode, errorCode) = exception switch
        {
            // 1. Твои бизнес-ошибки
            AppException appException => (StatusCodes.Status400BadRequest, appException.ErrorCode),

            // 2. Ошибки формата (пустой запрос, кривой JSON) — ТО, ЧТО ТЫ СПРАШИВАЛ
            BadHttpRequestException => (StatusCodes.Status400BadRequest, AppErrorCode.bad_request_400),

            // 3. Безопасность (если не в белом списке)
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, AppErrorCode.unauthorized_401),

            // 4. Всё остальное — взрыв на сервере
            _ => (StatusCodes.Status500InternalServerError, AppErrorCode.unknown_server_error_500)
        };

        // Логируем только системные 500-ки
        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(exception, "System Failure: {Message}", exception.Message);
        }

        // Отправляем ответ
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new AppExceptionDto(errorCode), cancellationToken);

        return true; // Говорим системе, что мы всё обработали
    }
}