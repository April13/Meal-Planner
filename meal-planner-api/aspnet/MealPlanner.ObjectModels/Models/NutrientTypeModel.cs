using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Nutrient_ model (a nutrient on nutrition facts label)
  /// </summary>
  public class NutrientTypeModel : IValidatableObject, IModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitId { get; set; }

    /// <summary>
    /// Represents the _NutrientType_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}