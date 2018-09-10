using System;
using System.Security.Claims;
using System.Threading.Tasks;
using JobberApp.Contracts;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JobberApp.Controllers
{
    [Route("api/employer")]
    public class LocationsController : Controller
    {
        private readonly ILocationService<LocationViewModel,SaveLocationModel> _locationService;

        public LocationsController(ILocationService<LocationViewModel,SaveLocationModel> locationService) 
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
        }

        [HttpGet("locations")]
        [Authorize]       
        public async Task<IActionResult> GetLocations() 
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _locationService.GetLocations(userId));
        } 

        [HttpPost("addlocation")]
        public async Task<IActionResult> CreateLocation([FromBody] SaveLocationModel saveLocationModel) 
        {
           string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _locationService.CreateLocation(saveLocationModel, userId));
        }

        [HttpDelete("location/{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }                      
            return Ok(await _locationService.DeleteLocation(id));
        }

        [HttpPut("location/{id}")]
        public async Task<IActionResult> UpdateLocation([FromBody] SaveLocationModel saveLocationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            return Ok(await _locationService.UpdateLocation(saveLocationModel));
        }

    }
}