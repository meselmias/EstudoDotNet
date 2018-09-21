using API.ConsumindoApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.ConsumindoApiMVC.Controllers
{
    public class ProdutosController : ApiController
    {
        private estudoContext db = new estudoContext();

        //api/Produtos/listarProdutos   
        public IQueryable<Produto> GetProdutos()
        {
            return db.Produtos;
        }

        // POST: api/produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult Cadastrar(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtos.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }



    }
}
