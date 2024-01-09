using crud_swashbuckle.Model;

namespace crud_swashbuckle.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchUsers();
        Task<User> SearchUser(int id);
        Task<bool> SaveChangeAsync();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}