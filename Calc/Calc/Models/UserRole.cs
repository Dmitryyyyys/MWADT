using Microsoft.AspNetCore.Identity;
namespace Calc.Models
{
    public class UserRole
    {
        public IdentityUser user = null;
        public List<string> rolesList = new List<string>();

        public string GetUserListAsString()
        {
            string output = "";
            foreach(var role in rolesList)
            {
                output += $"{role} ";
            }
        return output;
        }
    }
}
