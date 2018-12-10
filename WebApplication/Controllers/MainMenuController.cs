using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class MainMenuController : Controller
    {
        private IStorageContext db;
        private AuthService auth;

        public MainMenuController(IStorageContext db, AuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        public IActionResult Index()
        {
            if (auth.User != null)
            {
                ViewData["UserInfo"] = auth.User.Jmeno + ", " + auth.User.Email;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}