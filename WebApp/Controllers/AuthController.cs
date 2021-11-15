using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : BaseController
    {
        IConfiguration configuration;

        public AuthController(SiteProvider provider, IConfiguration configuration) : base(provider) {
            this.configuration = configuration;
        }

        public IActionResult Password()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Password(ForgotPassword obj)
        {
            string token = Helper.RandomString(32);
            obj.Token = token;
            int ret = provider.Member.Update(obj);
            if (ret > 0)

            {
                string body = $"<a href=\"https://localhost:44369/auth/reset/{token}\">Click here Reset Password</a>";
                IConfigurationSection section = configuration.GetSection("Email:Gmail");

                
                SmtpClient client = new SmtpClient(section.GetSection("Host").Value, Convert.ToInt32(section.GetSection("Port").Value))
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("ltvnetcore@gmail.com", "$tvne!c0re")
                };
                MailAddress from = new MailAddress("ltvnetcore@gmail.com");
                MailAddress to = new MailAddress(obj.Email);
                MailMessage mailMessage = new MailMessage(from, to);
                mailMessage.Subject = "App Scheduling Reset Password";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = body;
                client.Send(mailMessage);
                TempData["email"] = obj.Email;
                return Redirect("/auth/SentSuccess");
            }
            ModelState.AddModelError("", "Email Not Found");
            return View(obj);
        }

        public IActionResult SentSuccess()
        {
            return View();
        }

        public IActionResult Reset(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reset(string id, ResetPassword obj)
        {
            obj.Token = id;
            int ret = provider.Member.Update(obj);
            if (ret > 0)
            {
                return Redirect("/auth/login");
            }
            ModelState.AddModelError("", "Token Ivalid");
            return View(obj);
        }

        [Authorize]
        public IActionResult Change()
        {
            return View();
        }

        [Authorize, HttpPost]
        public IActionResult Change(ChangeModel obj)
        {
            obj.MemberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int ret = provider.Member.ChangePassword(obj);
            if(ret == 0)
            {
                ModelState.AddModelError("", "Change Password Failed");
                return View(obj);
            }
            //return Redirect("/Auth");
            return Redirect("/auth/logout");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel obj)
        {
            provider.Member.Add(new Member {
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
            Member member = provider.Member.Login(obj);
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
                List<Role> roles = provider.Role.GetRolesByMemberId(member.Id);
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
