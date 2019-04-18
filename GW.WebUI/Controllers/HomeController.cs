using GW.BLL.Models;
using GW.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GW.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkAddress unitOfWorkAddress;
        public HomeController(IUnitOfWorkAddress unitOfWorkAddress)
        {
            this.unitOfWorkAddress = unitOfWorkAddress;
        }

        public ActionResult Index()
        {
            var model = unitOfWorkAddress.AddressService.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}