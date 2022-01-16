using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizOverflow.Data.Contracts;
using QuizOverflow.DTO;
using QuizOverflow.Models;
using QuizOverflow.Services.Contracts;
using System.Text.Json;

namespace QuizOverflow.Services.Services
{
    public class SeedService: ISeedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeedService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SeedCategories()
        {
            var areAnyCategoriesInDb = await _unitOfWork.CategoryRepository.Get().AnyAsync();

            if (!areAnyCategoriesInDb)
            {
                var sqlQuery = @" SET IDENTITY_INSERT [dbo].[Categories] ON 
                 INSERT [dbo].[Categories] ([Id], [Name], [CreatedOn], [ModifiedOn], [IsDeleted], [DeletedOn]) 
                 VALUES (1, 'Chemistry', GETDATE(), GETDATE(),0, GETDATE())
                 INSERT [dbo].[Categories] ([Id], [Name], [CreatedOn], [ModifiedOn], [IsDeleted], DeletedOn) 
                 VALUES (2, 'Biology', GETDATE(), GETDATE(),0, GETDATE())
                 INSERT [dbo].[Categories] ([Id], [Name], [CreatedOn], [ModifiedOn], [IsDeleted], DeletedOn) 
                 VALUES (3, 'Physics', GETDATE(), GETDATE(),0, GETDATE())
                 INSERT [dbo].[Categories] ([Id], [Name], [CreatedOn], [ModifiedOn], [IsDeleted], DeletedOn) 
                 VALUES (4, 'Literature', GETDATE(), GETDATE(),0, GETDATE())
                 INSERT [dbo].[Categories] ([Id], [Name], [CreatedOn], [ModifiedOn], [IsDeleted], DeletedOn) 
                 VALUES (5, 'History', GETDATE(), GETDATE(),0, GETDATE())
                 INSERT [dbo].[Categories] ([Id], [Name], [CreatedOn], [ModifiedOn], [IsDeleted], DeletedOn) 
                 VALUES (6, 'Geography', GETDATE(), GETDATE(),0, GETDATE())
                 SET IDENTITY_INSERT [dbo].[Categories] OFF";

                _unitOfWork.CategoryRepository.ExecuteRawScript(sqlQuery);
            }
        }

        public async Task SeedQuestions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var text = File.ReadAllText(@"D:\Coding\Projects\Goshi\QuizOverflow\QuizOverflow.Data\JSON\QOJSON.json");

            var questionDtos = JsonSerializer.Deserialize<List<QuestionDto>>(text, options);
            var questionEntities = _mapper.Map<List<QuestionDto>, List<Question>>(questionDtos);
            
            _unitOfWork.QuestionRepository.CreateRange(questionEntities);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
