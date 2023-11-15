namespace Living.Domain.Base.Interfaces;
public interface ITimestamps
{
    DateTime CreatedAt { get; }
    DateTime? LastUpdatedAt { get; }
    DateTime? DeletedAt { get; set; }
}
