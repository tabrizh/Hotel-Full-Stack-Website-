﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels
{
    public class SliderImageViewModel
    {
        public IFormFile[] Files { get; set; }
    }
}
