using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public String Moviename { get; set; }
        [Required]
        public DateTime? Releasedate { get; set; }

        [Required]
        public string DirectorName { get; set; }
    }
}
