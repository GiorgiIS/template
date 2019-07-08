using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementTool
{
    public class FileHelper
    {
        public static string GetFileNameFromPath(string path)
        {
            var name = path.Substring(path.LastIndexOf('\\'));
            return name.Replace("\\", "");
        }
    }
}
