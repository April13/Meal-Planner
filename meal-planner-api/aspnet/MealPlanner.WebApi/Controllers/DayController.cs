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
  public class DayController : ControllerBase
  {
    private UnitOfWork _unitOfWork;
    public DayController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        IEnumerable<DayModel> model = await this._unitOfWork.Day.SelectAsync();

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while getting all the Day! {ex.ToString()}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return base.Ok( await this._unitOfWork.Day.SelectAsync(id) );
      }
      catch (Exception ex)
      {
        return base.NotFound($"Day does not exists! {ex.ToString()}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DayModel model)
    {
      // TODO: Validation for day model state
      // if (!ModelState.IsValid)
      //   return BadRequest("Day model is invalid");

      try
      {
        // Day for an account already exists?
        IList<DayModel> existingDayForAccount =
          this._unitOfWork.Day._db
            .Where(m => m.Date.Equals(model.Date) && m.AccountId.Equals(model.AccountId))
            .ToList();
        if (existingDayForAccount != null && existingDayForAccount.Count > 0)
          return base.BadRequest("Day for the account already exists!");

        // Add to database
        await this._unitOfWork.Day.InsertAsync(model);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to create Day!");

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while creating Day! {ex.ToString()}");
      }
    }

    [HttpPut()]
    public async Task<IActionResult> Put([FromBody] DayModel model)
    {
      // TODO: Validation fo day model state
      // if (!ModelState.IsValid)
      //   return BadRequest("Day model is invalid");

      try
      {
        try
        {
          DayModel existingModel = await this._unitOfWork.Day.SelectAsync(model.Id);
        }
        catch
        {
          return base.NotFound("Day does not exists!");
        }

        // Update day in database
        this._unitOfWork.Day.Update(model);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to update Day!");

        return base.Ok();
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while updating Day! {ex.ToString()}");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        try
        {
          DayModel model = await this._unitOfWork.Day.SelectAsync(id);
          // DayModel model = this._unitOfWork.Day._db.Where(m => m.Id == id).FirstOrDefault();
        }
        catch
        {
          return base.BadRequest("Day does not exists!");
        }

        // Delete day from database
        await this._unitOfWork.Day.DeleteAsync(id);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to delete Day!");

        return base.Ok();
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while deleting Day! {ex.ToString()}");
      }
    }
  }
}