using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infobez.Task1
{
    public static class HashFileHelper
    {
        private static readonly string LocalInfo = $"{Environment.CurrentDirectory}/info.json";
        public static long HashForFile(string fileName)
        {
            long hash = 0;
            byte[] bytes = File.ReadAllBytes(fileName);
            for (int i = 0; i < bytes.Length - 2; i += 2)
            {
                hash += bytes[i] ^ bytes[i + 1];
            }
            return hash;
        }

        public static List<MyFile> GetAllFilesInDirectory(string directory, ref List<MyFile> myFiles)
        {
            string[] directories = Directory.GetDirectories(directory);
            foreach (string file in Directory.GetFiles(directory))
            {
                myFiles.Add(new MyFile()
                {
                    Path = file,
                    Hash = HashForFile(file)
                });
            }
            foreach (string item in directories)
            {
                GetAllFilesInDirectory(item, ref myFiles);
            }

            return myFiles;
        }

        public static void SaveInfoFile(List<MyFile> myFiles)
        {
            File.WriteAllText(LocalInfo, JsonConvert.SerializeObject(myFiles));
        }
    }
}
