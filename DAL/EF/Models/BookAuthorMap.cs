using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class BookAuthorMap
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Required, ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
