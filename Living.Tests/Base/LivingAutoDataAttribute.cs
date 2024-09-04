using Living.Tests.Helpers;

namespace Living.Tests.Base;

[AttributeUsage(AttributeTargets.Method)]
public class LivingAutoDataAttribute : AutoDataAttribute
{
    public LivingAutoDataAttribute() : base(FixtureHelper.CreateFixture) { }
}
