using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, Range(1,5)]
        public byte GivenStars { get; set; }

        [Required, MinLength(10, ErrorMessage = "Minimum length can be 10 characters")]
        public string CommentText { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int RoomId { get; set; }
    }
}
