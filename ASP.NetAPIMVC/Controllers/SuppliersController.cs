﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASP.NetAPIMVC.Controllers
{
    public class SuppliersController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44387/API/")
        };
        // GET: Suppliers
        public ActionResult Index()
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = client.GetAsync("Suppliers");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            return View(suppliers);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Suppliers", supplier).Result;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var responseTask = client.GetAsync("Suppliers/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();

                suppliers = readTask.Result;
            }
            return View(suppliers.FirstOrDefault(s => s.id == id));
        }
        public ActionResult Edit(int id)
        {
            IEnumerable<Supplier> suppliers= null;
            //HTTP GET
            var responseTask = client.GetAsync("Suppliers?id=" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();

                suppliers = readTask.Result;
            }
            return View(suppliers.FirstOrDefault(s=>s.id == id));
        }
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            var putTask = client.PutAsJsonAsync<Supplier>("Suppliers/"+ supplier.id, supplier);
            putTask.Wait();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var responseTask = client.GetAsync("Suppliers/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();

                suppliers = readTask.Result;
            }
            return View(suppliers.FirstOrDefault(s => s.id == id));
        }
        [HttpPost]
        public ActionResult Delete(Supplier supplier, int id)
        {
            var deleteTask = client.DeleteAsync("Suppliers/" + id);
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}