using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _ServingSize_ model (serving size on nutrition facts label)
  /// </summary>
  public class ServingSizeModel : IValidatableObject//, IModel
  {
    public int UnitPerServingId { get; set; }
    public AmountModel ServingSize { get; set; }
    // [ForeignKey("UnitPerServingId")]
    // public UnitModel UnitOfServingSize { get; set; }


    /// <summary>
    /// Represents the _ServingSize_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}