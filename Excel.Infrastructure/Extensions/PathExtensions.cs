using System.IO;

namespace Excel.Infrastructure.Extensions
{
    internal static class PathExtensions
    {
        internal static string GetParentPath(this string path)
        {
            return (new FileInfo(path).Directory.Parent.FullName);
        }
    }
}
