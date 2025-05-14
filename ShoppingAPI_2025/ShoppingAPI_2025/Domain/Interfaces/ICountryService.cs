using ShoppingAPI_2025.DAL.Entities;

namespace ShoppingAPI_2025.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); //Una de las tantas firmas de un método!

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryById(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
    }
}
