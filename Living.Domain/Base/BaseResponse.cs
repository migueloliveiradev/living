using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text.Json.Serialization;

namespace Living.Domain.Base;

public class BaseResponse<T> : BaseResponse
{
    [JsonConstructor]
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

    public BaseResponse(Notification notification, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        Notifications.Add(notification.Key, [notification.Code]);
        HttpStatusCode = httpStatusCode;
    }

    public BaseResponse(IEnumerable<Notification> notifications, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        foreach (var notification in notifications)
        {
            Notifications.TryAdd(notification.Key, []);
            Notifications[notification.Key] = [.. Notifications[notification.Key], notification.Code];
        }

        HttpStatusCode = httpStatusCode;
    }

    public BaseResponse(IEnumerable<IdentityError> errors, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        foreach (var error in errors)
        {
            Notifications.TryAdd("IDENTITY", []);
            Notifications["IDENTITY"] = [.. Notifications["IDENTITY"], error.Code];
        }

        HttpStatusCode = httpStatusCode;
    }

    public bool HasNotifications => Notifications.Count > 0;

    public Dictionary<string, string[]> Notifications { get; set; } = [];

    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
}