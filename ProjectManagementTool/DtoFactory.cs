using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class DtoFactory
    {
        private string _projectPath { get; set; }
        private Type _entity { get; set; }

        public DtoFactory(string projectPath, Type entity)
        {
            _projectPath = projectPath;
            _entity = entity;
        }

        public void CreateDto(string dtoFullName)
        {
            var dtoProperties = _entity.GetProperties().Where(p => p.Name != "CreatedAt" && p.Name != "UpdatedAt" && p.Name != "DeletedAt" && p.Name != "Id").ToList();
            string dtoDirectory = $"{_projectPath}\\ProjectTemplate.Services\\Dtos\\{_entity.Name}Dtos";

            var dtoTemplate = GetDtoTemplate(dtoFullName);
            var dtoContent = GetDtoContent(dtoTemplate, _entity.Name, dtoProperties);
            var dtoName = $@"{dtoDirectory}\{_entity.Name}{dtoFullName.Replace("Template.txt", ".cs")}";
            using (FileStream fs = File.Create(dtoName))
            {
                byte[] content = new UTF8Encoding(true).GetBytes(dtoContent);
                fs.Write(content, 0, content.Length);
            }
        }

        public void CreateDtoDirectory()
        {
            string dtoDir = $"{_projectPath}\\ProjectTemplate.Services\\Dtos\\{_entity.Name}Dtos";
            Directory.CreateDirectory(dtoDir);
        }

        private string GetDtoTemplate(string templateName)
        {
            var path = $@"{_projectPath}\ProjectManagementTool\ObjectTemplates";
            string implementation = File.ReadAllText(Directory.EnumerateFiles(path, templateName).FirstOrDefault(f => FileHelper.GetFileNameFromPath(f) == templateName));
            return implementation;
        }
        private string GetDtoContent(string dtoTemplate, string entityName, List<PropertyInfo> entityProperties)
        {
            var properties = string.Join("\n\t\t", entityProperties.Select(ep => "public " + ep.ToString() + " { get; set; }"));
            var dto = dtoTemplate.Replace("[ENTITY_NAME]", entityName)
                .Replace("[PROPERTIES]", properties)
                .Replace("System.", "")
                .Replace("Int32", "int")
                .Replace("String", "string");

            return dto;
        }
    }
}
