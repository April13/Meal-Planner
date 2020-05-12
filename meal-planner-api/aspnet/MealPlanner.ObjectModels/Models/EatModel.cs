using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Eat_ model (serving(s) eaten of a food item)
  /// </summary>
  public class EatModel : IValidatableObject
  {
    public int Id { get; set; }

    public int DayId { get; set; }
    public int ServingsId { get; set; }

    [ForeignKey("ServingsId")]
    public AmountModel Servings { get; set; }

    public int FoodId { get; set; }

    [ForeignKey("FoodId")]
    public FoodModel Food { get; set; }

    /// <summary>
    /// Represents the _Eat_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}