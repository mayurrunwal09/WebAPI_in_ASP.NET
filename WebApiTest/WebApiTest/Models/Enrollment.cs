using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiTest.Models
{
    public class Enrollment 
    {
        [Key]
        public int EnrollmentId { get; set; }
 
      
        [Required(ErrorMessage = "Plase Enter Enrollment Date")]
        [DisplayFormat(DataFormatString = "{00:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int StudenId { get;set; }
        public int CourseId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
        
        public Course Course { get; set; }


    }
}
