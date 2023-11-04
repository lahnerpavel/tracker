namespace Eshop.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();

        TEntity? FindById(uint id);
        
        //TEntity? GetById(int id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(uint id);

        bool ExistsWithId(uint id);
    }
}