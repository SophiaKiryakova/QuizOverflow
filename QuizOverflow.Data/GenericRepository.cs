using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuizOverflow.Data.Contracts;
using QuizOverflow.Models.Abstracts;
using System.Linq.Expressions;

namespace QuizOverflow.Data
{
    public class GenericRepository<T>: IGenericRepository<T> where T : EntityBase
    {
        private readonly IQuizOverflowDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(IQuizOverflowDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(
                    "An instance of QuizOverflowDbContext is required to use this repository.");
            }

            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Creates a query for taking elements which have not been flagged as deleted.
        /// </summary>
        public IQueryable<T> Get()
        {
            return _dbSet.Where(e => !e.IsDeleted).AsQueryable();
        }

        /// <summary>
        /// Creates a query with a given expression for additional filtering or for getting related
        /// entities through the navigational properties.
        /// </summary>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        /// <summary>
        /// Prepares the entity to be created with initial CreatedOn, ModifiedOn, IsDeleted properties.
        /// </summary>
        public void Create(T entity)
        {
            CheckIfEntityIsNull(entity);

            EntityEntry entry = _context.Entry(entity);

            entity.CreatedOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            entity.DeletedOn = null;
            entity.IsDeleted = false;

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
            }
        }

        /// <summary>
        /// Prepares a collection of entities to be created with initial CreatedOn, ModifiedOn, IsDeleted properties.
        /// </summary>
        public void CreateRange(IEnumerable<T> entities)
        {
            foreach(T entity in entities)
            {
                Create(entity);
            }
        }

        /// <summary>
        /// Marks an entity as deleted, changes the IsDeleted flag and adds DeletedOn.
        /// </summary>
        public void Delete(T entity)
        {
            CheckIfEntityIsNull(entity);

            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;

            var entry = _context.Entry(entity);

            if (entry.State != EntityState.Modified)
            {
                entry.State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Marks a collection of entities as deleted, changes the IsDeleted flag and adds DeletedOn.
        /// </summary>
        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Delete(entity);
            }
        }

        /// <summary>
        /// Marks an entity as updated and changes the ModifiedOn property.
        /// </summary>
        public void Update(T entity)
        {
            CheckIfEntityIsNull(entity);

            var entry = _context.Entry(entity);

            entity.ModifiedOn = DateTime.Now;

            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Marks a collection of entities as updated and changes the ModifiedOn property.
        /// </summary>
        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach(T entity in entities)
            {
                Update(entity);
            }
        }

        public void ExecuteRawScript(string sqlQuery)
        {
            _context.Database.ExecuteSqlRaw(sqlQuery);
        }

        private void CheckIfEntityIsNull(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }
        }
    }
}
