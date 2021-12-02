using System.ComponentModel.DataAnnotations;

namespace MovieWebAppProject.Models
{
    public class Movie
    {
        [Key]
        [Required]
        [Display(Name = "movieTitle")]
        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "description")]
        public string Description { get; set; }

        [Required]
        [Range(10, 25)]
        [Display(Name = "duration")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "artists")]
        public string Artists { get; set; }

        [Required]
        [Display(Name = "genres")]
        public string Genres { get; set; }

    }
}
