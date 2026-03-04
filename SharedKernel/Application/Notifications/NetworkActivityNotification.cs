using EslOnline.SharedKernel.Application.Interfaces;

namespace EslOnline.SharedKernel.Application.Notifications;

public sealed record NetworkActivityNotification(bool IsActive) : INotification;
