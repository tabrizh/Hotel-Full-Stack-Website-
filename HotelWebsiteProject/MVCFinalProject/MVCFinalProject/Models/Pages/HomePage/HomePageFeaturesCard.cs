using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.HomePage
{
    public class HomePageFeaturesCard : BaseEntity
    {
        public int Count { get; set; }
        public string Text { get; set; }
    }
}
