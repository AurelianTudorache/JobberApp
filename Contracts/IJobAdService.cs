using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobberApp.Contracts
{
    public interface IJobAdService<T, S> where T : class where S : class
    {
        Task<T> CreateJobAd(S resource, string userId);
        Task<IEnumerable<string>> GetJobAdsNames(string userId); 
        Task<IEnumerable<T>> GetJobAds(string userId); 
        Task<IEnumerable<T>> GetCompletedJobAds(string userId); 
        Task<IEnumerable<T>> GetAssignedJobAds(string userId); 
        Task<T> DeleteJobAd(int id); 


        // Task<IEnumerable<T>> GetAllJobAds(); 
    }
}