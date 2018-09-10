using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.Repositories;
using JobberApp.ViewModels;

namespace JobberApp.Services
{
    public class JobAdService : IJobAdService<JobAdViewModel,SaveJobAdModel>
    {
        private IGenericRepository _jobAdRepository;
        private readonly IMapper _mapper;
        public JobAdService(IGenericRepository jobAdRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jobAdRepository = jobAdRepository ?? throw new ArgumentNullException(nameof(jobAdRepository));            
        }

        public async Task<JobAdViewModel> CreateJobAd(SaveJobAdModel saveJobAdModel, string userId) 
        {
            var jobAd = _mapper.Map<SaveJobAdModel, JobAd>(saveJobAdModel);

            var employer = await _jobAdRepository.GetOneAsync<Employer>(x => x.UserId == userId);

            jobAd.EmployerId = employer.Id;
            jobAd.CreatedAt = DateTime.Now;
           
            await _jobAdRepository.Create<JobAd>(jobAd);

            jobAd = await _jobAdRepository.GetByIdAsync<JobAd>(jobAd.Id);

            var result = _mapper.Map<JobAd, JobAdViewModel>(jobAd);
            
            return result;
        }

        public async Task<IEnumerable<string>> GetJobAdsNames(string userId)
        {   
            var employer = await _jobAdRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            var employerJobAds = await _jobAdRepository.GetAsync<JobAd>(x => x.EmployerId == employer.Id); 

            // var result = _mapper.Map<IEnumerable<JobAd>, IEnumerable<JobAdViewModel>>(employerJobAds); 
            
            return employerJobAds.Select(x=> x.Name);

        }

        public async Task<IEnumerable<JobAdViewModel>> GetJobAds(string userId)
        {   
            var employer = await _jobAdRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            var employerJobAds = await _jobAdRepository.GetAsync<JobAd>(x => x.EmployerId == employer.Id);  

            return _mapper.Map<IEnumerable<JobAd>, IEnumerable<JobAdViewModel>>(employerJobAds); 
        }

        public async Task<JobAdViewModel> DeleteJobAd(int id)
        {
            var jobAd = await _jobAdRepository.GetByIdAsync<JobAd>(id);

            await _jobAdRepository.Delete<JobAd>(jobAd);

            var result = _mapper.Map<JobAd, JobAdViewModel>(jobAd);

            return result;           
        }

        public async Task<IEnumerable<JobAdViewModel>> GetCompletedJobAds(string userId)
        {   
            var employer = await _jobAdRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            var employerJobAds = await _jobAdRepository.GetAsync<JobAd>(x => x.EmployerId == employer.Id && x.IsCompleted == true);  

            return _mapper.Map<IEnumerable<JobAd>, IEnumerable<JobAdViewModel>>(employerJobAds); 
        }

        public async Task<IEnumerable<JobAdViewModel>> GetAssignedJobAds(string userId)
        {   
            var employer = await _jobAdRepository.GetOneAsync<Employer>(x => x.UserId == userId);
            var employerJobAds = await _jobAdRepository.GetAsync<JobAd>(x => x.EmployerId == employer.Id && x.IsAssigned == true && x.IsCompleted == false);  

            return _mapper.Map<IEnumerable<JobAd>, IEnumerable<JobAdViewModel>>(employerJobAds); 
        }

        // public async Task<IEnumerable<JobAdViewModel>> GetAllJobAds()
        // {            
        //     var allJobAds = await _jobAdRepository.GetAllAsync<JobAd>();  

        //     return _mapper.Map<IEnumerable<JobAd>, IEnumerable<JobAdViewModel>>(allJobAds); 
        // }

    }
}