using Living.Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Living.Infraestructure.Context.Interceptors;
public class SavingChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateITimestamps(eventData.Context.ChangeTracker);
            UpdateISoftDelete(eventData.Context.ChangeTracker);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateITimestamps(ChangeTracker changeTracker)
    {
        var entries = changeTracker.Entries<ITimestamps>();
        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.CurrentValues[nameof(ITimestamps.CreatedAt)] = now;
                    entry.CurrentValues[nameof(ITimestamps.LastUpdatedAt)] = now;
                    break;
                case EntityState.Modified:
                    entry.CurrentValues[nameof(ITimestamps.LastUpdatedAt)] = now;
                    break;
            }
        }
    }

    private static void UpdateISoftDelete(ChangeTracker changeTracker)
    {
        var entries = changeTracker.Entries<ISoftDelete>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}
