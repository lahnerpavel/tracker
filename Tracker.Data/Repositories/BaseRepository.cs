using Eshop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Tracker.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TrackerDbContext trackerDbContext;
        protected readonly DbSet<TEntity> dbSet;


        public BaseRepository(TrackerDbContext trackerDbContext)
        {
            this.trackerDbContext = trackerDbContext;
            dbSet = trackerDbContext.Set<TEntity>();
        }


        public TEntity? FindById(uint id)
        {
            return dbSet.Find(id);
        }

        /*public TEntity? GetById(uint id)
        {
            return dbSet.Find(id);
        }*/

        public bool ExistsWithId(uint id)
        {
            TEntity? entity = dbSet.Find(id);
            // Abychom se vyhnuli problémům se sledováním více entit se stejným ID
            if (entity is not null)
                trackerDbContext.Entry(entity).State = EntityState.Detached;
            return entity is not null;
        }

        public IList<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = dbSet.Add(entity);
            trackerDbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = dbSet.Update(entity);
            trackerDbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(uint id)
        {
            TEntity? entity = dbSet.Find(id);

            if (entity is null)
                return;

            try
            {
                dbSet.Remove(entity);
                trackerDbContext.SaveChanges();
            }
            catch
            {
                trackerDbContext.Entry(entity).State = EntityState.Unchanged;
                throw;
            }
        }
    }
}