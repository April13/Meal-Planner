using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MealPlanner.DataContext.Repositories;
using MealPlanner.ObjectModels.Models;
using System;
using System.Threading.Tasks;

namespace MealPlanner.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class FoodController : ControllerBase
  {
    private UnitOfWork _unitOfWork;
    public FoodController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        IEnumerable<FoodModel> model = await this._unitOfWork.Food.SelectAsync();

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while getting all the Food! {ex.ToString()}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return base.Ok( await this._unitOfWork.Food.SelectAsync(id) );
      }
      catch (Exception ex)
      {
        return base.NotFound($"Food does not exists! {ex.ToString()}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FoodModel model)
    {
      // Validating Food Name as it is required
      // TODO: model state validation
      // if (!ModelState.IsValid)
      //   return BadRequest("Food model is invalid");
      if (string.IsNullOrWhiteSpace(model.Name))
        return base.BadRequest("Food Name is required!");

      try
      {
        // Food name already exists?
        IList<FoodModel> existingNames =
          this._unitOfWork.Food._db
            .Where(m => m.Name == model.Name)
            .ToList();
        if (existingNames != null && existingNames.Count > 0)
          return base.BadRequest("Food already exists!");

        // Add to database
        await this._unitOfWork.Food.InsertAsync(model);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to create Food!");

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while creating Food! {ex.ToString()}");
      }
    }

    [HttpPut()]
    public async Task<IActionResult> Put([FromBody] FoodModel model)
    {
      // Validating Employee Name as it is required
      // TODO: model state validation
      // if (!ModelState.IsValid)
      //   return BadRequest("Food model is invalid");
      if (string.IsNullOrWhiteSpace(model.Name))
        return base.BadRequest("Food Name is required!");

      try
      {
        try
        {
          FoodModel existingModel = await this._unitOfWork.Food.SelectAsync(model.Id);
        }
        catch
        {
          return base.NotFound("Food does not exists!");
        }

        // Update food in database
        this._unitOfWork.Food.Update(model);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to update Food!");

        return base.Ok();
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while updating Food! {ex.ToString()}");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        try
        {
          FoodModel model = await this._unitOfWork.Food.SelectAsync(id);
          // FoodModel model = this._unitOfWork.Food._db.Where(m => m.Id == id).FirstOrDefault();
        }
        catch
        {
          return base.BadRequest("Food does not exists!");
        }

        // Delete food from database
        await this._unitOfWork.Food.DeleteAsync(id);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to delete Food!");

        return base.Ok();
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while deleting Food! {ex.ToString()}");
      }
    }
  }
}