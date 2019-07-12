using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectManagementTool
{
    public class PropertyHelper
    {
        public static List<string>TransforPropertysToStatements(List<PropertyInfo> propertys)
        {
            var properties = propertys.Select(ep =>
            {
                var x = ep;
                var property = ep.ToString().ToLower().Contains("nullable") ? ep.ToString().Replace("Nullable`1", "").Replace("[", "").Replace("]", "?") : ep.ToString();
                var propDeclaration = "public " + property + " { get; set; }";

                var normalized = propDeclaration.Replace("System.", "")
                .Replace("Int32", "int")
                .Replace("Int64", "long")
                .Replace("Single", "float")
                .Replace("Decimal", "decimal")
                .Replace("Double", "double")
                .Replace("Boolean", "bool")
                .Replace("Single", "float")
                .Replace("String", "string");

                return normalized;
            });
            

            return properties.ToList();
        }
    }
}
