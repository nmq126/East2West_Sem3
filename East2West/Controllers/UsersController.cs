using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using East2West.Data;
using East2West.Models;
using PagedList;

namespace East2West.Controllers
{
    public class UsersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Users
        public ActionResult Index(int? status, string id, string sortType, string username, string firstName,
            string lastName, string address, int? roleId, int? page, int? order)
        {
            ViewBag.BreadCrumb = "User List";
            var users = db.Users.Include(u => u.Orders);
            ViewBag.Status = status;
            ViewBag.Id = id;
            ViewBag.SortType = sortType;
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.Address = address;
            ViewBag.Username = username;
            ViewBag.RoleId = roleId;
            ViewBag.Order = order;
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            if (!String.IsNullOrEmpty(id))
            {
                users = users.Where(x => x.Id.Contains(id));
            }
            if (!String.IsNullOrEmpty(username))
            {
                users = users.Where(x => x.UserName.Contains(username));
            }
            if (!String.IsNullOrEmpty(lastName))
            {
                users = users.Where(x => x.LastName.Contains(lastName));
            }
            if (!String.IsNullOrEmpty(firstName))
            {
                users = users.Where(x => x.FirstName.Contains(firstName));
            }
            if (!String.IsNullOrEmpty(address))
            {
                users = users.Where(x => x.Address.Contains(address));
            }

            switch (status)
            {
                case 2:
                    break;
                case 1:
                    users = users.Where(t => t.Status == 1);
                    break;
                case 0:
                    users = users.Where(t => t.Status == 0);
                    break;
                default:
                    break;
            }

            switch (order)
            {
                case 3:
                    break;
                case 2:
                    users = users.Where(u => u.Orders.Where(o => o.Status == 1).Count() >= 10);
                    break;
                case 1:
                    users = users.Where(u => u.Orders.Where(o => o.Status == 1).Count() < 10 && u.Orders.Where(o => o.Status == 1).Count() > 0);
                    break;
                case 0:
                    users = users.Where(u => u.Orders.Where(o => o.Status == 1).Count() == 0);
                    break;
                default:
                    break;
            }

            switch (sortType)
            {
                case "createdAt_asc":
                    users = users.OrderBy(s => s.CreatedAt);
                    break;
                case "createdAt_desc":
                    users = users.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    users = users.OrderByDescending(s => s.CreatedAt);
                    break;
            }

            return View(users.ToPagedList(pageNumber, pageSize));
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Include(u => u.Orders).Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            var orders = user.Orders;
            if (orders != null)
            {
                ViewBag.OrderPlaced = orders.OrderByDescending(o => o.CreatedAt).ToPagedList(1, 10);

            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Password,Address,Thumbnail,Description,Status,CreatedAt,UpdatedAt,DeletedAt,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                user.UpdatedAt = DateTime.Now;
                try
                {
                    db.SaveChanges();
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

                return RedirectToAction("Index");
            }
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
