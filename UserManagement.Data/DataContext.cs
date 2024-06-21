using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
    IConfiguration appConfig;

    public DataContext(IConfiguration config)
    {
        appConfig = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(appConfig.GetConnectionString("LocalConnection"));
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Log> Logs { get; set; }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public TEntity? GetSingle<TEntity>(int Id) where TEntity : class
        => base.Set<TEntity>().Find(Id);


    public TEntity Create<TEntity>(TEntity entity) where TEntity : class
    {
        base.Add<TEntity>(entity);
        base.SaveChanges();
        return entity;
    }

    public void Edit<TEntity>(TEntity entity) where TEntity : class
    {

        base.Update<TEntity>(entity);
        base.SaveChanges();

    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        base.Remove<TEntity>(entity);
        base.SaveChanges();

    }



}
