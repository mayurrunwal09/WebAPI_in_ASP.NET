using System.ComponentModel.DataAnnotations;

namespace webapi3.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Director { get; set; }
    }
}
