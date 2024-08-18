namespace Living.Tests.Base;

[AttributeUsage(AttributeTargets.Method)]
public class LivingInlineAutoDataAttribute(params object[] values) : InlineAutoDataAttribute(new LivingAutoDataAttribute(), values)
{
}
