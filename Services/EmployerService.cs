using System;
using System.Threading.Tasks;
using AutoMapper;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.Repositories;
using JobberApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobberApp.Services
{
    public class EmployerService : IEmployerService<EmployerViewModel,SaveEmployerModel>
    {
        private IGenericRepository _employerRepository;
        private readonly IMapper _mapper;
        public EmployerService(IGenericRepository employerRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employerRepository = employerRepository ?? throw new ArgumentNullException(nameof(employerRepository));            
        }

        public async Task<EmployerViewModel> GetEmployer(string userId)
        {   
            var employer = await _employerRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            
            return _mapper.Map<Employer, EmployerViewModel>(employer); 
        }

        public async Task<EmployerViewModel> UpdateEmployer(SaveEmployerModel saveEmployerModel) 
        {
            var employer = await _employerRepository.GetOneAsync<Employer>(e => e.Id == saveEmployerModel.Id);
            
            _mapper.Map<SaveEmployerModel, Employer>(saveEmployerModel, employer);   

            await _employerRepository.Update<Employer>(employer);       

            employer = await _employerRepository.GetByIdAsync<Employer>(employer.Id);

            var result = _mapper.Map<Employer, EmployerViewModel>(employer);

            return result;
        }

        // public async Task<EmployerViewModel> GetEmployerMessages(string userId)
        // {
        //     var employerMessages = await _employerRepository.GetOneAsync<Employer>(x => x.UserId == userId, "Messages,Messages.Employee");
        //     return _mapper.Map<Employer, EmployerViewModel>(employerMessages);
        // }

        // public async Task<EmployerViewModel> GetEmployerLocations(string userId)
        // {    
        //     var employerLocations = await _employerRepository.GetOneAsync<Employer>(x => x.UserId == userId, "Locations");
        //     return _mapper.Map<Employer, EmployerViewModel>(employerLocations); 
        // } 

        // public async Task<EmployerViewModel> GetEmployerNotifications(string userId)
        // {
        //     var employerNotifications = await _employerRepository.GetOneAsync<Employer>(x => x.UserId == userId, "Notifications");
        //     return _mapper.Map<Employer, EmployerViewModel>(employerNotifications);
        // }

      
        // public async Task<EmployerViewModel> GetEmployerJobsAddNewAsync()
        // {            
        //     throw new NotImplementedException();
        // } 

        // }
        // public async Task<EmployerViewModel> GetEmployerJobsPostedAsync() 
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<EmployerViewModel> GetEmployerJobsFilledAsync()
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<EmployerViewModel> GetEmployerJobsTodayAsync()
        // {
        //     throw new NotImplementedException();
        // } 

        // public async Task<EmployerViewModel> GetEmployerJobsCompletedAsync()
        // {
        //     throw new NotImplementedException();
        // }

    }
}