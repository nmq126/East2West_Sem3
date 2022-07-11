using East2West.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class UserController : Controller
    {
        private Data.DBContext myIdentityDbContext;
        private UserManager<User> userManager;
        private RoleManager<AppRole> roleManager;

        // GET: User
        public UserController()
        {
            myIdentityDbContext = new Data.DBContext();
            UserStore<User> userStore = new UserStore<User>(myIdentityDbContext);
            userManager = new UserManager<User>(userStore);
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(myIdentityDbContext);
            roleManager = new RoleManager<AppRole>(roleStore);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User user)
        {
            do
            {
                user.Id = String.Concat("USER_", Guid.NewGuid().ToString("N").Substring(0, 5));
            } while (myIdentityDbContext.Users.FirstOrDefault(c => c.Id == user.Id) != null);
            user.CreatedAt = DateTime.Now;
            user.Status = 1;
            try
            {
                var result = await userManager.CreateAsync(user, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    return View("ViewError");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        [Authorize(Roles = "Super Admin")]
        public async Task<ActionResult> AddRole(string RoleName)
        {
            AppRole appRole = new AppRole()
            {
                Name = RoleName
            };
            var result = await roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return View("ViewSucceeded");
            }
            else
            {
                return View("ViewError");
            }
        }

        [Authorize(Roles = "Super Admin")]
        public async Task<String> AddUserToRole(string UserId, string RoleId)
        {
            var user = myIdentityDbContext.Users.Find(UserId);
            var role = myIdentityDbContext.Roles.Find(RoleId);
            if (role == null || user == null)
            {
                return "Bad Request";
            }
            var result = await userManager.AddToRoleAsync(user.Id, role.Name);
            if (result.Succeeded)
            {
                return "Role added successfully";
            }
            else
            {
                return "Action fail";
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindAsync(UserName, Password);
                if (user == null)
                {
                    ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");
                    return View();
                }
                else if (user.Status == 0)
                {
                    ModelState.AddModelError("LoginError", "Account locked! Contact our support to unlock.");
                    return View();
                }
                else
                {
                    SignInManager<User, string> signInManager = new SignInManager<User, string>(userManager, Request.GetOwinContext().Authentication);
                    await signInManager.SignInAsync(user, false, false);
                    string redirectUrl = (string)Session["currentUrl"];
                    if (String.IsNullOrEmpty(redirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (redirectUrl != null)
                    {
                        Session.Remove("currentUrl");
                        return Redirect(redirectUrl);
                    }
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAdmin(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindAsync(UserName, Password);
                if (user == null)
                {
                    ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");
                    return View();
                }
                else if (user.Status == 0)
                {
                    ModelState.AddModelError("LoginError", "Account locked! Contact our support to unlock.");
                    return View();
                }
                else
                {
                    SignInManager<User, string> signInManager = new SignInManager<User, string>(userManager, Request.GetOwinContext().Authentication);
                    await signInManager.SignInAsync(user, false, false);

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return RedirectToAction("LoginAdmin");
        }

        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOutAdmin()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("LoginAdmin", "User");
        }

        public ActionResult ShowInformation(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (id == null)
            {
                return RedirectToAction("Error404", "Home");
            }
            var user = myIdentityDbContext.Users.Include(u => u.Orders).Include("Orders.OrderTours").Include("Orders.OrderCars").Include("Orders.OrderCars.CarSchedule.Car.CarModel").FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return RedirectToAction("Error404", "Home");
            }
            return View(user);
        }
    }
}