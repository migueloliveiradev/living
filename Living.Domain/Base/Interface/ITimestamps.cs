namespace Living.Domain.Base.Interface;
public interface ITimestamps
{
    DateTime CreatedAt { get; }
    DateTime? LastUpdatedAt { get; }
    DateTime? DeletedAt { get; }
}
