﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public  class SupplierViewModel
    {
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string City { get; set; }
        public string Mobileno { get; set; }
        public string Gender { get; set; }
    }
    public class InsertSupplier
    {
        [Required(ErrorMessage = "Supplier ID is required.")]
        public string SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name must be less than or equal to 100 characters.")]
        public string SupplierName { get; set; }

        [StringLength(100, ErrorMessage = "City must be less than or equal to 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number.")]
        public string Mobileno { get; set; }

        [StringLength(10, ErrorMessage = "Gender must be less than or equal to 10 characters.")]
        public string Gender { get; set; }
    }
    public class UpdateSupplier : InsertSupplier
    {
        public int Id { get; set;}
    }
}
