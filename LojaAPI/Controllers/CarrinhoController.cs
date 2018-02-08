﻿using LojaAPI.DAO;
using LojaAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var dao = new CarrinhoDAO();
                var carrinho = dao.Busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("O carrinho {0} não foi encontrado", id);
                var error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }            
        }

        public HttpResponseMessage Post([FromBody] Carrinho carrinho)
        {
            var dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);

            var response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        [Route("api/carrinho/{idCarrinho}/produto/{idProduto}")]
        public HttpResponseMessage Delete([FromUri] int idCarrinho, [FromUri] int idProduto)
        {
            var dao = new CarrinhoDAO();
            var carrinho = dao.Busca(idCarrinho);
            carrinho.Remove(idProduto);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
