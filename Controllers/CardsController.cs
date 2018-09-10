using System;
using System.Security.Claims;
using System.Threading.Tasks;
using JobberApp.Contracts;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobberApp.Controllers
{
    [Route("api/employer/card")]
    public class CardsController : Controller
    {
        private readonly ICardService<CardViewModel,SaveCardModel> _cardService;

        public CardsController(ICardService<CardViewModel,SaveCardModel> cardService) 
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCard() 
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _cardService.GetCard(userId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] SaveCardModel saveCardModel) 
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _cardService.CreateCard(saveCardModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard([FromBody] SaveCardModel saveCardModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            return Ok(await _cardService.UpdateCard(saveCardModel));
        }
    }
}