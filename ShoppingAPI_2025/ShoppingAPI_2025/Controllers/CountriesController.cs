using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Controllers
{
    [Route("api/[controller]")] //Este es el nombre inicial de mi ruta, url o path
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController (ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();

            if (countries == null || !countries.Any()) return NotFound();

            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/id")] //URL: api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var countries = await _countryService.GetCountryByIdAsync(id);

            if (countries == null) return NotFound(); //NotFound =status 404

            return Ok(countries); //Ok = StatusCode Code 200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);

                if (newCountry == null) return NotFound();

                return Ok(newCountry); 
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya exixte", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);

                if (editedCountry == null) return NotFound();

                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya exixte", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedCountry = await _countryService.DeleteCountryAsync(id);

                if (deletedCountry == null) return NotFound();

                return Ok(deletedCountry);
            
        }
    }
}
