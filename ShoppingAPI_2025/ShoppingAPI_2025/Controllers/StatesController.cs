using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_2025.DAL.Entities;
using ShoppingAPI_2025.Domain.Interfaces;

namespace ShoppingAPI_2025.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesAsync()
        {
            var states = await _stateService.GetStatesAsync();

            if (states == null || !states.Any())
            {
                return NotFound();
            }

            return Ok(states);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByID/{id}")]
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound();
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"Ya existe un estado con el nombre: {state.Name}");

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                if (editedState == null) return NotFound();
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"Ya existe un estado con el nombre: {state.Name}");

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) return NotFound();
            return Ok(deletedState);
        }
    }
}
