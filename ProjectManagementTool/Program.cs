using System;
using System.IO;

namespace ProjectManagementTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to sync entites");
            var command = Console.ReadKey();

            var path = @"C:\Users\gisaiashvili\source\repos\ProjectTemplate";
            var name = "ProjectTemplate";

            SyncronizeEntities(path, name);

            Console.ReadKey();
        }

        private static void SyncronizeEntities(string projectPath, string projectName)
        {
            var entityFullPath = $@"{projectPath}\ProjectTemplate.Core\Entities";

            foreach (string file in Directory.EnumerateFiles(entityFullPath, "*.cs"))
            {
                var fileName = GetFileNameFromPath(file);
                if (fileName != "EntityBase.cs")
                {
                    string contents = File.ReadAllText(file);
                    CreateDto(projectPath, fileName, contents);

                }
            }
        }

        private static string GetFileNameFromPath(string path)
        {
            var name = path.Substring(path.LastIndexOf('\\'));
            return name.Replace("\\", "");
        }

        private static void CreateDto(string projectPath, string name, string content)
        {
            var dtoFullPath = $@"{projectPath}\ProjectTemplate.Core\Entities";
        }
    }
}
