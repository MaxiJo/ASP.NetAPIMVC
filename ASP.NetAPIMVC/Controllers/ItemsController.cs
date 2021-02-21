using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASP.NetAPIMVC.Controllers
{
    public class ItemsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44387/API/")
        };
        // GET: Items
        public ActionResult Index()
        {
            IEnumerable<SupplierItem> SupplierItems = null;
            var respondTask = client.GetAsync("Items");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SupplierItem>>();
                readTask.Wait();
                SupplierItems = readTask.Result;
            }
            return View(SupplierItems);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item item)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Items", item).Result;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            IEnumerable<SupplierItem> SupplierItem = null;
            var responseTask = client.GetAsync("Items/" + Id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SupplierItem>>();
                readTask.Wait();

                SupplierItem = readTask.Result;
            }
            return View(SupplierItem.FirstOrDefault(i => i.id == Id));
        }
        public ActionResult Edit(int id)
        {
            IEnumerable<SupplierItem> SupplierItems = null;
            //HTTP GET
            var responseTask = client.GetAsync("Items?id=" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SupplierItem>>();
                readTask.Wait();

                SupplierItems = readTask.Result;
            }
            return View(SupplierItems.FirstOrDefault(i => i.id == id));
        }
        [HttpPost]
        public ActionResult Edit(Item item,int id)
        {
            SupplierItem sI = new SupplierItem();
            item.id = id;
            item.nama = sI.nama;
            item.price = sI.price;
            item.quantity = sI.quantity;
            item.supplierId = sI.supplierId;
            var putTask = client.PutAsJsonAsync<Item>("Items/" + item.id, item);
            putTask.Wait();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            IEnumerable<SupplierItem> items = null;
            var responseTask = client.GetAsync("Items/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SupplierItem>>();
                readTask.Wait();

                items = readTask.Result;
            }
            return View(items.FirstOrDefault(i => i.id == id));
        }
        [HttpPost]
        public ActionResult Delete(Item item, int id)
        {
            var deleteTask = client.DeleteAsync("Items/" + id);
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