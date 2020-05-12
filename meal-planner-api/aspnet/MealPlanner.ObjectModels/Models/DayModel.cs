using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Day_ model (what is eaten in a day)
  /// </summary>
  public class DayModel : IValidatableObject
  {
    public int Id { get; set; }

    public int AccountId { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public List<EatModel> Eats { get; set; }

    /// <summary>
    /// Represents the _Day_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}