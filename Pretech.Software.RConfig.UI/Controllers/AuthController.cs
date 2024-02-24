using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Pretech.Software.RConfig.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

#if DEBUG
            var cUser = _config["Root:User"];
            var cPass = _config["Root:Password"];
            var cSession = TimeSpan.Parse(_config["Root:Session"]);
#endif
#if !DEBUG
  var cUser = Environment.GetEnvironmentVariable("RootUser");
            var cPass = Environment.GetEnvironmentVariable("RootPassword");
            var cSession = TimeSpan.Parse(Environment.GetEnvironmentVariable("RootSession"));
#endif
            if (cUser == null || cPass == null)
            {
                return View("Login", "Home");

            }
            if (cUser.Equals(username) && cPass.Equals(password))
            {
                var claims = new List<Claim>
                {
                        new Claim(ClaimTypes.Name,cUser),
                        new Claim(ClaimTypes.Role,"Admin"),

            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(cSession.TotalMinutes),
                    IsPersistent = true,
                    RedirectUri = "/"
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(claimsIdentity),
                                              authProperties);
                return RedirectToAction("Index", "Home");

            }
            else return View("Login", "Home");

        }
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
