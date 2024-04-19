using UserValidationApi.Models;

namespace UserValidationApi.Interface
{
    public interface IUserService
    {
        Task<User> CreateUser(UserRequest user);

        Task<User> UpdateUser(User user);
    }
}
