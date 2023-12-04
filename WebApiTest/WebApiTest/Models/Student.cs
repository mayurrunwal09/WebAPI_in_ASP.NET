using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiTest.Models
{
    public class Student 
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Plase  Enter Student First Name")]
        [StringLength(50)]
        [DisplayName("Student First Name")]
        public string FirstName { get;set; }
        [Required(ErrorMessage = "Plase  Enter Student Last Name")]
        [StringLength(50)]
        [DisplayName("Student Last Name")]
        public string LastName { get;set; }
        [Required(ErrorMessage ="Plase Enter Date of birth")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get;set; }
        [Required(ErrorMessage = "Plase  Enter Student First Name")]
        [StringLength(200)]
        [DisplayName("Enter Students Address")]
        public string Address { get;set; }



        [JsonIgnore]
        public IList<Enrollment>  Enrollments { get; set; }
    }
}
