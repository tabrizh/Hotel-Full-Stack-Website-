using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Models.Pages.Layout
{
    public class FooterTags : BaseEntity
    {
        public string Icon { get; set; }
        public string TagName { get; set; }
        public string TagText { get; set; }
    }
}
