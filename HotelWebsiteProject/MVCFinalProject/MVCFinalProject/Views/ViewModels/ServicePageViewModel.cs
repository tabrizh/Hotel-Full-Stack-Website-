using MVCFinalProject.Models.Entities;
using MVCFinalProject.Models.Pages.ServicePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class ServicePageViewModel
    {
        public ServicePageBannerSection ServicePageBannerSection { get; set; }
        public ServicePageServicesSection ServicePageServicesSection { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
