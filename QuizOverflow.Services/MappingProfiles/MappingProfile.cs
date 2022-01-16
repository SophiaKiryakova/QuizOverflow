using AutoMapper;
using QuizOverflow.DTO;
using QuizOverflow.Models;

namespace QuizOverflow.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
