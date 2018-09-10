using System.Threading.Tasks;

namespace JobberApp.Contracts
{
    public interface IEmployerService<T, S> where T: class where S: class
    {

        Task<T> GetEmployer(string userId);
        Task<T> UpdateEmployer(S resource);  
        // Task<T> CreateCard(S resource);
        // Task<T> GetEmployerLocations(string userId);
        // Task<T> GetEmployerNotifications(string userId); 
        // Task<T> GetEmployerMessages(string userId); 
        // Task<T> GetEmployerJobsPostedAsync(); 
        // Task<T> GetEmployerJobsFilledAsync(); 
        // Task<T> GetEmployerJobsTodayAsync(); 
        // Task<T> GetEmployerJobsCompletedAsync(); 
        // Task<T> GetEmployerJobsAddNewAsync(); 
    }
}