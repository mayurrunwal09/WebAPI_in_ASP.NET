using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item:BaseEntity
    {
        [Required(ErrorMessage ="Enter a Valid Item Code")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage ="Enter Item Name")]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required(ErrorMessage ="Enter the price of Item")]
        public string Price { get;set; }

        public Guid catageryId { get; set; }

        [JsonIgnore]
        public virtual List<ItemImage> Images { get; set; }

        public virtual SupplierItem SupplierItem { get; set; }
        public virtual CustomerItem CustomerItem { get; set; }
        public virtual Catagery Catagery { get; set; }
    }
}
