using Living.Tests.Unit.Helpers;

namespace Living.Tests.Unit.Architecture;
public class CleanArchitectureTests
{
    private const string ASSEMBLY_NAME_BASE = "Living";

    [Fact]
    public void Domain_NotShouldHaveDependencies()
    {
        var dependencies = ProjectsAssemblies.Domain.GetReferencedAssemblies()
            .Where(x => x.FullName.StartsWith(ASSEMBLY_NAME_BASE));

        dependencies.Should().BeEmpty();
    }

    [Fact]
    public void Application_ShouldDependOnDomainAndShared()
    {
        var dependencies = ProjectsAssemblies.Application.GetReferencedAssemblies()
            .Where(x => x.FullName.StartsWith(ASSEMBLY_NAME_BASE));

        dependencies.Should().HaveCount(2);

        dependencies.Should().Contain(x => x.Name == ProjectsAssemblies.Domain.GetName().Name);
        dependencies.Should().Contain(x => x.Name == ProjectsAssemblies.Shared.GetName().Name);
    }

    [Fact]
    public void Infrastructure_ShouldDependOnDomain()
    {
        var dependencies = ProjectsAssemblies.Infrastructure.GetReferencedAssemblies()
            .Where(x => x.FullName.StartsWith(ASSEMBLY_NAME_BASE));

        dependencies.Should().HaveCount(2);

        dependencies.Should().Contain(x => x.Name == ProjectsAssemblies.Domain.GetName().Name);
        dependencies.Should().Contain(x => x.Name == ProjectsAssemblies.Shared.GetName().Name);
    }

    [Fact]
    public void Shared_NotShouldHaveDependencies()
    {
        var dependencies = ProjectsAssemblies.Shared.GetReferencedAssemblies()
            .Where(x => x.FullName.StartsWith(ASSEMBLY_NAME_BASE));

        dependencies.Should().BeEmpty();
    }
}
