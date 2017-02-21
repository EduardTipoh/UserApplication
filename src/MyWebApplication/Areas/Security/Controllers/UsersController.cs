using MyWebApplication.Areas.Security.Models;
using MyWebApplication.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Areas.Security.Controllers
{
    public class UsersController : Controller
    {

        public UsersController()
        {
            {
                var genders = new List<SelectListItem> {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                }
            };
                ViewBag.Genders = genders;
            }
        }
       

               // GET: Security/User
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserModelView
                             {
                                 Id = user.Id,
                                 Name = user.Name,
                                 Age = user.Age,
                                 Gender = user.Gender
                             }).ToList();
                return View(users);
            }
        }

        // GET: Security/User/Details/5
        public ActionResult Details(int id)
        {
            return View(GetUser(id));
        }


        // GET: Security/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Security/User/Create
        [HttpPost]
        public ActionResult Create(UserModelView viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();

                using (var db = new DatabaseContext())
                {
                db.Users.Add(new User
                   {
                       // Id = Guid.NewGuid(),
                       Name = viewModel.Name,
                       Hobby = viewModel.Hobby,
                       Gender = viewModel.Gender,
                       Age = viewModel.Age
                   });
                     db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


          

        // GET: Security/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetUser(id));
        }

        // POST: Security/User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,UserModelView viewModel)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var edit = db.Users.FirstOrDefault(u => u.Id == id);
                    edit.Name = viewModel.Name;
                    edit.Hobby = viewModel.Hobby;
                    edit.Age = viewModel.Age;
                    edit.Gender = viewModel.Gender;

                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetUser(id));
        }

        // POST: Security/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new DatabaseContext())
            {
                var usr = db.Users.FirstOrDefault(u => u.Id == id);
                db.Users.Remove(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch
            {
                return View();
            }
        }
             private UserModelView GetUser(int id)
        {
            using (var db = new DatabaseContext())
            {
                return (from user in db.Users
                        where user.Id == id
                        select new UserModelView
                        {
                            Id = user.Id,
                           Name = user.Name,
                            Age = user.Age,
                            Gender = user.Gender
                        }).FirstOrDefault();

                //db.Users.Select(u => new UserViewModel { 
                //    Id = u.Id
                //}).FirstOrDefault(x => x.Id == id);
            }

        
        }
    }
}
