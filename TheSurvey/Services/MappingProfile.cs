using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();

            CreateMap<Survey, SurveyDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<Variant, VariantDto>();
            CreateMap<Answer, AnswerDto>();
            //CreateMap<RegisterRequest, User>()
            //    .ForMember(u => u.HashPassword, opt => opt.MapFrom(r => PasswordHasher.GetHash(r.Password)));
        }
    }
}
