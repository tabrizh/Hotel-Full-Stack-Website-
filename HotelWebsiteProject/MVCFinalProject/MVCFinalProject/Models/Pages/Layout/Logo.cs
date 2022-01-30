using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Models.Pages.Layout
{
    public class Logo : BaseEntity
    {
        public string LogoURL { get; set; }
    }
}
