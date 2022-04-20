using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi_Crud.Models;

namespace WebApi_Crud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        Web_Api_Crud_DBEntities db = new Web_Api_Crud_DBEntities();
        HttpClient client = new HttpClient();
        public ActionResult Emp()
        {
            //  List<Employee> lst = new List<Employee>();
            //  client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            //var response=  client.GetAsync("CrudApi");
            //  response.Wait();
            //  var test = response.Result;
            //  if(test.IsSuccessStatusCode)
            //  {
            //      var display = test.Content.ReadAsAsync <List<Employee>> ();
            //      display.Wait();
            //      lst = display.Result;
            //  }
            // return View(lst);

            List<Employee> list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            var res = client.GetAsync("CrudApi");
            res.Wait();
            var test = res.Result;
            if(test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<List<Employee>>();
                dis.Wait();
                list = dis.Result;
            }
            return View(list);

        }
        [HttpGet]
        public ActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creat(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            var resp = client.PostAsJsonAsync<Employee>("CrudApi", emp);
            resp.Wait();
            var test = resp.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Emp");
            }
            return View("Creat");
        }
        public ActionResult Details(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            var resp = client.GetAsync("CrudApi?id="+id);
            resp.Wait();
            var test = resp.Result;
            if(test.IsSuccessStatusCode)
            {
                var disp = test.Content.ReadAsAsync<Employee>();
                 e = disp.Result;
            }

            return View(e);
        }

        public ActionResult Edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            var resp = client.GetAsync("CrudApi?id=" + id);
            resp.Wait();
            var test = resp.Result;
            if (test.IsSuccessStatusCode)
            {
                var disp = test.Content.ReadAsAsync<Employee>();
                e = disp.Result;
            }

            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            var res = client.PutAsJsonAsync <Employee>("CrudApi", e);
            res.Wait();
           var test= res.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Emp");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44366/api/CrudApi");
            var res = client.DeleteAsync("CrudApi?id="+id);
            res.Wait();
            var test = res.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Emp");
            }
            return View("Emp");
        }
        public ActionResult email()
        {
            return View();
        }
        public ActionResult email2()
        {
            return View();
        }
    }
}
