using ProjectTemplate.Core.Entities;
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
            var command = Console.ReadKey();

            GetEntites();

            var path = @"C:\Users\gisaiashvili\source\repos\ProjectTemplate";

            SyncronizeEntities(path);

            Console.ReadKey();
        }

        private static void SyncronizeEntities(string projectPath)
        {
            var entities = GetEntites();

            foreach (var e in entities)
            {
                var createDtoTemplate = GetCreateDtoTemplate(projectPath);

                var entityName = e.Name;
                var createDtoProporties = e.GetProperties().Where(p => p.Name != "CreatedAt" && p.Name != "UpdatedAt" && p.Name != "DeletedAt" && p.Name != "Id").ToList();

                string dtoDir = $"{projectPath}\\ProjectTemplate.Services\\Dtos\\{entityName}Dtos";

                if (!Directory.Exists(dtoDir))
                {
                    Directory.CreateDirectory(dtoDir);
                }

                var createDtoContent = AddCreateDto(createDtoTemplate, entityName, createDtoProporties);

                string createDtoName = $@"{dtoDir}\{entityName}CreateDto.cs";

                if (!File.Exists(createDtoName))
                {
                    using (FileStream fs = File.Create(createDtoName))
                    {
                        byte[] content = new UTF8Encoding(true).GetBytes(createDtoContent);
                        fs.Write(content, 0, content.Length);
                    }
                }
            }
        }

        private static IEnumerable<Type> GetEntites()
        {
            Assembly mscorlib = typeof(EntityBase).Assembly;
            var resp = mscorlib.GetTypes().Where(t => t.Name != "EntityBase");
            return resp;

        }

        private static string GetFileNameFromPath(string path)
        {
            var name = path.Substring(path.LastIndexOf('\\'));
            return name.Replace("\\", "");
        }

        private static string AddCreateDto(string createDtoTemplate, string entityName, List<PropertyInfo> entityProperties)
        {
            var properties = string.Join("\n\t\t", entityProperties.Select(ep => "public " + ep.ToString() + " { get; set; }"));
            var createDto = createDtoTemplate.Replace("[ENTITY_NAME]", entityName)
                .Replace("[PROPERTIES]", properties)
                .Replace("System.", "")
                .Replace("Int32", "int")
                .Replace("String", "string");

            return createDto;
        }

        private static void AddUpdateDto()
        {
        }

        private static void AddReadDto()
        {
        }

        private static string GetCreateDtoTemplate(string projectPath)
        {
            var path = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            string implementation = File.ReadAllText(Directory.EnumerateFiles(path, "CreateDtoTemplate.txt").FirstOrDefault(f => GetFileNameFromPath(f) == "CreateDtoTemplate.txt"));
            return implementation;
        }

        private static string GetUpdateDtoTemplate()
        {
            return string.Empty;
        }

        private static string GetReadDtoTemplate()
        {
            return string.Empty;
        }
    }
}
