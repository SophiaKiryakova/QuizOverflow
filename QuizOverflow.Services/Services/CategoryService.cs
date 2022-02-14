using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizOverflow.Data.Contracts;
using QuizOverflow.DTO;
using QuizOverflow.Models;

namespace QuizOverflow.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.Get().ToListAsync();
            var categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories);

            return categoryDtos;
        }
    }
}
