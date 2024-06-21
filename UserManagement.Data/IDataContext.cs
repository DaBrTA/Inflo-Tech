using System.Linq;

namespace UserManagement.Data;

public interface IDataContext
{

    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    TEntity? GetSingle<TEntity>(int Id) where TEntity : class;

    TEntity Create<TEntity>(TEntity entity) where TEntity : class;

    void Edit<TEntity>(TEntity entity) where TEntity : class;

    void Delete<TEntity>(TEntity entity) where TEntity : class;
}
