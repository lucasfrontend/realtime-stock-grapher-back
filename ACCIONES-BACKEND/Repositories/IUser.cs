using ACCIONES_BACKEND.Models;

namespace ACCIONES_BACKEND.Repositories
{
    public interface IUser
    {
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<User> RegisterUserAsync(User user);
        Task<User> FindUserByEmailAsync(string email);
    }
}