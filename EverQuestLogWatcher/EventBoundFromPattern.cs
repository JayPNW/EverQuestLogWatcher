using System.Reflection;
using System.Text.RegularExpressions;

namespace EverQuestLogWatcher;

class EventBoundFromPattern(Type eventType, LogLinePatternAttribute pattern)
{
    readonly ConstructorInfo constructor = eventType.GetConstructors().Single();

    public Type EventType { get; } = eventType;
    public Regex RegexMatchingWholeMessage { get; } = new Regex(pattern.RegexMatchingWholeMessage, RegexOptions.Compiled | RegexOptions.CultureInvariant);

    /// <summary>Constructor parameters after the three common ones are filled from the regex group with the same name.</summary>
    public EverQuestLogEvent CreateEvent(Match match, Character character, DateTime localTimestamp, string rawLogLine)
    {
        object[] commonArguments = [character, localTimestamp, rawLogLine];
        var capturedArguments = this.constructor.GetParameters().Skip(commonArguments.Length).Select(parameter => (object)match.Groups[parameter.Name!].Value);
        return (EverQuestLogEvent)this.constructor.Invoke([.. commonArguments, .. capturedArguments]);
    }
}
