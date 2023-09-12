using BuberDinner.Domain.Models;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : ValueObject
    {
        protected readonly ApplicationDbContext Context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity menu)
        {
            Context.Add(menu);
            Context.SaveChanges();
        }

        public virtual TEntity? GetById(TId id)
        {
            return Context.Set<TEntity>().SingleOrDefault(entity => entity.Id == id);
        }
    }
}