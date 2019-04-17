using GW.BLL.Models;
using GW.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GW.WebUI.Controllers
{
    public class StreetController : Controller
    {
        IGenericService<StreetDTO> streetService;

        public StreetController(IGenericService<StreetDTO> streetService)
        {
            this.streetService = streetService;
        }

        // GET: Street
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = streetService.GetAll();
            return View(model);
        }

        // GET: Street/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var model = streetService.Find(id);
            return View(model);
        }

        // GET: Street/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model =new StreetDTO();
            return View(model);
        }

        // POST: Street/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(StreetDTO street,
            FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                streetService.Add(street);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Street/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = streetService.Find(id);
            return View(model);
        }

        // POST: Street/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(StreetDTO street, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                streetService.Update(street);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Street/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Street/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                streetService.Delete(streetService.Find(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
