﻿using System;
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
    public class clientesController : ApiController
    {
        private estudoangularEntities db = new estudoangularEntities();

        // GET: api/clientes
        public IQueryable<cliente> Getcliente()
        {
            return db.cliente;
        }

        // GET: api/clientes/5
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Getcliente(int id)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcliente(int id, cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;
            cliente.dataCadastro = DateTime.Today;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
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

        // POST: api/clientes
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Postcliente(cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cliente.dataCadastro = DateTime.Today;
            db.cliente.Add(cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/clientes/5
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Deletecliente(int id)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clienteExists(int id)
        {
            return db.cliente.Count(e => e.Id == id) > 0;
        }
    }
}