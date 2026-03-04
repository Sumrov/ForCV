using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.SharedKernel.Application.Interfaces;

public interface ICitizenRequest
{
    CitizenId CitizenId { get; init; }
}