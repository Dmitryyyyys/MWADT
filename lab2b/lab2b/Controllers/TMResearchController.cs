using Microsoft.AspNetCore.Mvc;

    public class TMResearchController : Controller
    {
        
        public IActionResult M01(string? id)
        {
            return Content("GET:M01\nstring - " + id);
        }

        
        public IActionResult M02(string id)
        {
            return Content("GET:M02\nstring - " + id);
        }

       
        public IActionResult M03(string id)
        {
            return Content("GET:M03\nstring - " + id);
        }

        
        public IActionResult MXX()
        {
            return Content("GET:MXX");
        }
    }