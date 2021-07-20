using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name ="Category:")]
        public string NameCategory { get; set; }
        public virtual ICollection<Animal> Animal { get; set; }
    }
}
