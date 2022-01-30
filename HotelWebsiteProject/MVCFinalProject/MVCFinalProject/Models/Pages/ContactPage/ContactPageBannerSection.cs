using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.ContactPage
{
    public class ContactPageBannerSection : BaseEntity
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
    }
}
