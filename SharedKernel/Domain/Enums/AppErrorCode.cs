namespace EslOnline.SharedKernel.Domain.Enums;

public enum AppErrorCode
{
    unknown_server_error_500,
    bad_request_400,
    unauthorized_401,
    google_email_not_verified,
    google_locale_missing,
    client_error,
    network_error,
    unitask_error,
    login_google_response_deserialize_error,
    memory_repository_havent_citizenId
}
