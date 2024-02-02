using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Base;
public class BaseResponse<T> : BaseResponse
{
    public BaseResponse(T data)
    {
        Data = data;
    }

    public BaseResponse(Notification notification) : base(notification)
    {
    }

    public BaseResponse(IEnumerable<Notification> notifications) : base(notifications)
    {
    }

    public BaseResponse(IEnumerable<IdentityError> errors) : base(errors)
    {
    }

    public T? Data { get; set; }
}

public class BaseResponse
{
    public BaseResponse()
    {
    }

    public BaseResponse(Notification notification)
    {
        Notifications.TryAdd(notification.Key, []);
        Notifications[notification.Key] = [..Notifications[notification.Key], notification.Code];
    }

    public BaseResponse(IEnumerable<Notification> notifications)
    {
        foreach (var notification in notifications)
        {
            Notifications.TryAdd(notification.Key, []);
            Notifications[notification.Key] = [..Notifications[notification.Key], notification.Code];
        }
    }

    public BaseResponse(IEnumerable<IdentityError> errors)
    {
        foreach (var error in errors)
        {
            Notifications.TryAdd("IDENTITY", []);
            Notifications["IDENTITY"] = [..Notifications["IDENTITY"], error.Code];
        }
    }

    public bool HasNotifications => Notifications.Count > 0;

    public Dictionary<string, string[]> Notifications { get; set; } = [];
}