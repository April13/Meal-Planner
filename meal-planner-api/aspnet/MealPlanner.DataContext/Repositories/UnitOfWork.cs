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

    public virtual Repository<FoodModel> Food { get; }
    // public virtual Repository<NutritionModel> Nutrition { get; set; }
    // public virtual Repository<NutrientModel> Nutrient { get; set; }
    // public virtual Repository<AmountModel> Amount { get; set; }
    public virtual Repository<UnitModel> Unit { get; set; }
    public virtual Repository<DayModel> Day { get; set; }
    // public virtual Repository<EatModel> Eat { get; set; }

    public UnitOfWork(MealPlannerContext context)
    {
      _context = context;

      Food = new Repository<FoodModel>(context);
      // Nutrition = new Repository<NutritionModel>(context);
      // Nutrient = new Repository<NutrientModel>(context);
      // Amount = new Repository<AmountModel>(context);
      Unit = new Repository<UnitModel>(context);
      Day = new Repository<DayModel>(context);
      // Eat = new Repository<EatModel>(context);
    }

    /// <summary>
    /// Represents the _UnitOfWork_ `Commit` method
    /// </summary>
    /// <returns></returns>
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
  }
}