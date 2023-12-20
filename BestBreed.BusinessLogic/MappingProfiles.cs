using AutoMapper;
using BestBreed.BusinessLogic.DtoModels;
using BestBreed.DataLayer.Entities;

namespace BestBreed.BusinessLogic
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cat, CatDto>();
            CreateMap<Like, LikeDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<SurveyResult, SurveyResultDto>();
        }
    }
}