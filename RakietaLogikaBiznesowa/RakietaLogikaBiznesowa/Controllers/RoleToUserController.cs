using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RakietaLogikaBiznesowa.Models;

namespace RakietaLogikaBiznesowa.Controllers
{
    public class RoleToUserController : Controller
    {
        private Model1 db = new Model1(); 

        // GET: RoleToUser
        public ActionResult Index()
        {
            //var UserRole = db.User;
            //var UserRole 

            return View();
        }
    }
}