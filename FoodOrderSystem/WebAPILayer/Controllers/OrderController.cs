using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_And_Services.Services.Custom.FoodServices;
using Repository_And_Services.Services.Custom.OrderServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _customerService;
        public OrderController(IOrderService customerService)
        {
            _customerService = customerService;
        }

        [Route("GetAllOrder")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var res = await _customerService.GetAll();
            if (res == null)
                return BadRequest("No records found");
            return Ok(res);
        }
        [Route("GetOrder")]
        [HttpGet]
        public async Task<IActionResult> GetOrder(int Id)
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
        [Route("InsertOrder")]
        [HttpPost]
        public async Task<IActionResult> InsertOrder(InsertOrder categoryModel)
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
        [Route("UpdateOrder")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrder categoryModel)
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

        [Route("DeleteOrder")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var result = await _customerService.Delete(Id);
            if (result == true)
                return Ok("Category Deleted SUccessfully...!");
            else
                return BadRequest("Category is not deleted, Please Try again later...!");
        }
    }
}
