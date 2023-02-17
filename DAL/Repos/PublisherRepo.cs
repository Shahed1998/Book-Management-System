using DAL.DataContext;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PublisherRepo : Repo, IRepo<Publisher>, IPublisher
    {
        public Publisher Add(Publisher c)
        {
            c.Id = 0;

            _context.Publishers.Add(c);

            if (_context.SaveChanges() > 0) return c;

            return null;

        }

        public Publisher Delete(int id)
        {
            var author = Get(id);

            _context.Publishers.Remove(author);

            if(_context.SaveChanges() > 0) return author;   

            return null;
        }

        public List<Publisher> Get(int page = 1, int pageSize = 10)
        {
            return _context.Publishers.ToList();
        }

        public Publisher Get(int id)
        {
            return _context.Publishers.SingleOrDefault(x => x.Id == id);
        }

        public Publisher Update(Publisher c)
        {
            var author = Get(c.Id);

            _context.Entry(author).CurrentValues.SetValues(c);

            if(_context.SaveChanges() > 0) return c;

            return null;
        }

        public Publisher GetAllBooksByPublisherId(int AuthorId)
        {
           var author = _context.Publishers.Select(b => new Publisher
             {
                 Name = b.Name,
                 Books = b.Books,
                 Id = b.Id

             }).SingleOrDefault(x => x.Id == AuthorId);

             return author; 
        }

    }
}
