namespace EverQuestLogWatcher;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class LogLinePatternAttribute : Attribute
{
    public string RegexMatchingWholeMessage { get; }
    public IReadOnlyList<string> ExampleMessages { get; }

    public LogLinePatternAttribute(string regexMatchingWholeMessage, params string[] exampleMessages)
    {
        if (!regexMatchingWholeMessage.StartsWith('^') || !regexMatchingWholeMessage.EndsWith('$'))
        {
            throw new ArgumentException($"Pattern must start with ^ and end with $ to match the whole line: {regexMatchingWholeMessage}", nameof(regexMatchingWholeMessage));
        }

        RegexMatchingWholeMessage = regexMatchingWholeMessage;
        ExampleMessages = exampleMessages;
    }
}
