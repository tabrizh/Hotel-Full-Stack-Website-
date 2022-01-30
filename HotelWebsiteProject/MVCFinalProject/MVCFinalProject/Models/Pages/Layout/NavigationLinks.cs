using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Models.Pages.Layout
{
    public class NavigationLinks : BaseEntity
    {
        public string NavLink { get; set; }
        public string NavController { get; set; }
        public string NavAction { get; set; }
    }
}
