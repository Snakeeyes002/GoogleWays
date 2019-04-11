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
    public class SubdivisionController : ApiController
    {
        IGenericService<SubdivisionDTO> subdivisionService;

        public SubdivisionController(IGenericService<SubdivisionDTO> subService)
        {
            this.subdivisionService = subService;
        }

        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, subdivisionService.GetAll());
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
                var subdivision = subdivisionService.Find(id);
                return (subdivision != null) ? Request.CreateResponse(HttpStatusCode.OK, subdivision)
                    : Request.CreateResponse(HttpStatusCode.NotFound, $"Не найден адрес = {id}"); ;
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Не смогли получить  адрес = {id}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(SubdivisionDTO address)
        {
            try
            {
                subdivisionService.Add(address);
                return Request.CreateResponse(HttpStatusCode.OK, address);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить адрес");
            }
        }
    }
}
