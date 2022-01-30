using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.HomePage
{
    public class HomePageAboutSection : BaseEntity
    {
        public string Image { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string BtnText { get; set; }
    }
}
