using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        [Key]

        public Guid Id { get; set; }

        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }

        [DisplayName("Active")]
        
        public bool? IsActive { get; set; }
    }
}
