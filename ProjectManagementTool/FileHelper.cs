using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectManagementTool
{
    public class FileHelper
    {
        public static string GetFileNameFromPath(string path)
        {
            var name = path.Substring(path.LastIndexOf('\\'));
            name = name.Replace("\\", "");
            return name;
        }

        public static string GetFile(string filePath, string fileName)
        {
            var allFiles = Directory.EnumerateFiles(filePath);
            var targetFile = allFiles.FirstOrDefault(f => GetFileNameFromPath(f) == fileName);
            var contentOfTargetFile = File.ReadAllText(targetFile);

            return contentOfTargetFile;
        }

        public static void CreateFile(string filePath, string fileContent)
        {
            using (FileStream fs = File.Create(filePath))
            {
                byte[] content = new UTF8Encoding(true).GetBytes(fileContent);
                fs.Write(content, 0, content.Length);
            }
        }

        public static void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
}
