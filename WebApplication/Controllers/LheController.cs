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

        public IActionResult Add()
        {
            return View(new LheForm { Id = DateTime.Now.ToBinary().ToString(), Datum = DateTime.Now });
        }

        [HttpPost]
        public IActionResult Add(LheForm lheForm)
        {
            if (ModelState.IsValid)
            {
                var module = new LesniHospodarskaEvidenceTableModule(db);
                var lhe = new LesniHospodarskaEvidence
                {
                    Datum = lheForm.Datum,
                    Mnozstvi = lheForm.Mnozstvi,
                    Plocha = lheForm.Plocha,
                    Poznamka = lheForm.Poznamka,
                    IdPorostniSkupina = "f6d514ef-f51f-4228-8bec-252c0113291f",
                    IdPodvykon = "141_0",
                    IdDrevina = "98B80C09988C407C855302ED924A59FC",
                    IdDruhTezby = "AFE2719213AD4AFD8118C52654F8EE95",
                    Id = lheForm.Id
                };

                module.AddLhe(lhe);
                return RedirectToAction("Index");
            }
            else
            {
                return View(lheForm);
            }
        }

        public IActionResult Remove(string id)
        {
            var module = new LesniHospodarskaEvidenceTableModule(db);
            module.RemoveLhe(new LesniHospodarskaEvidence { Id = id});
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var module = new LesniHospodarskaEvidenceTableModule(db);
            var lhe = module.LoadOne(id);
            var form = new LheForm
            {
                Id = lhe.Id,
                Mnozstvi = lhe.Mnozstvi,
                Plocha = lhe.Plocha,
                Poznamka = lhe.Poznamka,
                Datum = lhe.Datum
            };

            return View(form);
        }

        [HttpPost]
        public IActionResult Edit(LheForm lheForm)
        {
            if (ModelState.IsValid)
            {
                var module = new LesniHospodarskaEvidenceTableModule(db);
                var ev = new LesniHospodarskaEvidence
                {
                    Datum = lheForm.Datum,
                    Mnozstvi = lheForm.Mnozstvi,
                    Plocha = lheForm.Plocha,
                    Poznamka = lheForm.Poznamka,
                    IdPorostniSkupina = "f6d514ef-f51f-4228-8bec-252c0113291f",
                    IdPodvykon = "141_0",
                    IdDrevina = "98B80C09988C407C855302ED924A59FC",
                    IdDruhTezby = "AFE2719213AD4AFD8118C52654F8EE95",
                    Id = lheForm.Id
                };

                module.UpdateLhe(ev);
                return RedirectToAction("Index");
            }
            else
            {
                return View(lheForm);
            }
        }
    }
}