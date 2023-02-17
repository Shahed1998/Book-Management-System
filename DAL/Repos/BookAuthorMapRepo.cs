using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookAuthorMapRepo : Repo, IRepo<BookAuthorMap>, IBookAuthor
    {
        public BookAuthorMap Add(BookAuthorMap c)
        {
            try
            {
                _context.BookAuthorMaps.Add(c);
                _context.SaveChanges();
                return c;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public BookAuthorMap Delete(int id)
        {
            var map = _context.BookAuthorMaps.Find(id);
            _context.BookAuthorMaps.Remove(map);
            if (_context.SaveChanges()>0) { return map; }
            return null;
        }

        public bool Delete(int authorId, int bookId)
        {
            var map = _context.BookAuthorMaps.Where(x => x.AuthorId == authorId && x.BookId == bookId).FirstOrDefault();
            _context.BookAuthorMaps.Remove(map);
            if(_context.SaveChanges() > 0) { return true; }
            return false;
        }

        public List<BookAuthorMap> Get(int page = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public BookAuthorMap Get(int id)
        {
            throw new NotImplementedException();
        }

        public BookAuthorMap Update(BookAuthorMap c)
        {
            throw new NotImplementedException();
        }
    }
}
