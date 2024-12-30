using Calc.Models;
namespace Calc.StaticData
{
    public class StaticData
    {
        public static List<User> users = new()
    {
            new User() { Email = "admin@belstu.by",Password = "-Qwerty12345",Roles = new[] { Roles.Administrator} },
    };
    }
}
