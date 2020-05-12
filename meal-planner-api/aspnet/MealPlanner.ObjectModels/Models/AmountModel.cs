using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Rental_ model
  /// </summary>
  public class AmountModel : IValidatableObject
  {
    public int Id { get; set; }
    public int WholeNumber { get; set; }
    public int Numerator { get; set; }
    public int Denominator { get; set; }


    /// <summary>
    /// Represents the _Nutrient_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}