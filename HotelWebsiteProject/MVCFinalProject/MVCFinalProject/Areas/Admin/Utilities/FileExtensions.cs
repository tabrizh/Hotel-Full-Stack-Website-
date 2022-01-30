using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.Utilities
{
    public static class FileExtensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsGreaterThanGivenSize(this IFormFile file, int kb)
        {
            return file.Length > kb * 1000;
        }
    }
}

