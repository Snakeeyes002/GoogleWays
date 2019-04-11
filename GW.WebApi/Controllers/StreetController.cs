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
    public class StreetController : ApiController
    {
        IGenericService<StreetDTO> streetService;
        public StreetController(IGenericService<StreetDTO> streetService)
        {
            this.streetService = streetService;
        }

        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, streetService.GetAll());
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
                var address = streetService.Find(id);
                return (address != null) ? Request.CreateResponse(HttpStatusCode.OK, address)
                    : Request.CreateResponse(HttpStatusCode.NotFound, $"Не найдена улица = {id}"); ;
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Не смогли найти улицу = {id}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(StreetDTO street)
        {
            try
            {
                streetService.Add(street);
                return Request.CreateResponse(HttpStatusCode.OK, street);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить адрес");
            }
        }
    }
}
