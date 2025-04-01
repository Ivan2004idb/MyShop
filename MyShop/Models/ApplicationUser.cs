using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class ApplicationUser 
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName2 { get; set; }

           [Required, MaxLength(100)]
        public string Number { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string Login { get; set; }

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }

        public bool PolicyAgreed { get; set; }
    }
}