using System.Data;

namespace UserValidationApi.Models
{
    public class AdminUser : User
    {
        public AdminUser()
        {
            Role = "Admin";
        }
    }
}