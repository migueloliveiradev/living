using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Base;
public class BaseResponse<T> : BaseResponse
{
    public BaseResponse(T data)
    {
        Data = data;
    }

    public BaseResponse(Notification notification)
    {
        _notifications.Add(notification);
    }

    public BaseResponse(IEnumerable<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public BaseResponse(IEnumerable<IdentityError> errors)
    {
        _notifications.AddRange(errors.Select(p => new Notification("Identity", p.Code)));
    }

    public T? Data { get; set; }
}

public class BaseResponse
{
    protected readonly List<Notification> _notifications = [];
    public BaseResponse()
    {
    }

    public BaseResponse(Notification notification)
    {
        _notifications.Add(notification);
    }

    public BaseResponse(IEnumerable<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public BaseResponse(IEnumerable<IdentityError> errors)
    {
        _notifications.AddRange(errors.Select(p => new Notification("Identity", p.Code)));
    }

    public bool HasNotifications => _notifications.Count is not 0;

    public Dictionary<string, string[]> Notifications => _notifications
        .GroupBy(x => x.Key)
        .ToDictionary(x => x.Key, x => x.Select(y => y.Code).ToArray());
}