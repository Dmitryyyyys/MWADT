using Microsoft.AspNetCore.Mvc;

namespace Calc.Controllers
{
    public class CalcController : Controller
    {
        // GET: /Calc/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.x = null;
            ViewBag.y = null;
            ViewBag.z = null;
            ViewBag.press = null;
            ViewBag.Error = null;
            return View("/Views/Calc/Calc.cshtml");
        }

        // GET: /Calc/Sum
        [HttpGet]
        public IActionResult Sum()
        {
            ViewBag.press = "+";
            ViewBag.x = null;
            ViewBag.y = null;
            ViewBag.z = null;
            ViewBag.Error = null;
            return View("/Views/Calc/Calc.cshtml");
        }

        // POST: /Calc/Sum
        [HttpPost]
        public IActionResult Sum(float? x, float? y)
        {
            ViewBag.press = "+";
            ViewBag.x = x;
            ViewBag.y = y;

            if (x == null || y == null)
            {
                ViewBag.Error = "Ошибка: Введите оба числа.";
            }
            else
            {
                ViewBag.z = x + y;
            }

            return View("/Views/Calc/Calc.cshtml");
        }

        // GET: /Calc/Sub
        [HttpGet]
        public IActionResult Sub()
        {
            ViewBag.press = "-";
            ViewBag.x = null;
            ViewBag.y = null;
            ViewBag.z = null;
            ViewBag.Error = null;
            return View("/Views/Calc/Calc.cshtml");
        }

        // POST: /Calc/Sub
        [HttpPost]
        public IActionResult Sub(float? x, float? y)
        {
            ViewBag.press = "-";
            ViewBag.x = x;
            ViewBag.y = y;

            if (x == null || y == null)
            {
                ViewBag.Error = "Ошибка: Введите оба числа.";
            }
            else
            {
                ViewBag.z = x - y;
            }

            return View("/Views/Calc/Calc.cshtml");
        }

        // GET: /Calc/Mul
        [HttpGet]
        public IActionResult Mul()
        {
            ViewBag.press = "*";
            ViewBag.x = null;
            ViewBag.y = null;
            ViewBag.z = null;
            ViewBag.Error = null;
            return View("/Views/Calc/Calc.cshtml");
        }

        // POST: /Calc/Mul
        [HttpPost]
        public IActionResult Mul(float? x, float? y)
        {
            ViewBag.press = "*";
            ViewBag.x = x;
            ViewBag.y = y;

            if (x == null || y == null)
            {
                ViewBag.Error = "Ошибка: Введите оба числа.";
            }
            else
            {
                ViewBag.z = x * y;
            }

            return View("/Views/Calc/Calc.cshtml");
        }

        // GET: /Calc/Div
        [HttpGet]
        public IActionResult Div()
        {
            ViewBag.press = "/";
            ViewBag.x = null;
            ViewBag.y = null;
            ViewBag.z = null;
            ViewBag.Error = null;
            return View("/Views/Calc/Calc.cshtml");
        }

        // POST: /Calc/Div
        [HttpPost]
        public IActionResult Div(float? x, float? y)
        {
            ViewBag.press = "/";
            ViewBag.x = x;
            ViewBag.y = y;

            if (x == null || y == null)
            {
                ViewBag.Error = "Ошибка: Введите оба числа.";
            }
            else if (y == 0)
            {
                ViewBag.Error = "Ошибка: Деление на 0 невозможно.";
            }
            else
            {
                ViewBag.z = x / y;
            }

            return View("/Views/Calc/Calc.cshtml");
        }
    }
}
