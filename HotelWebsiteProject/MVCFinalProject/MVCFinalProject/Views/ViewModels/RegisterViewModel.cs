using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(100), MinLength(5, ErrorMessage = "Minimal 5 hərif olamlıdır")]
        public string FullName { get; set; }

        [Required, MaxLength(100), MinLength(4, ErrorMessage = "Minimal 5 hərif olamlıdır")]
        public string UserName { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Şifrələr bir birindən fərqlənir")]
        public string ConfirmPassword { get; set; }
    }
}
