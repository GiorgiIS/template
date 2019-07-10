using ProjectTemplate.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class DbContextFactory
    {
        private readonly string _projectPath;
        private readonly string _dbContextPath;
        private readonly string _dbContextTemplatePath;
        private readonly Type _entity;

        public DbContextFactory(string projectPath, Type entity)
        {
            _projectPath = projectPath;
            _entity = entity;
            _dbContextPath = $"{projectPath}\\ProjectTemplate.Repository.EF";
            _dbContextTemplatePath = $@"{projectPath}\ProjectManagementTool\ObjectTemplates";
        }

        public void CreateDbContext()
        {
            var dbContextContent = GetDbContextContent();
            var dbSetName = TextHelper.ConvertWordToPlural(_entity.Name);
            var newContent = dbContextContent.Replace("protected override void OnConfiguring",
                "public DbSet<" + _entity.Name + "> " + dbSetName + " { get; set; } \n\n\t\tprotected override void OnConfiguring");

            FileHelper.CreateFile(_dbContextPath + "\\CustomDbContext.cs", newContent);
        }

        private string GetDbContextContent()
        {
            return FileHelper.GetFile(_dbContextPath, "CustomDbContext.cs");
        }
    }
}
