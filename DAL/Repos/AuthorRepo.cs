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
    internal class AuthorRepo : Repo, IRepo<Author>
    {
        public Author Add(Author c)
        {
            _context.Authors.Add(c);

            if(_context.SaveChanges() > 0) return c;

            return null;
        }

        public Author Delete(int id)
        {
            var author = _context.Authors.Find(id);

            if(author != null)
            {
                _context.Authors.Remove(author);

                if(_context.SaveChanges() > 0) return author;

                return null;
            }

            return null;

        }

        public List<Author> Get(int page = 1, int pageSize = 10)
        {
            return _context.Authors.ToList();
        }

        public Author Get(int id)
        {

            var data = _context.Authors
                .Include(x => x.BookAuthorMaps)
                .ThenInclude(y => y.Book)
                .SingleOrDefault(b => b.Id == id);

            return data;
        }

        public Author Update(Author c)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == c.Id);

            if (author == null) return null;

            _context.Entry(author).CurrentValues.SetValues(c);

            if (_context.SaveChanges() > 0) return author;

            return null;
        }
    }
}
