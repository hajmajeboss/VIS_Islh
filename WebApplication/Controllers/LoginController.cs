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
        private AuthService auth;

        public LoginController(IStorageContext db, AuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        public IActionResult Index()
        {
            auth.User = null;
            return View(new LoginForm());
        }

        [HttpPost]
        public IActionResult Index(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                Uzivatel uzivatel = new Uzivatel { Username = form.Username, Password = Hash.GenerateSha1(form.Password) };
                UzivatelTableModule uzivatelTableModule = new UzivatelTableModule(db);
                Uzivatel signedUser = uzivatelTableModule.TrySignIn(uzivatel);
                if (signedUser != null)
                {
                    auth.User = signedUser;
                    return RedirectToAction("Index", "MainMenu");
                }
                else
                {
                    ModelState.AddModelError("Password", "Přihlášení se nezdařilo.");
                }
            }

            return View(form);
        }
    }
}