using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public  class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }

        public Customer Customer { get; set; }

        public Food Food { get; set; }
    }
    public class InsertOrder
    {

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Food ID is required.")]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
    public class UpdateOrder : InsertOrder
    {
        public int Id { get; set; }
    }
}
