using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using Unities;
using Utilities;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            //var list = await UsersBL.Instance.FindAll();
            UserUtility userUtility = new UserUtility();
            userUtility.Gender = 2;            
            var list = await UsersBL.Instance.FindByFilter(userUtility.ToFilterDefinition());
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Profile profile)
        {
            var user = new User(profile);
            await UsersBL.Instance.Create(user);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string id)
        {

            var user = await UsersBL.Instance.FindById(id);
            return View(user.Profile);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(string id, Profile profile)
        {
            var user = await UsersBL.Instance.FindById(id);
            user.Profile = profile;
            await UsersBL.Instance.Save(user);
            return RedirectToAction("Index");
        }
    }
}