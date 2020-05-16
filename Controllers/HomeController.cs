using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DBQWebsite.Models;
using Microsoft.AspNetCore.Identity;
using DBQWebsite.Data;

namespace DBQWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DBQContext _context;
        public HomeController(DBQContext context, RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;

            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddUser(string email, string state)
        {
            var policyNumber = GenerateRandomAlphanumeric.GenerateRandomAlphanumericString(5);
            var user = new IdentityUser
            {
                UserName = policyNumber,
                Email = email,

            };

            var pwdGen1 = new PasswordGenerator.Password();
            string password1 = pwdGen1.Next();
            var result = await _userManager.CreateAsync(user, password1);
           
            if (result.Succeeded)
            {
                return Json(user.UserName);
              
            }
            else
            {
                var emailExist = "emailExist";
                return Json(emailExist);
            }
         

           

           
        }

        [HttpGet]
        public IActionResult AddDog(PolicyDog dogQuestions)
        {
            if (dogQuestions.Name != null)
            {
                _context.PolicyDog.Add(dogQuestions);
               _context.SaveChanges();
            }

        
            return Json("OK");
        }

       

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Portal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return View("Portal");
                }
                else
                {
                    return View("Portal");
                }

            }
            else
            {
                return View("Portal");
            }


        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password)
        {


            var user = new IdentityUser
            {
                UserName = username,
                Email = email,

            };

            var result = await _userManager.CreateAsync(user, password);


            if (result.Succeeded)
            {
                var resultss = await _userManager.AddToRoleAsync(user, "Admin");
                if (resultss.Succeeded)
                {
                    try
                    {
                       

                        
                            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var callbackUrl = Url.Action("ConfirmEmail", "Home", new { userId = user.Id, code = token }, protocol: Url.ActionContext.HttpContext.Request.Scheme);
                            //EmailRegisterConfirm confirm = new EmailRegisterConfirm("ronniej491@gmail.com", callbackUrl);
                            return View("Login");
                      
                    }
                    catch (System.Exception ex)
                    {

                        throw;
                    }



                }

                return View("Failed");

            }

            else
            {
                return View("Index");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
