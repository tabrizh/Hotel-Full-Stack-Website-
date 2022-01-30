using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.ContactPage
{
    public class ContactPageMapSection : BaseEntity
    {
        public string Heading { get; set; }
        public string? Location { get; set; }
    }
}
