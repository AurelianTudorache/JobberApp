using System;
using System.Threading.Tasks;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobberApp.Controllers
{
    [Route("api/skills")]
    public class SkillsController : Controller
    {
        private readonly ISkillService<SkillViewModel> _skillService;
        public SkillsController(ISkillService<SkillViewModel> skillService) => _skillService = skillService ?? throw new ArgumentNullException(nameof(skillService));

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSkills()
        {
            return Ok(await _skillService.GetSkills());
        }
    }
}