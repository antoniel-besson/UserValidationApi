using UserValidationApi.Models;

namespace UserValidationApi.Services.Observers
{
    public interface IObserver
    {
        void Update(User user);
    }
}
