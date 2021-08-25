using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogApplication.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string BlogUserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 5)]
        public string Desciption { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }

        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        // ==Navigation Property==

        //This points to the parent, the AUTHOR of the blog
        [Display(Name="Author")]
        public virtual BlogUser BlogUser { get; set; }

        //This is a reference of all the childs it has
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}
