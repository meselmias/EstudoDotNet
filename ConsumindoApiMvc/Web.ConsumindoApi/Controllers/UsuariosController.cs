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
    public class UsuariosController : Controller
    {
        HttpClient client = new HttpClient();

        public UsuariosController()
        {
            client.BaseAddress = new Uri("http://localhost:51010/api/Usuarios");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            HttpResponseMessage response = client.GetAsync("/api/Usuarios/listaUsuarios").Result;
            if (response.IsSuccessStatusCode)
            {
                usuarios = response.Content.ReadAsAsync<List<Usuario>>().Result;
            }

            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Usuarios/{id}").Result;
            Usuario usuario = response.Content.ReadAsAsync<Usuario>().Result;
            if (usuario != null)
                return View(usuario);
            else
                return HttpNotFound();         
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {

                HttpResponseMessage response = client.PostAsJsonAsync<Usuario>("/api/Usuarios", usuario).Result;
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

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Usuarios/{id}").Result;
            Usuario usuario = response.Content.ReadAsAsync<Usuario>().Result;
            if (usuario != null)
                return View(usuario);
            else
                return HttpNotFound();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync<Usuario>($"/api/Usuarios/{id}", usuario).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro ao Editar Usuario";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/api/Usuarios/{id}").Result;
            Usuario usuario = response.Content.ReadAsAsync<Usuario>().Result;
            if (usuario != null)
                return View(usuario);
            else
                return HttpNotFound();         
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuario usuario)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"/api/Usuarios/{id}").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                  return RedirectToAction("Index");
                }
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
