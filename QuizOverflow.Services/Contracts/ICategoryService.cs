using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOverflow.Data.Contracts
{
    public interface ICategoryService
    {
        public async Task<List<CategoryDto>> GetCategories();
    }
}
