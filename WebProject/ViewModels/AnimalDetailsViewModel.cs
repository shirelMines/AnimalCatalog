using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.ViewModels
{
    public class AnimalDetailsViewModel
    {
       public Animal Animals{ get; set; }
       public IEnumerable<Comment> Comments { get; set; }
       //public Category Category { get; set; }
       public Comment Comment { get; set; }
    }
}
