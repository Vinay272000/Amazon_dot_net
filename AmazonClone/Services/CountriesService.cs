using AmazonClone.Context;
using AmazonClone.Models;
using Microsoft.EntityFrameworkCore;

namespace AmazonClone.Services
{
    public class CountriesService : ICountriesService
    {
        public AmazonDbContext _AmazonDbContext;
        public ILogger<CategoryService> _log;
        public CountriesService(AmazonDbContext amazonDbContext, ILogger<CategoryService> log)
        {
            _AmazonDbContext = amazonDbContext;
            _log = log;
        }
        public async Task<bool> Create(Countrys country)
        {
            try
            {
                _AmazonDbContext.countrys?.Add(country);
                int entries = await _AmazonDbContext.SaveChangesAsync();
                return entries > 0;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"create({country})");
                return false;
            }
        }

        public async Task<bool> DeleteCountry(Countrys country)
        {
            try
            {
                if (_AmazonDbContext.countrys != null)
                {
                    _AmazonDbContext.countrys.Remove(_AmazonDbContext.countrys.Find(country.CountryId));
                    int deletedId = await _AmazonDbContext.SaveChangesAsync();
                    return deletedId > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"DeleteCountry({country})");
                return false;
            }
        }

        public async Task<IEnumerable<Countrys>> GetCountries()
        {
            try
            {
                return await _AmazonDbContext.countrys.ToListAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"GetCountries()");
                return Enumerable.Empty<Countrys>();
            }
        }

        public async Task<Countrys?> GetCountryById(int id)
        {
            try
            {
                if (_AmazonDbContext.countrys != null)
                {
                    return await _AmazonDbContext.countrys.FindAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"GetCountryById({id})");
                return null;
            }
        }

        public async Task<bool> UpdateCountry(Countrys country)
        {
            try
            {
                if (_AmazonDbContext.countrys != null)
                {
                    Countrys existingCountry = await _AmazonDbContext.countrys.FindAsync(country.CountryId);
                    if (existingCountry != null)
                    {
                        existingCountry.CountryName = country.CountryName;
                        int entries = _AmazonDbContext.SaveChanges();
                        return entries > 0;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Update({country}");
                return false;
            }
        }
    }
}
