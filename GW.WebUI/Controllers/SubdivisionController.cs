using GW.BLL.Models;
using GW.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace GW.WebUI.Controllers
{
    public class SubdivisionController : Controller
    {
        private readonly IUnitOfWorkAddress unitOfWorkAddress;

        public SubdivisionController(IUnitOfWorkAddress unitOfWorkAddress)
        {
            this.unitOfWorkAddress = unitOfWorkAddress;
        }
        // GET: Subdivision
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = unitOfWorkAddress.SubdivisionService.GetAll();
            return View(model);
        }

        // GET: Subdivision/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var model = unitOfWorkAddress.SubdivisionService.Find(id);
            return View(model);
        }

        // GET: Subdivision/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new SubdivisionDTO();
            return View(model);
        }

        // POST: Subdivision/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(SubdivisionDTO subdivision,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                unitOfWorkAddress.SubdivisionService.Add(subdivision);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subdivision/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = unitOfWorkAddress.SubdivisionService.Find(id);
            return View(model);
        }

        // POST: Subdivision/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(SubdivisionDTO subdivision, FormCollection collection)
        {
            using (unitOfWorkAddress.Transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    // TODO: Add update logic here
                    unitOfWorkAddress.SubdivisionService.Update(subdivision);
                    unitOfWorkAddress.Commit();
                    return RedirectToAction("Index");
                }
                catch
                {
                    unitOfWorkAddress.Rollback();
                }
            }
            return View();
        }

        // GET: Subdivision/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subdivision/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                unitOfWorkAddress.SubdivisionService.Delete(unitOfWorkAddress.SubdivisionService.Find(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
