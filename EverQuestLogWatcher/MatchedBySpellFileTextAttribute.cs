namespace EverQuestLogWatcher;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MatchedBySpellFileTextAttribute(string exampleMessage) : Attribute
{
    public string ExampleMessage { get; } = exampleMessage;
}
