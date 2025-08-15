using ProductAppAsync.src.models;

namespace ProductAppAsync.src.interfaces
{
    public interface UserInterface
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(string name, string address, string email);
    }
}
