using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Models.Pages.RoomPage
{
    public class RoomPageBanner : BaseEntity
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string BgImage { get; set; }
    }
}
