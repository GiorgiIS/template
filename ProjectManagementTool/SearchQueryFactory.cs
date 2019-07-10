using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class SearchQueryFactory
    {
        private readonly string _projectPath;
        private readonly Type _entity;
        private readonly List<PropertyInfo> _entityProperties;
        private readonly string _searchQueryTemplatePath;
        private readonly string _searchQueryFolderPath;

        public SearchQueryFactory(string projectPath, Type entity)
        {
            _projectPath = projectPath;
            _entity = entity;
            _entityProperties = _entity.GetProperties().Where(p => p.Name != "CreatedAt" && p.Name != "UpdatedAt" && p.Name != "DeletedAt" && p.Name != "Id").ToList();
            _searchQueryTemplatePath = $@"{_projectPath}\ProjectManagementTool\ObjectTemplates";
            _searchQueryFolderPath = $@"{_projectPath}\ProjectTemplate.Common.Api\RequestModels";
        }

        public void CreateSearchQuery()
        {
            var searchQueryTemplate = FileHelper.GetFile(_searchQueryTemplatePath, "SearchQueryTemplate.txt");

            var properties = _entityProperties.Where(p => p.PropertyType != typeof(DateTime) && p.PropertyType != typeof(DateTime?))
                .Select(ep => "public " + ep.ToString() + " { get; set; }").ToList();

            foreach (var p in _entityProperties)
            {
                if (p.PropertyType == typeof(DateTime))
                {
                    properties.Add($"public DateTime {p.Name}From" + " { get; set; }");
                    properties.Add($"public DateTime {p.Name}To" + " { get; set; }");
                }
                else if (p.PropertyType == typeof(DateTime?))
                {
                    properties.Add($"public DateTime? {p.Name}From" + " { get; set; }");
                    properties.Add($"public DateTime? {p.Name}To" + " { get; set; }");
                }
            }

            var propertiesAsString = string.Join("\n\t\t", properties);

            var searchQueryImplementation = searchQueryTemplate.Replace("[ENTITY_NAME]", _entity.Name)
                .Replace("[PROPERTIES]", propertiesAsString)
                .Replace("System.", "")
                .Replace("Int32", "int")
                .Replace("String", "string");

            FileHelper.CreateFile(_searchQueryFolderPath + $"\\{_entity.Name}SearchQuery.cs", searchQueryImplementation);
        }
    }
}
