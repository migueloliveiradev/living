namespace Living.Domain.Base.Interfaces;
public interface ISoftDelete
{
    DateTime? DeletedAt { get; set; }
}
