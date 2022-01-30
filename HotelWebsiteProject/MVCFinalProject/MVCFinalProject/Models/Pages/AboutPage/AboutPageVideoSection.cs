﻿using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.AboutPage
{
    public class AboutPageVideoSection : BaseEntity
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string ButtonText { get; set; }
    }
}
