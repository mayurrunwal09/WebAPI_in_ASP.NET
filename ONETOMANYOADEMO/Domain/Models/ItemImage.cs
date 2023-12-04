using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ItemImage : BaseEntity
    {
        [Required(ErrorMessage ="Select Item")]
        public Guid ItemId { get; set; }

        public string ItemImages { get; set; }

        [JsonIgnore]
        public virtual Item Item { get; set; }
    }
}
