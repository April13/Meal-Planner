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
  public class AccountController : ControllerBase
  {
    private UnitOfWork _unitOfWork;
    public AccountController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        IEnumerable<AccountModel> model = await this._unitOfWork.Account.SelectAsync();

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while getting all the Account! {ex.ToString()}");
      }
    }

    [HttpGet("verify/{email}/{password}")]
    public async Task<IActionResult> VerifyAccount(string email, string password)
    {
      AccountModel model = new AccountModel(){ Email = email, Password = password};
      // TODO: Validation for account model state
      // if (!ModelState.IsValid)
      //   return BadRequest("Account model is invalid");
      try
      {
        IEnumerable<AccountModel> accounts = await this._unitOfWork.Account.SelectAsync();
        AccountModel account = accounts.FirstOrDefault( m => m.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase) && m.Password.Equals(model.Password) );
        if (account == null)
          return base.NotFound("Incorrect Login or Account doesn't exist!");

        return base.Ok(account);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while verifying login for Account! {ex.ToString()}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return base.Ok( await this._unitOfWork.Account.SelectAsync(id) );
      }
      catch (Exception ex)
      {
        return base.NotFound($"Account does not exists! {ex.ToString()}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AccountModel model)
    {
      // TODO: Validation for account model state
      // if (!ModelState.IsValid)
      //   return BadRequest("Account model is invalid");

      try
      {
        // Email for an account already exists?
        IList<AccountModel> existingEmailForAccount =
          this._unitOfWork.Account._db
            .Where(m => m.Email.Equals(model.Email))
            .ToList();
        if (existingEmailForAccount != null && existingEmailForAccount.Count > 0)
          return base.BadRequest("Email is already being used for an existing account!");
        

        // Add to database
        await this._unitOfWork.Account.InsertAsync(model);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to create Account!");

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while creating Account! {ex.ToString()}");
      }
    }

    [HttpPut()]
    public async Task<IActionResult> Put([FromBody] AccountModel model)
    {
      // TODO: Validation fo account model state
      // if (!ModelState.IsValid)
      //   return BadRequest("Account model is invalid");

      try
      {
        try
        {
          AccountModel existingModel = await this._unitOfWork.Account.SelectAsync(model.Id);
        }
        catch
        {
          return base.NotFound("Account does not exists!");
        }

        // Update account in database
        this._unitOfWork.Account.Update(model);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to update Account!");

        return base.Ok();
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while updating Account! {ex.ToString()}");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        try
        {
          AccountModel model = await this._unitOfWork.Account.SelectAsync(id);
          // AccountModel model = this._unitOfWork.Account._db.Where(m => m.Id == id).FirstOrDefault();
        }
        catch
        {
          return base.BadRequest("Account does not exists!");
        }

        // Delete account from database
        await this._unitOfWork.Account.DeleteAsync(id);
        int rows = await this._unitOfWork.CommitAsync();
        if (rows != 1)
          return base.BadRequest("Failed to delete Account!");

        return base.Ok();
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while deleting Account! {ex.ToString()}");
      }
    }
    
  }
}