using Microsoft.EntityFrameworkCore;
using QuizOverflow.Data.Contracts;
using QuizOverflow.Services.Contracts;

namespace QuizOverflow.Services.Services
{
    public class SeedService: ISeedService
    {
        private IUnitOfWork _unitOfWork;

        public SeedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}
