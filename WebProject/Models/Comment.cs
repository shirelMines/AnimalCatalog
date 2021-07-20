using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }

        [Display(Name ="Add comment:")]
        public string CommentString { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
