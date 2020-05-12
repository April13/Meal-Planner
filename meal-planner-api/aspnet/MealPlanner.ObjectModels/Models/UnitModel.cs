using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Rental_ model
  /// </summary>
  public class UnitModel : IValidatableObject
  {
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Represents the _Unit_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}