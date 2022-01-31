using AutoMapper;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using QuizOverflow.Data.Contracts;
using QuizOverflow.Models;
using QuizOverflow.Services.Contracts;
using QuizOverflow.Services.Services;

namespace QuizOverflow.BusinessLayer.Tests
{
    [TestFixture]
    public class SeedServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        private ISeedService _seedService;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();

            _seedService = new SeedService(_unitOfWork.Object, _mapper.Object);
        }

        [Test]
        public async Task SeedCategories_ShouldNotSeedCategoriesIfDbAlreadyContainsSome()
        {
            var mockQuery = new List<Category>() { new Category { Id = 1, Name = "Chemistry" } }
                .AsQueryable()
                .BuildMock();

            var sqlQuery = "test string query";

            _unitOfWork.Setup(uow => uow.CategoryRepository.Get()).Returns(mockQuery.Object);
            _unitOfWork.Setup(uow => uow.CategoryRepository.ExecuteRawScript(sqlQuery)).Verifiable();

            await _seedService.SeedCategories();

            _unitOfWork.Verify(uow => uow.CategoryRepository.ExecuteRawScript(sqlQuery), Times.Never());
        }

        [Test]
        public async Task SeedCategories_ShouldSeedCategoriesIfDbDoesNotContainAny()
        {
            var mockQuery = new List<Category>()
                .AsQueryable()
                .BuildMock();

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

            _unitOfWork.Setup(uow => uow.CategoryRepository.Get()).Returns(mockQuery.Object);
            _unitOfWork.Setup(uow => uow.CategoryRepository.ExecuteRawScript(sqlQuery)).Verifiable();

            await _seedService.SeedCategories();

            _unitOfWork.Verify(uow => uow.CategoryRepository.ExecuteRawScript(sqlQuery), Times.Once());
        }
    }
}
