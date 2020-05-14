using System.Collections.Generic;
using System.Threading.Tasks;
using MealPlanner.ObjectModels;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.DataContext.Repositories
{
  /// <summary>
  /// Represents the _Repository_ generic
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public class Repository<TEntity> where TEntity : class, IModel
  {
    public readonly DbSet<TEntity> _db;

    public Repository(MealPlannerContext context)
    {
      _db = context.Set<TEntity>();
    }

    public virtual async Task DeleteAsync(int id) => _db.Remove(await SelectAsync(id));

    public virtual async Task InsertAsync(TEntity entry)
    {
      entry.Id = await GenerateId();
      await _db.AddAsync(entry).ConfigureAwait(true);
    }

    public virtual async Task<IEnumerable<TEntity>> SelectAsync() => await _db.ToListAsync();

    public virtual async Task<TEntity> SelectAsync(int id) => await _db.FindAsync(id).ConfigureAwait(true);

    public virtual void Update(TEntity entry) => _db.Update(entry);

    private async Task<int> GenerateId()
    {
      var any = await _db.FirstOrDefaultAsync();
      if (any == null || any.Id < 1001)
        return 1001;
      else       
      {
        int maxId = await _db.MaxAsync(e => e.Id);
        return maxId + 1;
      }
    }
  }
}