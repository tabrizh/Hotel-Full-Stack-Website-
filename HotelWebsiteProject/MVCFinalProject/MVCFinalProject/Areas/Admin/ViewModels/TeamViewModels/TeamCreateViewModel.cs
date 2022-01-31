using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.TeamViewModels
{
    public class TeamCreateViewModel
    {
        [Required, MinLength(5)]
        public string Name { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }
    }
}
