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
        private readonly IGenericService<AddressDTO> addressService;
        public HomeController(IGenericService<AddressDTO> addressService)
        {
            this.addressService = addressService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Test()
        {
            var model = addressService.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "User")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}