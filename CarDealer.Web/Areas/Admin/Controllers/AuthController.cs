using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Kullanıcı adı ve şifre kontrolü
            if (username == "admin" && password == "123456")
            {
                // Eğer doğruysa Admin/Home/Index sayfasına yönlendir
                if (username == "admin" && password == "123456")
                {
                    // Debugging to ensure the action is being reached
                    Console.WriteLine("Redirecting to Admin/Home/Index");
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
            }

            // Eğer yanlışsa tekrar login sayfasına dön ve hata mesajı göster
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login", "Auth", new { Area = "Admin" });
        }
    }
}
