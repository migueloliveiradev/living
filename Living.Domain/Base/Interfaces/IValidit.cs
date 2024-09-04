namespace Living.Domain.Base.Interfaces;

internal interface IValidit
{
    public IEnumerable<Notification> IsValid();
}
