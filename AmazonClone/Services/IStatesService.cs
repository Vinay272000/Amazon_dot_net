using AmazonClone.Models;

namespace AmazonClone.Services
{
    public interface IStatesService
    {
        Task<bool> Create(States state);
        Task<IEnumerable<States>> GetStates();

        Task<States?> GetStateById(int id);
        Task<bool> UpdateState(States state);
        Task<bool> DeleteState(States state);
    }
}
