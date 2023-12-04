using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Catagery : BaseEntity
    {
        [Required(ErrorMessage ="Enter Catagory name")]
        [StringLength(100)]
        public string CatageryName { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}
