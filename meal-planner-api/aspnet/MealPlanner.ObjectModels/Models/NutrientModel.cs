using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Nutrient_ model (a nutrient on nutrition facts label)
  /// </summary>
  public class NutrientModel : IValidatableObject//, IModel
  {
    public int NutrientTypeId { get; set; }
    
    public int? DailyValuePercentage { get; set; }

    public AmountModel Amount { get; set; }


    /// <summary>
    /// Represents the _Nutrient_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}