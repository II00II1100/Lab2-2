using LibApp.Models;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }

    }
}