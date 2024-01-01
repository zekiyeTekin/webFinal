using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using NETCore.Encrypt.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using WebFinal.Service.Data;
using WebFinal.Service.Models;
using WebFinal.Service.ViewModel;

namespace WebFinal.Controllers
{


    public class AccountController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        public AccountController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //login işlemleri
                string hashedPassword = DoMD5HashedString(model.Password);

                User user = _db.Users.SingleOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower()
                && x.Password == hashedPassword);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.UserName), "Kullanıcı hesabı pasif durumdadır");
                        return View(model);
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim("UserName", user.UserName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("Email", user.Email.ToString()));

                    ClaimsIdentity identity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");

                }


            }
            return View(model);
        }


        private string DoMD5HashedString(String s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = s + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_db.Users.Any(x => x.UserName.ToLower() == model.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.UserName), "Kullanıcı adı kullanılmaktadır!");
                    View(model);
                }

                string hashedPassword = DoMD5HashedString(model.Password);


                //register işlemleri () koymadım bir alta
                User user = new User
                {
                 
                    UserName = model.UserName,
                    Password = hashedPassword,
                    Email =model.Mail,
                };
                _db.Users.Add(user);
               int affectedRowCount = _db.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("","Kullanıcı eklenemedi!");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
                 
            }
            return View(model);
        }


        [Authorize]
        public IActionResult Profile()
        {
            ProfileInfoLoader();

            return View();
        }

        private void ProfileInfoLoader()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _db.Users.FirstOrDefault(x => x.Id == userid);

            ViewData["UserName"] = user.UserName;
        }

        [HttpPost]
        public IActionResult ProfileChangeUserName([StringLength(50)]string? username)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _db.Users.FirstOrDefault(x => x.Id == userid);
                user.UserName = username;
                _db.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }


        [HttpPost]
        public IActionResult ProfileChangePassword([MinLength(6)][MaxLength(16)] string? password)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _db.Users.FirstOrDefault(x => x.Id == userid);

                string hashedPassword = DoMD5HashedString(password);

                user.Password = hashedPassword;
                _db.SaveChanges();

                // return RedirectToAction(nameof(Profile));
                ViewData["result"] = "Şifre Değişti";
            }
            ProfileInfoLoader();
            return View("Profile");
        }


        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}
