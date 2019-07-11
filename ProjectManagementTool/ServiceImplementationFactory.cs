using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class ServiceImplementationFactory
    {
        private readonly Type _entity;
        private readonly string _serviceImplementationTemplatePath;
        private readonly string _serviceImplementationFolderPath;

        public ServiceImplementationFactory(string projectPath, Type entity)
        {
            _entity = entity;
            _serviceImplementationTemplatePath = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            _serviceImplementationFolderPath = $@"{projectPath}\ProjectTemplate.Application";
        }

        public void Create()
        {
            var serviceTemplate = FileHelper.GetFile(_serviceImplementationTemplatePath, "ServiceInterfaceImplementationTemplate.txt");
            var serviceImplementation = serviceTemplate.Replace("[ENTITY_NAME]", _entity.Name);

            FileHelper.CreateFile(_serviceImplementationFolderPath + $"\\{_entity.Name}Service.cs", serviceImplementation);
        }
    }
}
