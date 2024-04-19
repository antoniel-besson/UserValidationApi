using System.Data;

namespace UserValidationApi.Models
{
    public class CustomerUser : User
    {
        public CustomerUser()
        {
            Role = "Customer";
        }
    }
}