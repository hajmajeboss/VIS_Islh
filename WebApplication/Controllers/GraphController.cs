using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class GraphController : Controller
    {
        IStorageContext db;
        AuthService auth;

        public GraphController(IStorageContext db, AuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        public IActionResult Index()
        {
            if (auth.User == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public IActionResult Holiny()
        {
            if (auth.User == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var holinaTableModule = new HolinaTableModule(db);
            var graphData = holinaTableModule.GetHolinyByYearArrays();
            ViewData["years"] = graphData[0];
            ViewData["counts"] = graphData[1];
            return View();
        }

        public IActionResult Zalesneni()
        {
            if (auth.User == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}