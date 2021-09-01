using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogApplication.ViewModels
{
    public class ContactMe
    {
        [Required]
        [StringLength(80, ErrorMessage = "The {0} must be at least {1} characters long and no less than {2} length.", MinimumLength = 2)]

        public string Name { get; set; }

        [EmailAddress]
        [StringLength(50, ErrorMessage ="The {0} must be at least {1} characters long and no less than {2} length.", MinimumLength = 2)]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {1} characters long and no less than {2} length.", MinimumLength = 2)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {1} characters long and no less than {2} length.", MinimumLength = 2)]
        public string Message { get; set; }
    }
}
