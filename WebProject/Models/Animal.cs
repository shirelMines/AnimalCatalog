using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Display(Name ="Name:")]
        [Required(ErrorMessage = "Plese enter Name")]
        public string Name { get; set; }

        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Plese enter Age")]
        [Range(0,110)]
        
        public int Age { get; set; }

        [Display(Name = "Picture:")]
        [Required(ErrorMessage = "Plese upload picture")]
        public string PictureName { get; set; }

        [Display(Name = "Description:")]
        [Required(ErrorMessage = "Plese enter Description")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

        [NotMapped]
        [Display(Name = "Picture:")]
        [Required(ErrorMessage = "Plese upload picture")]
        public IFormFile ImageFile { get; set; }
    }
}
