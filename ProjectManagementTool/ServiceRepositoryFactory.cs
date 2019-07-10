using ProjectTemplate.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class RepositoryInterfaceFactory
    {
        private readonly string _repositoryInterfacePath;
        private readonly string _templatePath;
        private readonly Type _entity;

        public RepositoryInterfaceFactory(string projectPath, Type entity)
        {
            _entity = entity;
            _templatePath = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
            _repositoryInterfacePath = $@"{projectPath}\ProjectTemplate.Repository\Interfaces";
        }

        public void CreateRepositoryInterface()
        {
            var template = FileHelper.GetFile(_templatePath, "RepositoryInterfaceTemplate.txt");
            var content = template.Replace("[ENTITY_NAME]", _entity.Name);
            FileHelper.CreateFile(_repositoryInterfacePath + "\\I" + _entity.Name + "Repository.cs", content);
        }
    }
}
