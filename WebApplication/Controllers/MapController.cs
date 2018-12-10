using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class MapController : Controller
    {
        IStorageContext db;
        AuthService auth;

        public MapController(IStorageContext db, AuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        public IActionResult Holiny()
        {
            if (auth.User == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var holinaTableModule = new HolinaTableModule(db);
            ViewData["Holiny"] = holinaTableModule.LoadHoliny();
            ViewData["Desc"] = "  -  Mapa holin";
            return View();

        }
    }
}