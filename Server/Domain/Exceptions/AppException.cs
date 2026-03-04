using EslOnline.SharedKernel.Domain.Enums;

namespace EslOnline.Domain.Exceptions;

public class AppException : Exception
{
    protected AppException()
    {

    }

    public AppException(AppErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    public AppException(string? message) : base(message)
    {
    }

    public AppException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    //public AppException(AppErrorCode errorCode)
    //{
    //    AppErrorCode=errorCode;
    //}

    //public AppException(AppErrorCode errorCode, string message, Exception innerException) : base(message, innerException)
    //{
    //    AppErrorCode=errorCode;
    //}

    public AppErrorCode ErrorCode { get; }
};
