using blogsite.webapp.Identity;
using blogsite.webapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace blogsite.webapp.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var isThereUser = await _userManager.FindByNameAsync(loginModel.UserName);
            if(isThereUser==null)
            {
                TempData["Message"] = "Girilen kullanıcı adı sistemde kayıtlı değildir!";
                TempData["Alert"]="alert-danger";
                return View(loginModel);
            }
            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, true);
            if(result.Succeeded)
            {
                TempData["Message"] = "Giriş başarılı!";
                TempData["Alert"] = "alert-success";
                Thread.Sleep(3000);
                return RedirectToAction("Index", "Home");
            }
            TempData["Message"] = "Girilen şifre yanlış!";
            TempData["Alert"]="alert-danger";
            return View(loginModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Message"] = "Oturum kapatıldı!";
            TempData["Alert"]="alert-danger";
            return Redirect("~/");
        }
        /////////////////////////////////////////////////////////////////
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                return View(registerModel);
            }
            var isThereUser = await _userManager.FindByNameAsync(registerModel.UserName);
            var isThereEmail = await _userManager.FindByEmailAsync(registerModel.EmailAddress);
            if(isThereEmail != null)
            {
                TempData["Message"] = "Bu email zaten kullanılıyor!";
                TempData["Alert"]="alert-danger";
                return View(registerModel);
            }
            if(isThereUser != null)
            {
                TempData["Message"] = "Bu kullanıcı adı zaten kullanılıyor!";
                TempData["Alert"]="alert-danger";
                return View(registerModel);
            }
            var user = new User()
            {
                FirstName=registerModel.FirstName,
                LastName=registerModel.LastName,
                UserName=registerModel.UserName,
                Email=registerModel.EmailAddress
            };
            if(file!=null && file.Length!=0)
            {
                var fileName=registerModel.UserName+Path.GetExtension(file.FileName);
                var path=Path.Combine("wwwroot","Images",fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                user.ImageUrl=fileName;
            }
            else
            {
                user.ImageUrl="man.jpeg";
            }
            
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if(result.Succeeded)
            {
                TempData["Message"] = "Kaydınız Oluşturuldu!";
                TempData["Alert"]="alert-success";
                return RedirectToAction("Login","Account");
            }
            TempData["Message"] = "Hesabınız Oluşturulamadı";
            TempData["Alert"]="alert-danger";
            return View(registerModel);
        }
        /////////////////////////////////////////////////////////////////        

        public IActionResult AccountSettings()
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var userModel = new UserModel(){
                Id=user.Id,
                UserName=user.UserName,
                FirstName=user.FirstName,
                LastName=user.LastName,
                EmailAddress=user.Email
            };
            return View(userModel);
        }
    }

}