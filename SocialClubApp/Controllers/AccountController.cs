using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialClubApp.Models;
using SocialClubApp.ViewModels;

namespace SocialClubApp.Controllers
{
    public class AccountController : Controller
    {

        //stores constructor parameter in private field
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        
        //constructor injection
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            //this design pattern more loosily couples AccountController with 
            //UserManager and SignInManager
            _userManager = userManager;
            _signInManager = signInManager;           
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM) 
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email
                };

                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    // If the user is signed in and in the Admin role, then it is
                    // the Admin user that is creating a new user. So redirect the
                    // Admin user to ListRoles action
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Club");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerVM);
        }

        [HttpGet]
        public IActionResult Login() 
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        
        public async Task<IActionResult> Login(LoginViewModel loginVM, string? returnUrl) 
        {
            if (ModelState.IsValid) 
            {

                var result = await _signInManager.PasswordSignInAsync(loginVM.UserName,
                    loginVM.Password, loginVM.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else 
                    {
                        return RedirectToAction("Index", "Club");
                    }

                    
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View(loginVM);

        }

        public IActionResult AccessDenied() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Club");
        }

        public IActionResult ForgotPassword() 
        {
            return View();
        }

    }

}
