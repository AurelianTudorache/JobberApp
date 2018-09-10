using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobberApp.Contracts
{
    public interface ILocationService<T, S> where T : class where S : class
    {
        Task<IEnumerable<T>> GetLocations(string userId);     
        Task<T> CreateLocation(S resource, string userId); 
        Task<T> DeleteLocation(int id);    
        Task<T> UpdateLocation(S resource);     
    }
}