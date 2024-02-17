using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj Tytuł")]
        [StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Podaj immie Autora")]
        public string Author { get; set; }
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Podaj Gatunek Książki")]
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        [Required(ErrorMessage = "Podaj date wydania")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Podaj ilość na stanie")]
        [Range(1, 20, ErrorMessage = "Ilość min 1 | maks 20")]
        public byte NumberInStock { get; set; }
    }
}
