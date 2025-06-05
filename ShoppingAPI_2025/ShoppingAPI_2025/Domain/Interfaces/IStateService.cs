using ShoppingAPI_2025.DAL.Entities;

namespace ShoppingAPI_2025.Domain.Interfaces

{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync();

        Task<State> CreateStateAsync(State state);

        Task<State> GetStateByIdAsync(Guid id);

        Task<State> EditStateAsync(State state);

        Task<State> DeleteStateAsync(Guid id);
    }
}
