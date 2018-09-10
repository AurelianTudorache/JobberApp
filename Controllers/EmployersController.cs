using System;
using System.Security.Claims;
using System.Threading.Tasks;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.Extensions;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobberApp.Controllers
{
    [Route("api/employer")]
    public class EmployersController : Controller
    {
        private readonly IEmployerService<EmployerViewModel,SaveEmployerModel> _employerService;
        public EmployersController(IEmployerService<EmployerViewModel,SaveEmployerModel> employerService) 
        {
            _employerService = employerService ?? throw new ArgumentNullException(nameof(employerService));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployer() 
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _employerService.GetEmployer(userId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployerBusinessDetails([FromBody] SaveEmployerModel saveEmplyerdModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            return Ok(await _employerService.UpdateEmployer(saveEmplyerdModel));
        }

    }
}