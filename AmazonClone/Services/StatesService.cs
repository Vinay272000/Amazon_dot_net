using AmazonClone.Context;
using AmazonClone.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AmazonClone.Services
{
    public class StatesService : IStatesService
    {
        public AmazonDbContext _AmazonDbContext;
        public ILogger<CategoryService> _log;
        public StatesService(AmazonDbContext amazonDbContext, ILogger<CategoryService> log)
        {
            _AmazonDbContext = amazonDbContext;
            _log = log;
        }
        public async Task<bool> Create(States state)
        {
            try
            {
                _AmazonDbContext.States?.Add(state);
                int entries = await _AmazonDbContext.SaveChangesAsync();
                return entries > 0;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"create({state})");
                return false;
            }
        }

        public async Task<bool> DeleteState(States state)
        {
            try
            {
                if (_AmazonDbContext.States != null)
                {
                    _AmazonDbContext.States.Remove(_AmazonDbContext.States.Find(state.StateId));
                    int deletedId = await _AmazonDbContext.SaveChangesAsync();
                    return deletedId > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"DeleteState({state})");
                return false;
            }
        }

        public async Task<States?> GetStateById(int id)
        {
            try
            {
                if (_AmazonDbContext.States != null)
                {
                    return await _AmazonDbContext.States.FindAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"GetStateById({id})");
                return null;
            }
        }

        public async Task<IEnumerable<States>> GetStates()
        {
            try
            {
                return await _AmazonDbContext.States.ToListAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"GetStates()");
                return Enumerable.Empty<States>();
            }
        }

        public async Task<bool> UpdateState(States state)
        {
            try
            {
                if (_AmazonDbContext.States != null)
                {
                    States existingState = await _AmazonDbContext.States.FindAsync(state.StateId);
                    if (existingState != null)
                    {
                        existingState.StateName = state.StateName;
                        existingState.CountryId = state.CountryId;
                        int entries = _AmazonDbContext.SaveChanges();
                        return entries > 0;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Update({state}");
                return false;
            }
        }
    }
}
