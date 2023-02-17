using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class DataSeeder
    {
        private readonly BookManagementContext bookManagementContext;
        public DataSeeder(BookManagementContext bookManagementContext)
        {
            this.bookManagementContext = bookManagementContext;

        }

        public void Seed() 
        {
            Random rnd = new Random();

            if (!bookManagementContext.Publishers.Any())
            {
                var publishers = new List<Publisher>();
                for(int i = 0; i < 100; i++)
                {
                    var publisher = new Publisher();
                    publisher.Name = "publisher" + i;
                    publishers.Add(publisher);
                }
                bookManagementContext.Publishers.AddRange(publishers);
            };

            

            if (!bookManagementContext.Books.Any())
            {
                var books = new List<Book>();
                for (int i = 0; i < 100; i++)
                {
                    var book = new Book();
                    book.Title = "book" + i;
                    book.Type = (BookType)rnd.Next(0,3);
                    book.Description = Guid.NewGuid().ToString();
                    book.Price = rnd.Next(1000, 10000);
                    book.PublisherId = rnd.Next(1,101);
                    books.Add(book);
                }
                bookManagementContext.Books.AddRange(books);
            };

            

            if(!bookManagementContext.Authors.Any())
            {
                var authors = new List<Author>();

                for(int i = 0; i < 100; i++)
                {
                    var author = new Author();
                    author.Name = "author" + i;
                    author.DOB = DateTime.Now;
                    author.shortBio = Guid.NewGuid().ToString();
                    authors.Add(author);
                }

                bookManagementContext.Authors.AddRange(authors);
            } /**/

            bookManagementContext.SaveChanges();
        }
    }
}

