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
        private readonly string _projectPath;
        private readonly Type _entity;
        private readonly List<PropertyInfo> _dtoProperties;
        private readonly string _dtoDirectory;

        public DtoFactory(string projectPath, Type entity)
        {
            _projectPath = projectPath;
            _entity = entity;
            _dtoProperties = _entity.GetProperties().Where(p => p.Name != "CreatedAt" && p.Name != "UpdatedAt" && p.Name != "DeletedAt" && p.Name != "Id").ToList();
            _dtoDirectory = $"{_projectPath}\\ProjectTemplate.Services\\Dtos\\{_entity.Name}Dtos";
        }

        public void CreateDtos()
        {
            CreateDto("Create");
            CreateDto("Read");
            CreateDto("Update");
        }

        public void CreateDtoDirectory()
        {
            string dtoDirectoryPath = $"{_projectPath}\\ProjectTemplate.Services\\Dtos\\{_entity.Name}Dtos";
            FileHelper.CreateDirectory(dtoDirectoryPath);
        }

        private string GetDtoTemplate(string templateName)
        {
            var fullPath = $@"{_projectPath}\ProjectManagementTool\ObjectTemplates";
            return FileHelper.GetFile(fullPath, templateName);
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

        private void CreateDto(string dtoType)
        {
            var dtoTemplate = GetDtoTemplate($"{dtoType}DtoTemplate.txt");
            var dtoContent = GetDtoContent(dtoTemplate, _entity.Name, _dtoProperties);
            var dtoPath = $@"{_dtoDirectory}\{_entity.Name}{$"{dtoType}Dto.cs"}";
            FileHelper.CreateFile(dtoPath, dtoContent);
        }
    }
}
