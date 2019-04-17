using GW.BLL.Models;
using GW.BLL.Services;
using GW.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace GW.WebUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUnitOfWorkAddress unitOfWorkAddress;
        public AddressController(IUnitOfWorkAddress unitOfWorkAddress)
        {
            this.unitOfWorkAddress = unitOfWorkAddress;
        }
        // GET: Address
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
           
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Adresses(int currentpage = 1)
        {
            PagingInfo paging = new PagingInfo
            {
                CurrentPage = currentpage,
                TotalItems = unitOfWorkAddress.AddressService.GetAll().Count(),
                ItemsPerPage = 10
            };
            ViewBag.paging = paging;

            var model = unitOfWorkAddress.AddressService.GetAll().OrderBy(a => a.StreetName)
                .Skip((paging.CurrentPage - 1) * paging.ItemsPerPage).Take(paging.ItemsPerPage);
            return PartialView(model);
        }

        // GET: Address/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var model = unitOfWorkAddress.AddressService.Find(id);
            return View(model);
        }

        // GET: Address/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new AddressDTO();
            return View(model);
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(AddressDTO address)
        {
            try
            {
                // TODO: Add insert logic here
                unitOfWorkAddress.AddressService.Add(address);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = unitOfWorkAddress.AddressService.Find(id);
            return View(model);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(AddressDTO address, FormCollection collection)
        {
            using (unitOfWorkAddress.Transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    // TODO: Add update logic here
                    unitOfWorkAddress.AddressService.Update(address);
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

        // GET: Address/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                unitOfWorkAddress.AddressService.Delete(unitOfWorkAddress.AddressService.Find(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
