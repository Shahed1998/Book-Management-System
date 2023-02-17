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
    public class BookAuthorMapServices
    {
        public static BookAuthorMapDTOs Add(BookAuthorMapDTOs dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookAuthorMapDTOs, BookAuthorMap>();
                cfg.CreateMap<BookAuthorMap, BookAuthorMapDTOs>();
            });

            var mapper = new Mapper(config);

            var dbObject = mapper.Map<BookAuthorMap>(dto);

            var dbObj = DataAccessFactory.BookAuthorMapDataAccess().Add(dbObject);

            return mapper.Map<BookAuthorMapDTOs>(dbObj);
        }

        public static bool Delete(int authorId, int bookId)
        {
            return DataAccessFactory.BookAuthorMapDataAccessV2().Delete(authorId, bookId);
        }
    }
}
