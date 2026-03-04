using EslOnline.SharedKernel.Application.Interfaces;

namespace EslOnline.SharedKernel.Application.Notifications;

public sealed record BuildingClickNotification(string NotificationText) : INotification;
