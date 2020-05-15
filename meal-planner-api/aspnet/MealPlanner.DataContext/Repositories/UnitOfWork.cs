using System.Threading.Tasks;
using MealPlanner.ObjectModels.Models;

namespace MealPlanner.DataContext.Repositories
{
  /// <summary>
  /// Represents the _UnitOfWork_ repository
  /// </summary>
  public class UnitOfWork
  {
    private readonly MealPlannerContext _context;
    public virtual Repository<AccountModel> Account { get; set; }
    public virtual Repository<FoodModel> Food { get; }
    public virtual Repository<UnitModel> Unit { get; set; }
    public virtual Repository<DayModel> Day { get; set; }
    public virtual Repository<NutrientTypeModel> NutrientType { get; set; }

    public UnitOfWork(MealPlannerContext context)
    {
      _context = context;
      Account = new Repository<AccountModel>(context);
      Food = new Repository<FoodModel>(context);
      Unit = new Repository<UnitModel>(context);
      Day = new Repository<DayModel>(context);
      NutrientType = new Repository<NutrientTypeModel>(context);
    }

    /// <summary>
    /// Represents the _UnitOfWork_ `Commit` method
    /// </summary>
    /// <returns></returns>
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
  }
}