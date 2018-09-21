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
    public class ProdutosController : Controller
    {
        HttpClient client = new HttpClient();

        public ProdutosController()
        {
            client.BaseAddress = new Uri("http://localhost:51010/api/Produtos");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: Produtos
        public ActionResult Index()
        {
            List<Produto> produtos = new List<Produto>();
            HttpResponseMessage response = client.GetAsync("/api/Produtos").Result;
            if (response.IsSuccessStatusCode)
            {
                produtos = response.Content.ReadAsAsync<List<Produto>>().Result;
            }

            return View(produtos);
         
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync<Produto>("/api/Produtos", produto).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.erro = "Não foi possível realizar o cadastro";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
