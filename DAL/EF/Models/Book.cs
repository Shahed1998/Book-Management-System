using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Required,StringLength(50)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public BookType Type { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;

        [Required, ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        [Required]
        public ICollection<BookAuthorMap> BookAuthorMaps { get; set; }

        public Book()
        {
            BookAuthorMaps = new List<BookAuthorMap>();
        }


      
    }

    public enum BookType
    {
            Fantasy,
            Science,
            Horror
    }
}
