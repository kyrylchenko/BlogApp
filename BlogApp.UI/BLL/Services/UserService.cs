using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Context;
using DAL.Repositories;

namespace BLL.Services
{
    public class UserService
    {
       public  IRepository<DAL.Context.User> repository;
        public IMapper mapper;
        public UserService()
        {
            
            this.repository = new UserRepository(new BlogContext());
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
               
                x.CreateMap<DAL.Context.HashTag, DTO.HashTagDTO>();
                x.CreateMap<DTO.HashTagDTO, DAL.Context.HashTag>();
                x.CreateMap<DTO.ArticleDTO, DAL.Context.Article>();
                x.CreateMap<DAL.Context.Article,DTO.ArticleDTO>();
                x.CreateMap<DAL.Context.User, DTO.UserDTO>();
                x.CreateMap<DTO.UserDTO, DAL.Context.User>();
                x.CreateMap<User, User>();
            });
            mapper = new Mapper(configuration);
            
        }
        public IEnumerable<DTO.UserDTO> GetAll()
        {        
                return mapper.Map<IEnumerable<DAL.Context.User>, IEnumerable<DTO.UserDTO>>(repository.GetAll());                     
        }

        public DTO.UserDTO Get(int id)
        {
                DAL.Context.User entity = repository.Get(id);
                return mapper.Map<DAL.Context.User, DTO.UserDTO>(entity);         
        }

        public DTO.UserDTO Delete(DTO.UserDTO item)
        {
            DAL.Context.User entity = repository.Get(item.UserId);
            repository.Delete(entity);
            repository.SaveChanges();
            return item;
        }
        public void CreateOrUpdate(DTO.UserDTO item)
        {
            DAL.Context.User entity = mapper.Map<DTO.UserDTO, DAL.Context.User>(item);
            //if (repository.GetAll().FirstOrDefault(u => u.UserId == entity.UserId) == null)
                repository.CreateOrUpdate(entity);
            //else
            //{
            //    IEnumerable<User> users = repository.GetAll().ToList();
            //   User user =  users.FirstOrDefault(u => u.UserId == entity.UserId);               
            //    mapper.Map<User, User>(entity, user);
            //    repository.SaveChanges();             
            //        }
            repository.SaveChanges();
        }
    }
}
