using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class LheController : Controller
    {
        private IStorageContext db;
        private AuthService auth;

        public LheController(IStorageContext db, AuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        public IActionResult Index()
        {
            LesniHospodarskaEvidenceTableModule module = new LesniHospodarskaEvidenceTableModule(db);
            List<LesniHospodarskaEvidence> lhes = module.LoadLhe(new PorostniSkupina { Id = "f6d514ef-f51f-4228-8bec-252c0113291f" });

            ViewData["lhes"] = lhes;
            return View();
        }

        public IActionResult AddEdit()
        {
            return View();
        }
    }
}