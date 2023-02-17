using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorServices
    {
        public static AuthorDTOs Add(AuthorDTOs dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorDTOs, Author>();
                cfg.CreateMap<Author, AuthorDTOs>();
            });

            var mapper = new Mapper(config);

 
            var obj = DataAccessFactory.AuthorDataAccess().Add(mapper.Map<Author>(dto)); 

            return mapper.Map<AuthorDTOs>(obj);
        }

        public static List<AuthorDTO3> GetNP()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO3>();
            });

            var mapper = new Mapper(config);

            var data = DataAccessFactory.AuthorDataAccess().Get();

            var count = data.Count();

            var dtoObj = mapper.Map<List<AuthorDTO3>>(data);

            dtoObj.ForEach(obj => obj.Count = count);

            return dtoObj;
        }

        public static List<AuthorDTO3> Get(RouteParamsDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO3>();
            });

            var mapper = new Mapper(config);

            var data = DataAccessFactory.AuthorDataAccess().Get();

            var count = data.Count();

            data = data.OrderByDescending(s => s.Id).ToList();

            if (dto.search != null)
            {
                data = data.Where(p => p.Name.ToLower().Contains(dto.search.ToLower())).ToList();
            }

            data = data.Skip(dto.pageSize * (dto.page - 1)).Take(dto.pageSize).ToList();

            var dtoObj = mapper.Map<List<AuthorDTO3>>(data);

            dtoObj.ForEach(obj => obj.Count = count);

            return dtoObj;
        }

        public static AuthorDTO4 Get(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO4>();
                cfg.CreateMap<Book, BookDTO4>();
            });

            var mapper = new Mapper(config);

            var obj = DataAccessFactory.AuthorDataAccess().Get(id);

            var dtoObj = mapper.Map<AuthorDTO4>(obj);

            ICollection<BookDTO4> bookDTO = new List<BookDTO4>();

            foreach(var books in obj.BookAuthorMaps)
            {
                var dto = new BookDTO4();
                dto.Id = books.Book.Id;
                dto.Title = books.Book.Title;
                dto.Type = books.Book.Type;
                bookDTO.Add(dto);
            }

            dtoObj.Books = bookDTO;

            return dtoObj; 
        }

        public static AuthorDTO2 Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO2>();
            });

            var mapper = new Mapper(config);

            var dbObj = DataAccessFactory.AuthorDataAccess().Delete(id);

            if (dbObj != null) { return mapper.Map<AuthorDTO2>(dbObj);  }

            return null;
        }

        public static AuthorDTOs Update(AuthorDTOs dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTOs>();
                cfg.CreateMap<AuthorDTOs, Author>();
            });

            var mapper = new Mapper(config);

            var dbObj = DataAccessFactory.AuthorDataAccess().Update(mapper.Map<Author>(dto));

            return mapper.Map<AuthorDTOs>(dbObj);
        }
    }
}
