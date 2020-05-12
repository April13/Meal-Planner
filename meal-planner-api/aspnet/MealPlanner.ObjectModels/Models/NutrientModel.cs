using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Rental_ model
  /// </summary>
  public class NutrientModel : IValidatableObject
  {
    public int Id { get; set; }
    public int NutritionId { get; set; }
    public string Name { get; set; }
    public int DailyValuePercentage { get; set; }
    public int AmountId { get; set; }
    public int UnitId { get; set; }
    
    [ForeignKey("AmountId")]
    public AmountModel Amount { get; set; }
    [ForeignKey("UnitId")]
    public UnitModel Unit { get; set; }

    /// <summary>
    /// Represents the _Nutrient_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}