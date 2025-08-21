using ProductAppAsync.src.models;

namespace ProductAppAsync.src.interfaces
{
    public interface UserInterface
    {
       Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(int id); 
        
        // Create Operation
        Task<User> AddUserAsync(string name, string address, string email);
        
        // Update Operations
        Task<User> UpdateUserAsync(int id, string name, string address, string email);
      
        
        // Delete Operations
        Task<bool> DeleteUserAsync(int id);
    }
}
