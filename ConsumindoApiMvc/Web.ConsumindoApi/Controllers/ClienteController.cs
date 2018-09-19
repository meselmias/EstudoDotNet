using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.ConsumindoApi.Models;

namespace Web.ConsumindoApi.Controllers
{
    public class ClienteController : Controller
    {
        HttpClient client = new HttpClient();

        public ClienteController()
        {
            client.BaseAddress = new Uri("http://localhost:51160/api/Clientes");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            HttpResponseMessage response = client.GetAsync("/api/Clientes").Result;
            if (response.IsSuccessStatusCode)
            {
                clientes = response.Content.ReadAsAsync<List<Cliente>>().Result;
            }

            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Clientes/{id}").Result;
            Cliente cliente = response.Content.ReadAsAsync<Cliente>().Result;
            if (cliente != null)
                return View(cliente);
            else
                return HttpNotFound();

        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {

            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync<Cliente>("/api/clientes", cliente).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro ao criar cliente";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/clientes/{id}").Result;
            Cliente cliente = response.Content.ReadAsAsync<Cliente>().Result;
            if (cliente != null)
                return View(cliente);
            else
                return HttpNotFound();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync<Cliente>($"/api/clientes/{id}", cliente).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro ao criar cliente";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/clientes/{id}").Result;
            Cliente cliente = response.Content.ReadAsAsync<Cliente>().Result;
            if (cliente != null)
                return View(cliente);
            else
                return HttpNotFound();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {

            try
            {
                // TODO: Add delete logic here

                HttpResponseMessage response = client.DeleteAsync($"/api/clientes/{id}").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Error = "Erro ao excluir registro";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
