using AutoMapper;
using Azure.Core;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BLL.Services
{
    public class PublisherServices
    {
        // returns all publishers with paging 
        public static List<PublisherDTO3> Get(RouteParamsDTO dto)
        {
            var data = DataAccessFactory.PublisherDataAccess().Get().OrderByDescending(x => x.Id).ToList();

            var count = data.Count();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherDTO3>();

            });

            var mapper = new Mapper(config);

            if(dto.search != null)
            {
                data = data.Where(p => p.Name.ToLower().Contains(dto.search.ToLower())).ToList();
            }
            
            data = data.Skip(dto.pageSize * (dto.page - 1)).Take(dto.pageSize).ToList();

            

            var ret = mapper.Map<List<PublisherDTO3>>(data);

            ret.ForEach(val => val.Count = count);

            return ret;
        }


        // returns all publishers
        public static List<PublisherDTO3> GetWithNoPaging()
        {
            var data = DataAccessFactory.PublisherDataAccess().Get();

            var count = data.Count();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherDTO3>();

            });

            var mapper = new Mapper(config);


            var ret = mapper.Map<List<PublisherDTO3>>(data);

            ret.ForEach(val => val.Count = count);

            return ret;
        }

        // save authors
        public static PublisherDTO3 Add(PublisherDTO3 dto)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PublisherDTO3, Publisher>();
                cfg.CreateMap<Publisher, PublisherDTO3>();

            });

            var mapper = new Mapper(config);

            var dbObj = mapper.Map<Publisher>(dto);

            var data = DataAccessFactory.PublisherDataAccess().Add(dbObj);

            return mapper.Map<PublisherDTO3>(data);

        }

        // get author by id
        public static PublisherDTO3 Get(int id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Publisher, PublisherDTO3>(); });

            var mapper = new Mapper(config);

            var dbObj = DataAccessFactory.PublisherDataAccess().Get(id);

            return mapper.Map<Publisher, PublisherDTO3>(dbObj);

        }

        // update author
        public static PublisherDTO3 Update(PublisherDTO3 dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PublisherDTO3, Publisher>();
                cfg.CreateMap<Publisher, PublisherDTO3>();
            });

            var mapper = new Mapper(config);

            var dbObj = mapper.Map<Publisher>(dto);

            var db_obj = DataAccessFactory.PublisherDataAccess().Update(dbObj);

            return mapper.Map<PublisherDTO3>(db_obj);

        }

        // delete an author
        public static PublisherDTO Delete(int Id)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherDTO>();
            });

            var mapper = new Mapper(config);

            var dbObj = DataAccessFactory.PublisherDataAccess().Delete(Id);

            return mapper.Map<PublisherDTO>(dbObj);

        }

        // Get authors by book
        public static PublisherDTO GetBooks(int Id)
        {
            var dbObj = DataAccessFactory.PublisherDataAccessV2().GetAllBooksByPublisherId(Id);

            if (dbObj == null) return null;

            PublisherDTO dto = new PublisherDTO();

            dto.Id = dbObj.Id;

            dto.Name = dbObj.Name;

            dto.Books = dbObj.Books.AsEnumerable().Select(s => new BookDTO3
            {
                Title = s.Title,
                Type = s.Type,
                PublishedDate = s.PublishedDate
                
            }).ToList();

            return dto;

        }
    }
}
