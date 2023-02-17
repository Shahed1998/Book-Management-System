using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string? shortBio { get; set; }

        [Required]
        public ICollection<BookAuthorMap> BookAuthorMaps { get; set; }

        public Author()
        {
            BookAuthorMaps = new List<BookAuthorMap>();
        }

    }
}
