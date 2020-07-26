using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tag")]
        public string Name { get; set; }
    }
}
