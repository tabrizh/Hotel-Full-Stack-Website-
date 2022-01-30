using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.AboutPage
{
    public class AboutPageCEOSection : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string JobTitle { get; set; }
        public string Image { get; set; }
    }
}