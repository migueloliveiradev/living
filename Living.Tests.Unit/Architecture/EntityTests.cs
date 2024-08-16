using Living.Domain.Base.Interfaces;
using Living.Shared.Extensions;
using Living.Tests.Unit.Helpers;

namespace Living.Tests.Unit.Architecture;
public class EntityTests
{
    private static readonly string[] NAMESPACES_EXCLUDE =
        [
            "Microsoft.AspNetCore.Identity",
        ];

    [Fact]
    public void Entities_Id_ShouldBeGetInit()
    {
        var assembly = ProjectsAssemblies.Domain;

        var entities = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IEntity)))
            .SelectMany(t => t.GetProperties())
            .Where(p => p.Name == nameof(IEntity.Id))
            .ToList();

        entities.Should()
            .AllSatisfy(property =>
            {
                if (property.DeclaringType is null || property.DeclaringType.FullName is null)
                    return;

                if (NAMESPACES_EXCLUDE.Any(p => property.DeclaringType.FullName.StartsWith(p, StringComparison.Ordinal)))
                    return;

                property.IsGetInit()
                    .Should()
                    .BeTrue($"{property.DeclaringType.FullName}.{property.Name} not is 'get' and 'init'");
            });
    }

    [Fact]
    public void Entities_Timestamps_ShouldBeOnlyGet()
    {
        var assembly = ProjectsAssemblies.Domain;

        var entities = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(ITimestamps)))
            .SelectMany(t => t.GetProperties())
            .Where(p => p.Name == nameof(ITimestamps.CreatedAt))
            .ToList();

        entities.Should()
            .AllSatisfy(property =>
            {
                if (property.DeclaringType is null || property.DeclaringType.FullName is null)
                    return;

                property.IsOnlyGet()
                    .Should()
                    .BeTrue($"{property.DeclaringType.FullName}.{property.Name} not is 'get'");
            });
    }

    [Fact]
    public void Entities_Relations_ShouldBeGetInit()
    {
        var assembly = ProjectsAssemblies.Domain;

        var entities = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IEntity)))
            .SelectMany(t => t.GetProperties())
            .Where(p => p.PropertyType.IsClass)
            .Where(p => p.PropertyType.GetInterfaces().Contains(typeof(IEntity)))
            .ToList();

        entities.Should()
            .AllSatisfy(property =>
            {
                property.IsGetInit()
                    .Should()
                    .BeTrue($"{property.DeclaringType!.FullName}.{property.Name} not is 'get' and 'init'");
            });
    }
}
