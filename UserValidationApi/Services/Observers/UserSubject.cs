using UserValidationApi.Models;

namespace UserValidationApi.Services.Observers
{
    public class UserSubject : SingletonManager<UserSubject>
    {
        private List<IObserver> _observers = new List<IObserver>();
        private User _user;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_user);
            }
        }

        public void ChangeUser(User user)
        {
            _user = user;
            Notify();
        }
    }
}