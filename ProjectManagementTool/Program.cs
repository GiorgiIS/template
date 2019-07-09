using ProjectTemplate.Core.Entities;
using ProjectTemplate.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to sync entites");
            //var command = Console.ReadKey();

            var path = @"C:\Users\gisaiashvili\source\repos\ProjectTemplate";

            SyncronizeEntities(path);

            Console.ReadKey();
        }

        private static void SyncronizeEntities(string projectPath)
        {
            var entities = GetEntites();

            foreach (var entity in entities)
            {
                if (IsEntityAlreadyAdded(projectPath, entity))
                {
                    continue;
                }
                else
                {
                    var dtoFactory = new DtoFactory(projectPath, entity);
                    dtoFactory.CreateDtoDirectory();
                    dtoFactory.CreateDtos();

                    var mapperProifileFactory = new AutomapperProfileFactory(projectPath, entity);
                    mapperProifileFactory.CreateMapperProfile();

                    var searchQueryFactory = new SearchQueryFactory(projectPath, entity);
                    searchQueryFactory.CreateSearchQuery();
                }
            }
        }

        private static IEnumerable<Type> GetEntites()
        {
            Assembly mscorlib = typeof(EntityBase).Assembly;
            var resp = mscorlib.GetTypes().Where(t => t.Name != "EntityBase");
            return resp;
        }


        // დროებით ეს ნიშნავდეს რომ უკვე გადატარებულია ამ ენთითიზე.
        private static bool IsEntityAlreadyAdded(string projectPath, Type entity)
        {
            string dtoDir = $"{projectPath}\\ProjectTemplate.Services\\Dtos\\{entity.Name}Dtos";
            return Directory.Exists(dtoDir);
        }
    }
}
