using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.Repositories;
using JobberApp.ViewModels;

namespace JobberApp.Services
{
    public class CardService : ICardService<CardViewModel,SaveCardModel>
    {
        private IGenericRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardService(IGenericRepository cardRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));            
        }
        public async Task<CardViewModel> GetCard(string userId)
        {   
            var employer = await _cardRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            var employerCard = await _cardRepository.GetOneAsync<Card>(x => x.EmployerId == employer.Id);  
            
            return _mapper.Map<Card, CardViewModel>(employerCard); 
        }

        public async Task<CardViewModel> CreateCard(SaveCardModel saveCardModel) 
        {
            var card = _mapper.Map<SaveCardModel, Card>(saveCardModel);
           
            await _cardRepository.Create<Card>(card);

            card = await _cardRepository.GetByIdAsync<Card>(card.Id);

            var result = _mapper.Map<Card, CardViewModel>(card);
            
            return result;
        }

        public async Task<CardViewModel> UpdateCard(SaveCardModel saveCardModel) 
        {
            var card = await _cardRepository.GetOneAsync<Card>(c => c.Id == saveCardModel.Id);
            
            _mapper.Map<SaveCardModel, Card>(saveCardModel, card);   

            await _cardRepository.Update<Card>(card);       

            card = await _cardRepository.GetByIdAsync<Card>(card.Id);

            var result = _mapper.Map<Card, CardViewModel>(card);

            return result;
        }
        
    }
}