using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Customer : BaseEntityClass
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name must be less than or equal to 100 characters.")]
        public string CustomerName { get; set; }

        [StringLength(100, ErrorMessage = "City must be less than or equal to 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number.")]
        public string Mobileno { get; set; }

        [StringLength(10, ErrorMessage = "Gender must be less than or equal to 10 characters.")]
        public string Gender { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
