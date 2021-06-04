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
    public class BrandController : ControllerBase
    { 
        BrandAppService _brandAppService;
        public BrandController(BrandAppService brandAppService)
        {
            this._brandAppService =  brandAppService;
           
        }
        [HttpGet]
        public IActionResult GetAllBrands()
        {
            return Ok(_brandAppService.GetAllBrand());
        }
        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            return Ok(_brandAppService.GetBrand(id));
        }
        [HttpPost]
        public IActionResult Create(BrandViewModel brandViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _brandAppService.SaveNewBrand(brandViewModel);

                //string urlDetails = Url.Link("DefaultApi", new { id = categoryViewModel.ID });
                //return Created(urlDetails, "Added Sucess");
                return Created("CreateBrand", brandViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, BrandViewModel brandViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _brandAppService.UpdatBrand(brandViewModel);
                return Ok(brandViewModel);
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
                _brandAppService.DeleteBrand(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
 
    }
}
