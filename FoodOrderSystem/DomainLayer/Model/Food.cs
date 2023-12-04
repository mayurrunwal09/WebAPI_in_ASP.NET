using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Food : BaseEntityClass
    {
        [Required(ErrorMessage = "Food name is required.")]
        [StringLength(100, ErrorMessage = "Food name must be less than or equal to 100 characters.")]
        public string FoodName { get; set; }

        [StringLength(500, ErrorMessage = "Food description must be less than or equal to 500 characters.")]
        public string FoodDescription { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
