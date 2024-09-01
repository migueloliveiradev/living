using AutoFixture;

namespace Living.Tests.Unit.Base;
public class TestBase
{
    protected IFixture Fixture { get; private set; } = new Fixture();
}
