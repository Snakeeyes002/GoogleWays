using GW.BLL.Models;
using GW.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GW.WebUI.Controllers
{
    public class AddressController : Controller
    {
        IGenericService<AddressDTO> addressService;
        public AddressController(IGenericService<AddressDTO> addressService)
        {
            this.addressService = addressService;
        }
        // GET: Address
        public ActionResult Index()
        {
            var model = addressService.GetAll();
            return View(model);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            var model = addressService.Find(id);
            return View(model);
        }

        // GET: Address/Create
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
                addressService.Add(address);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var model = addressService.Find(id);
            return View(model);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(AddressDTO address, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                addressService.Update(address);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
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
                addressService.Delete(addressService.Find(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
