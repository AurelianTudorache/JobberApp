using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.Repositories;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace JobberApp.Services
{
    public class LocationService : ILocationService<LocationViewModel,SaveLocationModel>
    {
        private IGenericRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(IGenericRepository locationRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));            
        }

        public async Task<IEnumerable<LocationViewModel>> GetLocations(string userId)
        {   
            var employer = await _locationRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            var employerLocations = await _locationRepository.GetAsync<Location>(x => x.EmployerId == employer.Id);  

            return _mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(employerLocations); 
        }    

        public async Task<LocationViewModel> CreateLocation(SaveLocationModel saveLocationModel, string userId) 
        {
            var location = _mapper.Map<SaveLocationModel, Location>(saveLocationModel);

            var employer = await _locationRepository.GetOneAsync<Employer>(x => x.UserId == userId);

            location.EmployerId = employer.Id;
           
            await _locationRepository.Create<Location>(location);

            location = await _locationRepository.GetByIdAsync<Location>(location.Id);

            var result = _mapper.Map<Location, LocationViewModel>(location);
            
            return result;
        }

        public async Task<LocationViewModel> DeleteLocation(int id)
        {
            var location = await _locationRepository.GetByIdAsync<Location>(id);

            await _locationRepository.Delete<Location>(location);

            var result = _mapper.Map<Location, LocationViewModel>(location);

            return result;           
        }

        public async Task<LocationViewModel> UpdateLocation(SaveLocationModel saveLocationModel) 
        {
            var location = await _locationRepository.GetOneAsync<Location>(l => l.Id == saveLocationModel.Id);
            
            _mapper.Map<SaveLocationModel, Location>(saveLocationModel, location);   

            await _locationRepository.Update<Location>(location);       

            location = await _locationRepository.GetByIdAsync<Location>(location.Id);

            var result = _mapper.Map<Location, LocationViewModel>(location);

            return result;
        }
        
    }
}