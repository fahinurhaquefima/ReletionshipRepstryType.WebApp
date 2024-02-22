using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReletionshipRepstryType.WebApp.DatabaseContext;
using System.Linq.Expressions;

namespace ReletionshipRepstryType.WebApp.Services;

public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel>
    where TEntity : class, new() where IModel : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext dbContext;

    public RepositoryService(IMapper mapper , ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        _mapper = mapper;
        DbSet= dbContext.Set<TEntity>();
    }
    public DbSet<TEntity> DbSet { get; }

    public async Task<IModel> DeleteAsync(long id, CancellationToken cancellation)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        DbSet.Remove(entity);
        await dbContext.SaveChangesAsync(cancellation);

        var deletedModel = _mapper.Map<TEntity, IModel>(entity);
        return deletedModel;
    }


    public async Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = await includes.Aggregate(
            dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include))
            .ToListAsync().ConfigureAwait(true);

        return _mapper.Map<List<IModel>>(entities);
    }
    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellation)
    {
        var entities = await DbSet.ToListAsync(cancellation);
        if (entities == null) return null;
        var data = _mapper.Map<IEnumerable<IModel>>(entities);
        return data;
    }

    public async Task<IModel> GetByIdAsync(long id, CancellationToken cancellation)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        var model = _mapper.Map<TEntity, IModel>(entity);
        return model;
    }

    public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellation)
    {
        var entity = _mapper.Map<IModel, TEntity>(model);
        DbSet.Add(entity);
        await dbContext.SaveChangesAsync(cancellation);
        var insertedModel = _mapper.Map<TEntity, IModel>(entity);
        return insertedModel;
    }
    public async Task<IModel> UpdateAsync(long id, IModel model, CancellationToken cancellation)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        _mapper.Map(model, entity);

        await dbContext.SaveChangesAsync(cancellation);

        var updatedModel = _mapper.Map<TEntity, IModel>(entity);
        return updatedModel;
    }
}
