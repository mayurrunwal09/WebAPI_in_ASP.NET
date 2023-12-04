using System.ComponentModel.DataAnnotations;

namespace model_popup.Models
{
    public class Bank_Details
    {
        [Required]
        [Key]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "Account number must be between 12 and 14 characters.")]
        public int Account_number { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "IFSC code must be 11 characters.")]
        public int IFSC_Code { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number.")]
        public int Mobile_Number { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Zip code must be 6 characters.")]
        public int Zip_code { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name of customer cannot exceed 50 characters.")]
        public string Name_of_customer { get; set; }
    }
}
