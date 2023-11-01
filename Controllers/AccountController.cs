using Lancheria.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lancheria.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnURL = returnUrl,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVW)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVW);
            }

            var user = await _userManager.FindByNameAsync(loginVW.Username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVW.Password, false, false);
                if (result.Succeeded)
                {
                    if(string.IsNullOrEmpty(loginVW.ReturnURL))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVW.ReturnURL);
                }
            }
            ModelState.AddModelError("", "Falha ao realizar o Login!!");
            return View(loginVW);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registroVM.Username };
                var result = await _userManager.CreateAsync(user, registroVM.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuario");
                }
            }
        return View(registroVM);    
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied()
        {
            return View();  
        }
    }
}
