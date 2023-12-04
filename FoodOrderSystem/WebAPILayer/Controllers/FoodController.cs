using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_And_Services.Services.Custom.CustomerServices;
using Repository_And_Services.Services.Custom.FoodServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _customerService;
        public FoodController(IFoodService customerService)
        {
            _customerService = customerService;
        }

        [Route("GetAllFood")]
        [HttpGet]
        public async Task<IActionResult> GetAllFood()
        {
            var res = await _customerService.GetAll();
            if (res == null)
                return BadRequest("No records found");
            return Ok(res);
        }
        [Route("GetFood")]
        [HttpGet]
        public async Task<IActionResult> GetFood(int Id)
        {
            if (Id != null)
            {
                var result = await _customerService.GetById(Id);
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            else
                return NotFound("Invalid Category Id, Please Entering a Valid One...!");

        }
        [Route("InsertFood")]
        [HttpPost]
        public async Task<IActionResult> InsertFood(InserFood categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerService.Insert(categoryModel);
                if (result == true)
                    return Ok("Category Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");

        }
        [Route("UpdateFood")]
        [HttpPut]
        public async Task<IActionResult> UpdateFood(UpdateFood categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerService.Update(categoryModel);
                if (result == true)
                    return Ok(categoryModel);
                else
                    return BadRequest("Something Went Wrong, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
        }

        [Route("DeleteFood")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFood(int Id)
        {
            var result = await _customerService.Delete(Id);
            if (result == true)
                return Ok("Category Deleted SUccessfully...!");
            else
                return BadRequest("Category is not deleted, Please Try again later...!");
        }
    }
}
