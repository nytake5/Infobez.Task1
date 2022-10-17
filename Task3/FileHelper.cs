using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    public static class FileHelper
    {
        public static Regex regexForDirectory;

        private static List<string> GetAllFilesInDirectory(string directory, ref List<string> myFiles)
        {

            string[] directories = Directory.GetDirectories(directory);
            foreach (string file in Directory.GetFiles(directory))
            {
                string newFileName = regexForDirectory.Match(file).Value;
                myFiles.Add($"({newFileName}_{File.ReadAllText(file)})");
            }
            foreach (string item in directories)
            {
                GetAllFilesInDirectory(item, ref myFiles);
            }
            return myFiles;
        }

        public static string GetFilesInDirectoryInString(string directory)
        {
            List<string> list = new();
            Regex regex = new Regex(@"[\w]*$", RegexOptions.Compiled);
            var directoryName = regex.Match(directory).Value;
            regexForDirectory = new Regex($@"{directoryName}\\.*", RegexOptions.Compiled);
            return string.Join("", GetAllFilesInDirectory(directory, ref list));
        }

        public static void CreateDirectoryFromString(string newDirectory, string allText)
        {
            var files = allText.Split(new char[] { '(', ')' }).Where(x => !String.IsNullOrEmpty(x)).ToList();
            foreach (string file in files)
            {
                string[] content = file.Split("_");
                string directory = Path.Combine(newDirectory, Path.GetDirectoryName(content[0]) ?? String.Empty);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(Path.Combine(newDirectory, content[0]), content[1]);
            }
        }
    }
}
