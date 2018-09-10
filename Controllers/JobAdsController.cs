using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using JobberApp.Contracts;
using JobberApp.Repositories;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobberApp.Controllers
{
    [Route("api/employer")]
    public class JobAdsController : Controller
    {
        private readonly IJobAdService<JobAdViewModel,SaveJobAdModel> _jobAdService;

        public JobAdsController(IJobAdService<JobAdViewModel,SaveJobAdModel> jobAdService) 
        {
            _jobAdService = jobAdService ?? throw new ArgumentNullException(nameof(jobAdService));
        }

        [HttpPost("newjob")]
        public async Task<IActionResult> CreateJobAd([FromBody] SaveJobAdModel saveJobAdModel) 
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _jobAdService.CreateJobAd(saveJobAdModel, userId));
        }

        [HttpGet("jobgroups")]
        public async Task<IActionResult> GetJobAdsNames() 
        { 
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _jobAdService.GetJobAdsNames(userId));
        }

        [HttpGet("jobads")]
        public async Task<IActionResult> GetJobAds() 
        { 
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _jobAdService.GetJobAds(userId));
        }

        [HttpGet("assignedjobads")]
        public async Task<IActionResult> GetAssignedJobAds() 
        { 
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _jobAdService.GetAssignedJobAds(userId));
        }

        [HttpGet("completedjobads")]
        public async Task<IActionResult> GetCompletedJobAds() 
        { 
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _jobAdService.GetCompletedJobAds(userId));
        }

        [HttpDelete("jobad/{id}")]
        public async Task<IActionResult> DeleteJobAd(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }                      
            return Ok(await _jobAdService.DeleteJobAd(id));
        }

        // [HttpGet("alljobads")]
        // public async Task<IActionResult> GetAllJobAds() 
        // {    
        //     return Ok(await _jobAdService.GetAllJobAds());
        // }
       
    }
}