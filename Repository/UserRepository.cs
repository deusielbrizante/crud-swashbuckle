using crud_swashbuckle.Data;
using crud_swashbuckle.Model;
using Microsoft.EntityFrameworkCore;

namespace crud_swashbuckle.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context) => _context = context;

        public async Task<bool> SaveChangeAsync() => await _context.SaveChangesAsync() > 0;

        public async Task<User> SearchUser(int id) => await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> SearchUsers() => await _context.Users.ToListAsync();
        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }
    }
}