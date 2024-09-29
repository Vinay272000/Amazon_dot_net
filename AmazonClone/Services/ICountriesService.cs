using AmazonClone.Models;

namespace AmazonClone.Services
{
    public interface ICountriesService
    {
        Task<bool> Create(Countrys country);
        Task<IEnumerable<Countrys>> GetCountries();

        Task<Countrys?> GetCountryById(int id);
        Task<bool> UpdateCountry(Countrys country);
        Task<bool> DeleteCountry(Countrys country);
    }
}
