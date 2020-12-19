using ApiItemFila.Data.Interfaces.Services;
using ApiItemFila.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiItemFila.Application.Controllers
{
    public class ItemFilaController : ApiController
    {
        private readonly IService<Item> _service;

        private string _strConexao = string.Empty;

        public ItemFilaController(IService<Item> service)
        {
            _service = service;
            _strConexao = ConfigurationManager.ConnectionStrings["WiProItemFila"].ConnectionString;
        }

        [HttpPost]
        [Route("api/itemfila/additemfila")]
        public HttpResponseMessage AddItemFila([FromBody] List<Item> items)
        {
            try
            {
                foreach (var item in items)
                {
                    _service.Adicionar(item);
                }

                return Request.CreateResponse<List<Item>>(HttpStatusCode.OK, items);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $@"Erro ao Adicionar Item na fila! => {e.Message}");
            }
        }


        [HttpGet]
        [Route("api/itemfila/getitemfila")]
        public HttpResponseMessage GetItemFila()
        {
            try
            {
                Item item = _service.GetProxItem();
                return Request.CreateResponse<Item>(HttpStatusCode.OK, item);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $@"Erro ao buscar items na fila! => {e.Message}");
            }
        }
    }
}
