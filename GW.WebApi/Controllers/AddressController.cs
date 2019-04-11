using GW.BLL.Models;
using GW.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GW.WebApi.Controllers
{
    public class AddressController : ApiController
    {
        IGenericService<AddressDTO> addressService;
        public AddressController(IGenericService<AddressDTO> addressService)
        {
            this.addressService = addressService;
        }

        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, addressService.GetAll());
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить адрес");
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var address = addressService.Find(id);
                return (address != null) ? Request.CreateResponse(HttpStatusCode.OK, address)
                    : Request.CreateResponse(HttpStatusCode.NotFound, $"Не найден адрес = {id}"); ;
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Не смогли получить  адрес = {id}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(AddressDTO address)
        {
            try
            {
                addressService.Add(address);
                return Request.CreateResponse(HttpStatusCode.OK, address);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить адрес");
            }
        }
    }
}
