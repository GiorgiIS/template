﻿using ProjectTemplate.Core.Entities;
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
                var entityName = e.Name;
                string dtoDir = $"{projectPath}\\ProjectTemplate.Services\\Dtos\\{entityName}Dtos";

                // ეს ნიშნავს იმას რომ უკვე გადატარებულია ამ ენთითიზე
                if (Directory.Exists(dtoDir))
                {
                    continue;
                }

                Directory.CreateDirectory(dtoDir);

                var dtoProperties = e.GetProperties().Where(p => p.Name != "CreatedAt" && p.Name != "UpdatedAt" && p.Name != "DeletedAt" && p.Name != "Id").ToList();

                var createDtoTemplate = GetDtoTemplate(projectPath, "CreateDtoTemplate.txt");
                var createDtoContent = AddDto(createDtoTemplate, entityName, dtoProperties);
                var createDtoName = $@"{dtoDir}\{entityName}CreateDto.cs";
                using (FileStream fs = File.Create(createDtoName))
                {
                    byte[] content = new UTF8Encoding(true).GetBytes(createDtoContent);
                    fs.Write(content, 0, content.Length);
                }

                var updateDtoTemplate = GetDtoTemplate(projectPath, "UpdateDtoTemplate.txt");
                var updateDtoContent = AddDto(updateDtoTemplate, entityName, dtoProperties);
                var updateDtoName = $@"{dtoDir}\{entityName}UpdateDto.cs";
                using (FileStream fs = File.Create(updateDtoName))
                {
                    byte[] content = new UTF8Encoding(true).GetBytes(updateDtoContent);
                    fs.Write(content, 0, content.Length);
                }

                var readDtoTemplate = GetDtoTemplate(projectPath, "ReadDtoTemplate.txt");
                var readDtoContent = AddDto(readDtoTemplate, entityName, dtoProperties);
                var readDtoName = $@"{dtoDir}\{entityName}ReadDto.cs";
                using (FileStream fs = File.Create(readDtoName))
                {
                    byte[] content = new UTF8Encoding(true).GetBytes(readDtoContent);
                    fs.Write(content, 0, content.Length);
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

        private static string AddDto(string dtoTemplate, string entityName, List<PropertyInfo> entityProperties)
        {
            var properties = string.Join("\n\t\t", entityProperties.Select(ep => "public " + ep.ToString() + " { get; set; }"));
            var dto = dtoTemplate.Replace("[ENTITY_NAME]", entityName)
                .Replace("[PROPERTIES]", properties)
                .Replace("System.", "")
                .Replace("Int32", "int")
                .Replace("String", "string");

            return dto;
        }

        private static string GetDtoTemplate(string projectPath, string templateName)
        {
            var path = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            string implementation = File.ReadAllText(Directory.EnumerateFiles(path, templateName).FirstOrDefault(f => GetFileNameFromPath(f) == templateName));
            return implementation;
        }
    }
}
