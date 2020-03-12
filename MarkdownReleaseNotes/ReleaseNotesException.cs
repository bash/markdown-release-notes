using System;

namespace MarkdownReleaseNotes
{
    public sealed class ReleaseNotesException : Exception
    {
        public ReleaseNotesException(string message)
            : base(message)
        {
        }

        public ReleaseNotesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
