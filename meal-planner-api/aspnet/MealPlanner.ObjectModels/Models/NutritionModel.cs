using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.ObjectModels.Models
{
  /// <summary>
  /// Represents the _Nutrition_ model (a nutrition facts label)
  /// </summary>
  public class NutritionModel : IValidatableObject
  {
    public int Id { get; set; }
    public int ServingSizeId { get; set; }
    public int AmountPerServingId { get; set; }
    public int UnitPerServingId { get; set; }
    public int CaloriesPerServing { get; set; }
    
    [ForeignKey("ServingSizeId")]
    public AmountModel ServingSize { get; set; }
    [ForeignKey("AmountPerServingId")]
    public AmountModel AmountPerServing { get; set; }
    [ForeignKey("UnitPerServingId")]
    public UnitModel UnitPerServing { get; set; }
    public List<NutrientModel> Nutrients { get; set; }

    /// <summary>
    /// Represents the _Nutrition_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}