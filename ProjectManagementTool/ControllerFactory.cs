using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class ControllerFactory
    {
        private readonly Type _entity;
        private readonly string _controllerTemplatePath;
        private readonly string _controllerImplementationFolderPath;

        public ControllerFactory(string projectPath, Type entity)
        {
            _entity = entity;
            _controllerTemplatePath = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            _controllerImplementationFolderPath = $@"{projectPath}\ProjectTemplate.Api\Controllers";
        }

        public void Create()
        {
            var controllerTemplate = FileHelper.GetFile(_controllerTemplatePath, "ControllerTemplate.txt");
            var controllerImplementation = controllerTemplate.Replace("[ENTITY_NAME]", _entity.Name);

            FileHelper.CreateFile(_controllerImplementationFolderPath + $"\\{_entity.Name}Controller.cs", controllerImplementation);
        }
    }
}
