using MVCFinalProject.Areas.Admin.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.Utilities
{
    public static class FileUtility
    {
        public static string CreateFile(string folderPath, IFormFile file)
        {
            string fileName = Guid.NewGuid() + file.FileName;

            var path = Path.Combine(folderPath, fileName);

            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            stream.Close();
            return fileName;
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
