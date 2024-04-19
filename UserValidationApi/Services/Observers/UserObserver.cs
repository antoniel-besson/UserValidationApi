using System.Diagnostics;
using UserValidationApi.Models;

namespace UserValidationApi.Services.Observers
{
    public class UserObserver : IObserver
    {
        public void Update(User user)
        {
            Debug.WriteLine($"Updated User: {user.Username}, Email: {user.Email}");
            Console.WriteLine($"Updated User: {user.Username}, Email: {user.Email}");
        }
    }
}
