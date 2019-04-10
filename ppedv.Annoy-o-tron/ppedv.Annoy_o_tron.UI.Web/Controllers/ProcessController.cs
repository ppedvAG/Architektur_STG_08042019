using ppedv.Annoy_o_tron.Logic;
using ppedv.Annoy_o_tron.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.Annoy_o_tron.UI.Web.Controllers
{
    public class ProcessController : Controller
    {
        Core core = new Core();

        // GET: Process
        public ActionResult Index()
        {

            return View(core.UoW.ProcessRepository.GetAll());
        }

        // GET: Process/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UoW.ProcessRepository.GetById(id));
        }

        // GET: Process/Create
        public ActionResult Create()
        {
            return View(new Process() { Description = "NEU" });
        }

        // POST: Process/Create
        [HttpPost]
        public ActionResult Create(Process process)
        {
            try
            {
                core.UoW.ProcessRepository.Add(process);
                core.UoW.SaveAll();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Process/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.UoW.ProcessRepository.GetById(id));
        }

        // POST: Process/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Process proc)
        {
            try
            {
                core.UoW.ProcessRepository.Update(proc);
                core.UoW.SaveAll();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Process/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UoW.ProcessRepository.GetById(id));
        }

        // POST: Process/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var loaded = core.UoW.ProcessRepository.GetById(id);
                if (loaded != null)
                {
                    core.UoW.ProcessRepository.Delete(loaded);
                    core.UoW.SaveAll();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
