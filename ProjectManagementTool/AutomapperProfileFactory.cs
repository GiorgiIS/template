using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementTool
{
    public class AutomapperProfileFactory
    {
        private readonly string _projectPath;
        private readonly Type _entity;

        public AutomapperProfileFactory(string projectPath, Type entity)
        {
            _projectPath = projectPath;
            _entity = entity;
        }

        public void CreateMapperProfile()
        {
            var automapperProfile = FileHelper.GetFile($@"{_projectPath}\ProjectTemplate.Services", "AutomapperProfile.cs");
            var automapperProfileImplementation = GetAutomapperProfileImplementation(automapperProfile).Trim();
            var autoMapperUsingStatements = GetAutomapperUsingStatements(automapperProfile).Trim();

            var additionalUsingStatement = $"\nusing ProjectTemplate.Services.Dtos.{_entity.Name}Dtos;";
            var allUsingStatements = autoMapperUsingStatements + additionalUsingStatement;

            var createDtoMapperStatement = $"\n\t\t\tCreateMap<{_entity.Name}, {_entity.Name}CreateDto>().ReverseMap();";
            var updateDtoMapperStatement = $"\n\t\t\tCreateMap<{_entity.Name}, {_entity.Name}UpdateDto>().ReverseMap();";
            var readDtoMapperStatement = $"\n\t\t\tCreateMap<{_entity.Name}, {_entity.Name}ReadDto>().ReverseMap();\n\n";
            var allImplementation = (automapperProfileImplementation + "\n" + createDtoMapperStatement + updateDtoMapperStatement + readDtoMapperStatement).Trim();

            var template = FileHelper.GetFile($@"{_projectPath}\ProjectManagementTool\ObjectTemplates", "AutomapperProfileTemplate.txt");

            var newContent = template.Replace("[USING_STATEMENTS]", allUsingStatements)
                                      .Replace("[CONFIGURE_MAPS]", allImplementation);

            var mapperProfilerFullPath = $@"{_projectPath}\ProjectTemplate.Services\AutomapperProfile.cs";

            FileHelper.CreateFile(mapperProfilerFullPath, newContent);
        }

        private string GetAutomapperProfileImplementation(string mapperProfile)
        {
            var startingIndex = mapperProfile.LastIndexOf('{');
            var endingIndex = mapperProfile.IndexOf('}');

            var implementation = mapperProfile.Substring(startingIndex + 1, endingIndex - startingIndex - 1);

            return implementation;
        }

        private string GetAutomapperUsingStatements(string mapperProfile)
        {
            var endingIndex = mapperProfile.IndexOf("namespace");
            var implementation = mapperProfile.Substring(0, endingIndex);
            return implementation;
        }
    }
}


