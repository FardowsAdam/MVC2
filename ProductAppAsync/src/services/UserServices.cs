using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.interfaces;
using ProductAppAsync.src.models;
using ProductAppAsync.src.config;

namespace ProductAppAsync.src.services
{
    public class UserService : UserInterface
    {
        private readonly AppDBContext _db;

        public UserService(AppDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User> AddUserAsync(string name, string address, string email)
        {
            var user = new User
            {
                Name = name,
                Adedress = address,
                Email = email
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, string name, string address, string email)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
                return null;

            user.Name = name;
            user.Adedress = address;
            user.Email = email;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    
      public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null)
            return false;
        
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return true;
    }
    }
}
