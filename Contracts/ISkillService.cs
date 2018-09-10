using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobberApp.Contracts
{
    public interface ISkillService<T> where T: class
    {
        Task<IEnumerable<T>> GetSkills();
        // Task<DM> GetById(int id);
        // Task<DM> Create(VM viewModel);
        // Task<DM> Update(int id, VM viewModel);
        // Task<DM> Delete(int id);
    }
}