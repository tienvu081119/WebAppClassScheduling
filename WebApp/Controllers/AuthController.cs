using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        MemberRepository repository;
        RoleRepository roleRepository;

        public AuthController(CSContext context)
        {
            repository = new MemberRepository(context);
            roleRepository = new RoleRepository(context);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel obj)
        {
            repository.Add(new Member {
                Id= Helper.RandomString(32),
                Email = obj.Email,
                Gender = obj.Gender,
                Username = obj.Username,
                Password = Helper.Hash(obj.Password)

            });
            return Redirect("/auth/login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            Member member = repository.Login(obj);
            if(member != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, member.Username),
                    new Claim(ClaimTypes.Email, member.Email),
                    new Claim(ClaimTypes.Gender, member.Gender.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, member.Id)
                };
                //Thieu Roles
                List<Role> roles = roleRepository.GetRolesByMemberId(member.Id);
                if(roles != null)
                {
                    foreach(var item in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Name));
                    }
                }


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    IsPersistent = obj.Remember
                };
                await HttpContext.SignInAsync(principal, properties);

                return Redirect("/auth");
            }
            ModelState.AddModelError("", "Login Failed");
            return View(obj);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/auth/login");
        }
         
        public IActionResult Index()
        {
            return View();
        }
    }
}
