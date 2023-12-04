using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserType : BaseEntity
    {
        [Required(ErrorMessage ="Enter User Type")]
        [StringLength(20)]
        public string TypeName { get;set; }

        public virtual List<User> Users { get; set; }

    }
}
