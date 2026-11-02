using System.Runtime.CompilerServices;
using EmptyFiles;

namespace EverQuestLogWatcher.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void TreatMarkdownSnippetsIncludeFilesAsText()
    {
        FileExtensions.AddTextExtension("include.md");
    }
}
