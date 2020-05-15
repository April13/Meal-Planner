using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Nutrition_ model (a nutrition facts label)
  /// </summary>
  public class NutritionModel : IValidatableObject//, IModel
  {
    public int CaloriesPerServing { get; set; }
    
    public decimal ServingsPerContainer { get; set; }
    
    public List<ServingSizeModel> ServingSizes { get; set; }

    public List<NutrientModel> Nutrients { get; set; }

    /// <summary>
    /// Represents the _Nutrition_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}