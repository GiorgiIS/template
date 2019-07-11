using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class ConfigureServiceHelperFactory
    {
        private readonly Type _entity;
        private readonly string _configureServiceHelperFolderPath;

        public ConfigureServiceHelperFactory(string projectPath, Type entity)
        {
            _entity = entity;
            _configureServiceHelperFolderPath = $@"{projectPath}\ProjectTemplate.Common.Api";
        }

        public void Create()
        {
            var configureServiceHelper = FileHelper.GetFile(_configureServiceHelperFolderPath, "ConfigureServicesHelper.cs");
            var addService = $"services.AddScoped<I{_entity.Name}Service, {_entity.Name}Service>();\n";
            var addRepository = $"\t\t\tservices.AddScoped<I{_entity.Name}Repository, {_entity.Name}Repository>();\n\n";

            var newImplementation = configureServiceHelper.Replace("return services;", addService + addRepository + "\t\t\treturn services;");
            FileHelper.CreateFile(_configureServiceHelperFolderPath + $"\\ConfigureServicesHelper.cs", newImplementation);
        }
    }
}
