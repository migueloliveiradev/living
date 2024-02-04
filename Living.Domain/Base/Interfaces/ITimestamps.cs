namespace Living.Domain.Base.Interfaces;
public interface ITimestamps : ITimestamp
{
    DateTime LastUpdatedAt { get; set; }
    
}
