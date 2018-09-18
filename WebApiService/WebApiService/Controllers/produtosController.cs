using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    public class produtosController : ApiController
    {
        private estudoangularEntities db = new estudoangularEntities();

        // GET: api/produtos
        public List<produto> Getproduto()
        {
            List<produto> produtos = new List<produto>();
            produtos.Add(new produto
            {
                id = 1,
                nome = "notebook",
                descricao = "notebook dell",
                preco = "5.000,00",
                dataCadastro = DateTime.Today
                
            });
          

            return produtos;
        }

        // GET: api/produtos/5
        [ResponseType(typeof(produto))]
        public IHttpActionResult Getproduto(int id)
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproduto(int id, produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.id)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!produtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/produtos
        [ResponseType(typeof(produto))]
        public IHttpActionResult Postproduto(produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.produto.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.id }, produto);
        }

        // DELETE: api/produtos/5
        [ResponseType(typeof(produto))]
        public IHttpActionResult Deleteproduto(int id)
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.produto.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool produtoExists(int id)
        {
            return db.produto.Count(e => e.id == id) > 0;
        }
    }
}