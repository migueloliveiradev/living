using FluentAssertions.Collections;

namespace Living.Tests.Extensions;
public static class FluentAssertionsExtensions
{
    public static void ContainNotification(
        this GenericDictionaryAssertions<IDictionary<string, string[]>, string, string[]> dictionaryAssertions,
        Notification notification)
    {
        dictionaryAssertions.ContainKey(notification.Key);
        dictionaryAssertions.Contain(p => p.Value.Contains(notification.Code));
    }
}
