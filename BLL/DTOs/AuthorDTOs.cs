using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AuthorDTOs
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string? shortBio { get; set; }

    }

    public class AuthorDTO2
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string? shortBio { get; set; }

        public int? BookId { get; set; }
    }

    public class AuthorDTO3
    {
        
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public int Count { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string? shortBio { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

    }

    public class AuthorDTO4
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Count { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string? shortBio { get; set; }

        public ICollection<BookDTO4> Books { get; set; }

    }

}
