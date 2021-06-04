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
    public class ShipperController : ControllerBase
    {
      ShipperAppService _shipperAppService;
     

        public ShipperController(ShipperAppService shipperAppService)
        {
            this._shipperAppService = shipperAppService;

        }
        [HttpGet]
        public IActionResult GetAllShippers()
        {
            return Ok(_shipperAppService.GetAllShipper());
        }
        [HttpGet("{id}")]
        public IActionResult GetShipperById(int id)
        {
            return Ok(_shipperAppService.GetShipper(id));
        }
        [HttpPost]
        public IActionResult Create(ShipperViewModel shipperViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _shipperAppService.SaveNewShipper(shipperViewModel);

                //string urlDetails = Url.Link("DefaultApi", new { id = categoryViewModel.ID });
                //return Created(urlDetails, "Added Sucess");
                return Created("CreateShipper", shipperViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, ShipperViewModel shipperViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _shipperAppService.UpdatShipper(shipperViewModel);
                return Ok(shipperViewModel);
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
                _shipperAppService.DeleteShipper(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
  