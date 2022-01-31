using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.TeamViewModels
{
    public class TeamUpdateViewModel
    {
        [Required, MinLength(5)]
        public string Name { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public IFormFile File { get; set; }

        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }

        //Get
        public string Image { get; set; }
    }
}
