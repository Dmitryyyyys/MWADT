using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace UWSR.Pages.Auth
{
    public class CreateModel : PageModel
    {
        private readonly UWSR.Data.AppDbContext _context;

        public CreateModel(UWSR.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string Password { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Links == null)
            {
                return Page();
            }

            // Получаем значение действия из формы
            var action = HttpContext.Request.Form["action"];

            if (action == "Authorize")
            {
                if (Password == "1111")
                {
                    // Устанавливаем статус администратора в сессии
                    HttpContext.Session.Set("isAdmin", Encoding.UTF8.GetBytes("true"));
                }
            }
            else if (action == "Logout Admin")
            {
                // Очистить все данные сессии
                HttpContext.Session.Clear();

                // Принудительно удалить куки сессии
                HttpContext.Response.Cookies.Delete(".AspNetCore.Session");

                HttpContext.Session.Set("isAdmin", Encoding.UTF8.GetBytes("false"));
            }

            return RedirectToPage("./Index");
        }
    }
}
