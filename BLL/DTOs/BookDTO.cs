using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, EnumDataType(typeof(BookType))]
        public BookType Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;

        [Required]
        public int PublisherId { get; set; }

        public PublisherDTO? Author { get; set; }

    }

    public class BookDTO2
    {
        public int Id { get; set; }

        public int TotalCount { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, EnumDataType(typeof(BookType))]
        public BookType Type { get; set; }

        //public PublisherDTO2? Publisher { get; set; }

        //public ICollection<AuthorDTO2> Authors { get; set; }

    }

    public class BookDTO3
    {
        [Required]
        public string Title { get; set; }

        [Required, EnumDataType(typeof(BookType))]
        public BookType Type { get; set; }

        [Required, StringLength(50)]
        public DateTime PublishedDate { get; set; }
    }

    public class BookDTO4
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, EnumDataType(typeof(BookType))]
        public BookType Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;

        [Required]
        public int PublisherId { get; set; }

        public DateTime PublishedDate { get; set; }

    }

    public class BookDTO5
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required, EnumDataType(typeof(BookType))]
        public BookType Type { get; set; }

        [Required, StringLength(50)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;

        public PublisherDTO2? Publisher { get; set; }

        public ICollection<AuthorDTO2> Authors { get; set; }

    }
}
