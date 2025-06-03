using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2025.DAL;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            
            try
            {
                var countries = await _context.Countries.ToListAsync();

                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
        public async Task<Country> GetCountryByIdAsync(Guid id)
        {

            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); //El método Add() me permite creal el objeto en el contexto de mi base de datos.

                await _context.SaveChangesAsync(); //Este método me permite guardar el pais en mi tabla COUNTRY.

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? 
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;

                _context.Countries.Update(country);
                await _context.SaveChangesAsync(); //virtualizo mi objeto

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);

                if (country == null)
                {
                    return null;
                }
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

    }
}
