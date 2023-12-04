using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_And_Services.Services.Custom.CustomerServices;
using Repository_And_Services.Services.Custom.SupplierServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _customerService;
        public SupplierController(ISupplierService customerService)
        {
            _customerService = customerService;
        }

        [Route("GetAllSupplier")]
        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var res = await _customerService.GetAll();
            if (res == null)
                return BadRequest("No records found");
            return Ok(res);
        }
        [Route("GetSupplier")]
        [HttpGet]
        public async Task<IActionResult> GetSupplier(int Id)
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
        [Route("InsertSupplier")]
        [HttpPost]
        public async Task<IActionResult> InsertSupplier(InsertSupplier categoryModel)
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
        [Route("UpdateSupplier")]
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplier categoryModel)
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

        [Route("DeleteSupplier")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(int Id)
        {
            var result = await _customerService.Delete(Id);
            if (result == true)
                return Ok("Category Deleted SUccessfully...!");
            else
                return BadRequest("Category is not deleted, Please Try again later...!");
        }
    }
}
