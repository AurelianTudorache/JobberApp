using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobberApp.Contracts
{
    public interface ICardService<T, S> where T : class where S : class
    {
        Task<T> GetCard(string userId);
        Task<T> CreateCard(S resource);
        Task<T> UpdateCard(S resource);        
    }
}