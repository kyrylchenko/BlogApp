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
    public class ArticleService
    {
        public IRepository<DAL.Context.Article> repository;
        public IMapper mapper;
        public ArticleService()
        {
            this.repository = new ArticleRepository(new BlogContext());
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
              
                x.CreateMap<DAL.Context.User, DTO.UserDTO>();
                x.CreateMap<DTO.UserDTO, DAL.Context.User>();
                x.CreateMap<DAL.Context.HashTag, DTO.HashTagDTO>();
                x.CreateMap<DTO.HashTagDTO, DAL.Context.HashTag>();
                x.CreateMap<DAL.Context.Article, DTO.ArticleDTO>()
                .ForMember((u) => u.CountLikes, m => m.MapFrom(s => s.UsersWhoLiked.Count))
                 .ForMember((u) => u.CountUsersWhoAddedToFavorite, m => m.MapFrom(s => s.UsersWhoAdedToFavorite.Count))
                  .ForMember((u) => u.CountViews, m => m.MapFrom(s => s.UsersWhoViewed.Count))
                   .ForMember((u) => u.CreatorName, m => m.MapFrom(s => s.User.Name));


                x.CreateMap<DTO.ArticleDTO, DAL.Context.Article>();
            });
            mapper = new Mapper(configuration);
        }
        public IEnumerable<DTO.ArticleDTO> GetAll()
        {
           
                return mapper.Map<IEnumerable<DAL.Context.Article>, IEnumerable<DTO.ArticleDTO>>(repository.GetAll());
          
        }

        public DTO.ArticleDTO Get(int id)
        {
           
                DAL.Context.Article entity = repository.Get(id);
                return mapper.Map<DAL.Context.Article, DTO.ArticleDTO>(entity);
           
        }

        public DTO.ArticleDTO Delete(DTO.ArticleDTO item)
        {
            DAL.Context.Article entity = repository.Get(item.ArticleId);
            repository.Delete(entity);
            repository.SaveChanges();
            return item;
        }
        public void CreateOrUpdate(DTO.ArticleDTO item)
        {
            DAL.Context.Article entity = mapper.Map<DTO.ArticleDTO, DAL.Context.Article>(item);
            repository.CreateOrUpdate(entity);
            repository.SaveChanges();
        }
    }
}
