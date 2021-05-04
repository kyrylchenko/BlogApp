using AutoMapper;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HashTagService
    {
        public IRepository<DAL.Context.HashTag> repository;
        public IMapper mapper;
        public HashTagService()
        {
            this.repository = new HashTagRepository(new BlogContext());
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<DAL.Context.User, DTO.UserDTO>();
                x.CreateMap<DTO.UserDTO, DAL.Context.User>();
                x.CreateMap<DAL.Context.HashTag, DTO.HashTagDTO>();
                x.CreateMap<DTO.HashTagDTO, DAL.Context.HashTag>();
                x.CreateMap<DAL.Context.Article, DTO.ArticleDTO>();
                x.CreateMap<DTO.ArticleDTO, DAL.Context.Article>();
            });
            mapper = new Mapper(configuration);
        }
        public IEnumerable<DTO.HashTagDTO> GetAll()
        {
           
              return mapper.Map<IEnumerable<DAL.Context.HashTag>, IEnumerable<DTO.HashTagDTO>>(repository.GetAll());
         
        }

        public DTO.HashTagDTO Get(int id)
        {
           
                DAL.Context.HashTag entity = repository.Get(id);
                return mapper.Map<DAL.Context.HashTag, DTO.HashTagDTO>(entity);
          
        }

        public DTO.HashTagDTO Delete(DTO.HashTagDTO item)
        {
            DAL.Context.HashTag entity = repository.Get(item.HashTagId);
            repository.Delete(entity);
            repository.SaveChanges();
            return item;
        }
        public void CreateOrUpdate(DTO.HashTagDTO item)
        {
            DAL.Context.HashTag entity = mapper.Map<DTO.HashTagDTO, DAL.Context.HashTag>(item);
            repository.CreateOrUpdate(entity);
            repository.SaveChanges();
        }
    }
}
