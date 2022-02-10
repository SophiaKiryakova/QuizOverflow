using QuizOverflow.DTO;

namespace QuizOverflow.Data.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();
    }
}
