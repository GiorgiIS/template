using ProjectTemplate.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class ServiceInterfaceFactory
    {
        private readonly string _serviceInterfacePath;
        private readonly string _templatePath;
        private readonly Type _entity;

        public ServiceInterfaceFactory(string projectPath, Type entity)
        {
            _entity = entity;
            _templatePath = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            _serviceInterfacePath = $@"{projectPath}\ProjectTemplate.Services\Interfaces";
        }

        public void CreateServiceInterface()
        {
            var template = FileHelper.GetFile(_templatePath, "ServiceInterfaceTemplate.txt");
            var content = template.Replace("[ENTITY_NAME]", _entity.Name);
            FileHelper.CreateFile(_serviceInterfacePath + "\\I" + _entity.Name + "Service.cs", content);
        }
    }
}
