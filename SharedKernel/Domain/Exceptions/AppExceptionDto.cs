using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Domain.Enums;

namespace EslOnline.SharedKernel.Domain.Exceptions;

public sealed record AppExceptionDto(AppErrorCode ErrorCode) : IResponse;
