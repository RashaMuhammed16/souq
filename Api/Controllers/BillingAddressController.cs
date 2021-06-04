using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingAddressController : ControllerBase
    {
       BillingAddressAppService _billingAppService;
        public BillingAddressController(BillingAddressAppService billingAppService)
        {
            this._billingAppService = billingAppService;
            ;
        }
        [HttpGet]
        public IActionResult GetAllBillingAddress()
        {
            return Ok(_billingAppService.GetAllBillingAddress());
        }
        [HttpGet("{id}")]
        public IActionResult GetBillingAddressById(int id)
        {
            return Ok(_billingAppService.GetBillingAddress(id));
        }
        [HttpPost]
        public IActionResult Create(BillingAddressModelView billingViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _billingAppService.SaveNewBillingAddress(billingViewModel);

                //string urlDetails = Url.Link("DefaultApi", new { id = categoryViewModel.ID });
                //return Created(urlDetails, "Added Sucess");
                return Created("CreateBillingAddress", billingViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, BillingAddressModelView billingViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _billingAppService.UpdatBilling(billingViewModel);
                return Ok(billingViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _billingAppService.DeleteBillingAddress(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}