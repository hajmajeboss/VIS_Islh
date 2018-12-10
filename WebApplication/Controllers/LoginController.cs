using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {

        private IStorageContext db;

        public LoginController(IStorageContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(new LoginForm());
        }

        [HttpPost]
        public IActionResult Index(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                Uzivatel uzivatel = new Uzivatel { Username = form.Username, Password = form.Password };
                UzivatelTableModule uzivatelTableModule = new UzivatelTableModule(db);
                Uzivatel signedUser = uzivatelTableModule.TrySignIn(uzivatel);
                if (signedUser != null)
                {
                    return RedirectToAction("Index", "MainMenu");
                }
                else
                {
                    ModelState.AddModelError("ERR", "Přihlášení se nezdařilo.");
                }
            }

            return View(form);
        }
    }
}