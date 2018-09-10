using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using JobberApp.ViewModels;
using JobberApp.Data;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.Http;
using JobberApp.Data.Models;
using System.Diagnostics;

namespace JobberApp.Controllers
{
    [Route("api/token")]
    public class TokenController : Controller
    {
        #region Private Members
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;
        #endregion Private Members

        #region Constructor
        public TokenController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }
        #endregion

        
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody]TokenRequestViewModel tokenRequestViewModel)
        {
            // return a generic HTTP Status 500 (Server Error)
            // if the client payload is invalid.
            if (tokenRequestViewModel == null) return new StatusCodeResult(500);

            switch (tokenRequestViewModel.GrantType)
            {
                case "password":
                    return await GetToken(tokenRequestViewModel);
                case "refreshToken":
                    return await RefreshToken(tokenRequestViewModel);
                default:
                    // not supported - return a HTTP 401 (Unauthorized)
                    return new UnauthorizedResult();
            }
        }

        private async Task<IActionResult> GetToken(TokenRequestViewModel tokenRequestViewModel)
        {
            try
            {
                // check if there's an user with the given username
                var user = await _userManager.FindByNameAsync(tokenRequestViewModel.UserName);
                // fallback to support e-mail address instead of username
                if (user == null && tokenRequestViewModel.UserName.Contains("@"))
                    user = await _userManager.FindByEmailAsync(tokenRequestViewModel.UserName);

                if (user == null || !await _userManager.CheckPasswordAsync(user, tokenRequestViewModel.Password))
                {
                    // user does not exists or password mismatch
                    return new UnauthorizedResult();
                }

                // username & password matches: create the refresh token
                var rt = CreateRefreshToken(tokenRequestViewModel.ClientId, user.Id);

                // add the new refresh token to the DB
                _context.Tokens.Add(rt);
                _context.SaveChanges();

                // create & return the access token
                var t = CreateAccessToken(user.Id, rt.Value);
                return Ok(t);
            }
            catch (Exception)
            {
                // Debug.WriteLine("Exception Message: " + ex.Message);
                return new UnauthorizedResult();
            }
        }

        private async Task<IActionResult> RefreshToken(TokenRequestViewModel tokenRequestViewModel)
        {
            try
            {
                // check if the received refreshToken exists for the given clientId
                var rt = _context.Tokens.FirstOrDefault(t =>
                    t.ClientId == tokenRequestViewModel.ClientId
                    && t.Value == tokenRequestViewModel.RefreshToken);

                if (rt == null)
                {
                    // refresh token not found or invalid (or invalid clientId)
                    return new UnauthorizedResult();
                }

                // check if there's an user with the refresh token's userId
                var user = await _userManager.FindByIdAsync(rt.UserId);

                if (user == null)
                {
                    // UserId not found or invalid
                    return new UnauthorizedResult();
                }

                // generate a new refresh token
                var rtNew = CreateRefreshToken(rt.ClientId, rt.UserId);

                // invalidate the old refresh token (by deleting it)
                _context.Tokens.Remove(rt);

                // add the new refresh token
                _context.Tokens.Add(rtNew);

                // persist changes in the DB
                _context.SaveChanges();

                // create a new access token...
                var response = CreateAccessToken(rtNew.UserId, rtNew.Value);

                // ... and send it to the client
                return Ok(response);
            }
            catch (Exception)
            {
                return new UnauthorizedResult();
            }
        }

        private Token CreateRefreshToken(string clientId, string userId)
        {
            return new Token()
            {
                ClientId = clientId,
                UserId = userId,
                Type = 0,
                Value = Guid.NewGuid().ToString("N"),
                CreatedDate = DateTime.UtcNow
            };
        }

        private TokenResponseViewModel CreateAccessToken(string userId, string refreshToken)
        {
            DateTime now = DateTime.UtcNow;

            // add the registered claims for JWT (RFC7519).
            // For more info, see https://tools.ietf.org/html/rfc7519#section-4.1
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
                // TODO: add additional claims here
            };

            var tokenExpirationMins = _configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes"); 
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"]));

     
            var token = new JwtSecurityToken(
                issuer: _configuration["Auth:Jwt:Issuer"],
                audience: _configuration["Auth:Jwt:Audience"],
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(tokenExpirationMins)),
                signingCredentials: new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            var user = _context.Users.SingleOrDefault(x => x.Id == userId);

            return new TokenResponseViewModel()
            {
                Token = encodedToken,
                Expiration = tokenExpirationMins,
                RefreshToken = refreshToken,
                DisplayName = user.DisplayName
            };
        }
    }
}