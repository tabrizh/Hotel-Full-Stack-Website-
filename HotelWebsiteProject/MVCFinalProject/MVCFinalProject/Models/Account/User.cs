using Microsoft.AspNetCore.Identity;
using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Account
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Reservations> Reservations { get; set; }
    }
}
