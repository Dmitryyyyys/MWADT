using Microsoft.AspNetCore.Mvc;
namespace lab2a.Controllers
{
    public class StartControlle:Controller
    {
    [Route("Start/Index")]
        public IActionResult Index()
        { 
        return View("/Views/Start/Index.cshtml");
        }
        [Route("Start/One")]

        public IActionResult One()
        {
            return Ok("Start/One");
        }
        [Route("Start/Two")]

        public IActionResult Two()
        {
            return Ok("Start/Two");
        }
        [Route("Start/Three")]
        public IActionResult Three()
        {
            return Ok("Start/Three");
        }
    }
}
