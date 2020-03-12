using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MarkdownReleaseNotes.Build
{
    public sealed class RenderReleaseNotes : Task
    {
        [Required]
        public string ChangelogFile { get; set; } = null!;

        [Required]
        public string Version { get; set; } = null!;

        [Output]
        public string? GeneratedReleaseNotes { get; set; }

        public override bool Execute()
        {
            if (!File.Exists(ChangelogFile))
            {
                Log.LogError($"Changelog file '{ChangelogFile}' does not exist.");
                return false;
            }

            var markdown = File.ReadAllText(ChangelogFile);

            try
            {
                GeneratedReleaseNotes = ReleaseNotesRenderer.RenderReleaseNotes(markdown, Version);
            }
            catch (ReleaseNotesException exception)
            {
                Log.LogError(exception.Message);
                return false;
            }

            return true;
        }
    }
}
