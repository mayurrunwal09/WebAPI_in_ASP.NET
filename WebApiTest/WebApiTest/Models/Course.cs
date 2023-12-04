using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiTest.Models
{
    public class Course 
    {
        [Key]
        public int CourseId { get; set; }   
        [Required(ErrorMessage ="Please Enter Course Name")]
        [StringLength(100)]
        [DisplayName("Course Name")]
        public string CoueseName { get;set; }
        [Required(ErrorMessage = "Please Enter Instructor Name")]
        [StringLength(100)]
        [DisplayName("Instructor Name")]
        public string Instructor { get;set; }
        [Required]
        [DisplayName("Credit")]
        public double Credit { get;set; }

        [JsonIgnore]
       
      public IList<Enrollment> Enrollments { get; set; }
    }
}
