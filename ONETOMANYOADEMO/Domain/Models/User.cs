using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage ="This field is required")]
        [StringLength(10)]

        public string UserId { get; set; }

        [Required(ErrorMessage ="This Field is required")]
        [StringLength(100)]
        public string UserName { get; set; }

        [RegularExpression(@"/\S+@\S+\.\S",ErrorMessage ="Enter Valid Email-Id")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        [StringLength(100)]
        public string Password { get; set; }


        [RegularExpression(@"/^[+]?(\d{1,2})+\-(\d{10})/",ErrorMessage ="Enter Mobile Number")]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public string Picture { get;set; }

        public Guid UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }

        public virtual List<SupplierItem> Suppliers { get; set; }

        public virtual List<CustomerItem> CustomerItems { get; set; }

       
    }
}
