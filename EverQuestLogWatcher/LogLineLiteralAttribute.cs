using System.Text.RegularExpressions;

namespace EverQuestLogWatcher;

/// <summary>A message that is always exactly this text, with nothing varying. It is its own only example.</summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class LogLineLiteralAttribute(string message) : LogLinePatternAttribute($"^{Regex.Escape(message).Replace(@"\ ", " ")}$", message)
{
}
