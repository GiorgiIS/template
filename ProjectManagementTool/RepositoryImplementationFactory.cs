using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class RepositoryImplementationFactory
    {
        private readonly Type _entity;
        private readonly string _repositoryImplementationTemplatePath;
        private readonly string _repositoryImplementationFolderPath;

        public RepositoryImplementationFactory(string projectPath, Type entity)
        {
            _entity = entity;
            _repositoryImplementationTemplatePath = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            _repositoryImplementationFolderPath = $@"{projectPath}\ProjectTemplate.Repository\Implementations";
        }

        public void Create()
        {
            var repositoryTemplate = FileHelper.GetFile(_repositoryImplementationTemplatePath, "RepositoryInterfaceImplementationTemplate.txt");
            var repositoryImplementation = repositoryTemplate.Replace("[ENTITY_NAME]", _entity.Name);

            FileHelper.CreateFile(_repositoryImplementationFolderPath + $"\\{_entity.Name}Repository.cs", repositoryImplementation);
        }
    }
}
