using ProjectTemplate.Core.Entities;
using ProjectTemplate.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to sync entites");
            //var command = Console.ReadKey();

            var path = @"C:\Users\gisaiashvili\source\repos\ProjectTemplate";

            SyncronizeEntities(path);

            Console.ReadKey();
        }

        private static void SyncronizeEntities(string projectPath)
        {
            var mapperProfile = GetAutomapperProfileImplementation(projectPath);

            var entities = GetEntites();

            foreach (var entity in entities)
            {
                if (IsEntityAlreadyAdded(projectPath, entity))
                {
                    continue;
                }

                var dtoFactory = new DtoFactory(projectPath, entity);

                dtoFactory.CreateDtoDirectory();

                dtoFactory.CreateDto("CreateDtoTemplate.txt");
                dtoFactory.CreateDto("UpdateDtoTemplate.txt");
                dtoFactory.CreateDto("ReadDtoTemplate.txt");
            }
        }

        private static IEnumerable<Type> GetEntites()
        {
            Assembly mscorlib = typeof(EntityBase).Assembly;
            var resp = mscorlib.GetTypes().Where(t => t.Name != "EntityBase");
            return resp;
        }
        private static string GetAutomapperProfileImplementation(string projectPath)
        {
            var path = $@"{projectPath}\ProjectTemplate.Services";
            string mapperProfile = File.ReadAllText(Directory.EnumerateFiles(path, "AutomapperProfile.cs").FirstOrDefault(f => FileHelper.GetFileNameFromPath(f) == "AutomapperProfile.cs"));

            var startingIndex = mapperProfile.LastIndexOf('{');
            var endingIndex = mapperProfile.IndexOf('}');

            var implementation = mapperProfile.Substring(startingIndex + 1, endingIndex - startingIndex - 1);

            return implementation;
        }

        // დროებით ეს ნიშნავდეს რომ უკვე გადატარებულია ამ ენთითიზე.
        private static bool IsEntityAlreadyAdded(string projectPath, Type entity)
        {
            string dtoDir = $"{projectPath}\\ProjectTemplate.Services\\Dtos\\{entity.Name}Dtos";
            return Directory.Exists(dtoDir);
        }
    }
}
