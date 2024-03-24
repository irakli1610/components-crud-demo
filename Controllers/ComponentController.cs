using JunkWebApi.Data;
using JunkWebApi.Dto;
using JunkWebApi.Interfaces;
using JunkWebApi.Mappings.Components;
using JunkWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JunkWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _componentRepo;

        public ComponentController(IComponentRepository CompRepo)
        {
            _componentRepo = CompRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllComponents()
        {
            var components =await  _componentRepo.GetAllAsync();
            return Ok(components);
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var component = await _componentRepo.GetByIdAsync(id);

            if (component == null) 
            {
                return NotFound();
            }

            return Ok(component);
        }



        //fix return statement, for some reason server returns
        // error code 500. problem is inside nameof method, figure it out
        // otherwise method works, so you can continue to work.
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ComponentDto componentDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var componentModel = ComponentMapper.ToComponent(componentDto);
            var createdComponentModel = await _componentRepo.CreateAsync(componentModel);


            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdComponentModel.Id }, createdComponentModel);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var componentModel = await _componentRepo.DeleteAsync(id);

            if(componentModel == null)
            {
                return NotFound("Component does not exists");
            }

            return Ok(componentModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ComponentDto componentDto) 
        {
            var componentModel = await _componentRepo.UpdateAsync(id, ComponentMapper.ToComponent(componentDto));

            if(componentModel == null)
            {
                return BadRequest("Component not found");
            }
            return Ok(componentModel);
        }


    }
}
