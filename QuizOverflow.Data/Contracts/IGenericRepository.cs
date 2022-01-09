using QuizOverflow.Models.Abstracts;
using System.Linq.Expressions;

namespace QuizOverflow.Data.Contracts
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IQueryable<T> Get();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void CreateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
