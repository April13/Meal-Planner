using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Food_ model (a food item)
  /// </summary>
  public class FoodModel : IValidatableObject, IModel
  {
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; }

    // public int NutritionId { get; set; }

    // [ForeignKey("NutritionId")]
    public NutritionModel Nutrition { get; set; }

    /// <summary>
    /// Represents the _Food_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}