using MVCFinalProject.Models.Pages.AboutPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Views.ViewModels
{
    public class AboutPageViewModel
    {
        public AboutPageSectionBanner AboutPageSectionBanner { get; set; }
        public AboutPageCEOSection AboutPageCEOSection { get; set; }
        public ICollection<Features> Features { get; set; }
        public AboutPageVideoSection AboutPageVideoSection { get; set; }
        public AboutPageTeamSection TeamSection { get; set; }
        public ICollection<TeamMembers> TeamMembers { get; set; }
    }
}
