using System.Linq.Expressions;

namespace ReletionshipRepstryType.WebApp.Services;

public interface IRepositoryService<TEntity, IModel>where TEntity : class ,new () where IModel : class
{
    Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellation);
    Task<IModel> InsertAsync(IModel model, CancellationToken cancellation);
    Task<IModel> UpdateAsync(long id ,IModel model, CancellationToken cancellation);
    Task<IModel> DeleteAsync(long id , CancellationToken cancellation);
    Task<IModel> GetByIdAsync(long id , CancellationToken cancellation);
   Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
}
