using System;
using System.Security.Claims;
using System.Threading.Tasks;
using JobberApp.Data;
using JobberApp.Data.Models;
using JobberApp.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobberApp.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {     
        #region Private Members
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }
        #endregion

        #region RESTful Conventions
        /// <summary>
        /// PUT: api/user
        /// </summary>
        /// <returns>Creates a new User and return it accordingly.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserViewModel userViewModel)
        {
            // return a generic HTTP Status 500 (Server Error)
            // if the client payload is invalid.
            if (userViewModel == null) return new StatusCodeResult(500);

            // check if the Username/Email already exists
            ApplicationUser user = await _userManager.FindByNameAsync(userViewModel.UserName);
            if (user != null) return BadRequest("Username already exists");

            user = await _userManager.FindByEmailAsync(userViewModel.Email);
            if (user != null) return BadRequest("Email already exists.");

            // added in 2018.01.06 to fix GitHub issue #11
            // ref.: https://github.com/PacktPublishing/ASP.NET-Core-2-and-Angular-5/issues/11
            if (!PasswordCheck.IsValidPassword(userViewModel.Password, _userManager.Options.Password)) return BadRequest("Password is too weak.");

            var now = DateTime.Now;
            // create a new Item with the client-sent json data
            user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
                DisplayName = userViewModel.DisplayName,
                CreatedDate = now,
                LastModifiedDate = now
            };

            // Add the user to the Db with the choosen password
            await _userManager.CreateAsync(user, userViewModel.Password);


            // Assign the user to the 'Employer' role.
            await _userManager.AddToRoleAsync(user, "Employer");

            // Remove Lockout and E-Mail confirmation
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;

            await _context.Employers.AddAsync(new Employer { UserId = user.Id } );
            // persist the changes into the Database.
            await _context.SaveChangesAsync();

            // return the newly-created User to the client.
            return Ok(user.Adapt<UserViewModel>());
        }

        [HttpGet("details")]
        public async Task<IActionResult> LoggedInEmployer()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var employer = await _context.Employers.Include(c => c.User).SingleAsync(c => c.User.Id == userId);
            
            return new OkObjectResult(new
                {
                    employer.User.DisplayName
                });
        }
        #endregion
    }
}