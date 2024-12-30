using Microsoft.AspNetCore.Identity;
namespace Calc.Models
{
    public class UserViewModel
    {
        public string? errorMessage = null;
        public bool isActionSuccess = false;
        public List<IdentityUser>? userList = null;
    }
}
