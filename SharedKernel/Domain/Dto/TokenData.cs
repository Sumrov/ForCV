using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace EslOnline.SharedKernel.Domain.Dto;

public sealed record TokenData(
    [property: JsonPropertyName(CustomClaims.CitizenId)] CitizenId CitizenId
    );

