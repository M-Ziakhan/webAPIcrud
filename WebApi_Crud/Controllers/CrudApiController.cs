using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Crud.Models;

namespace WebApi_Crud.Controllers
{
   
    public class CrudApiController : ApiController
    {
        Web_Api_Crud_DBEntities db = new Web_Api_Crud_DBEntities();
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);

        }

        public IHttpActionResult GetEmployeeByID(int id)
        {
            //List<Employee> list = db.Employees.ToList();
            var emp = db.Employees.Where(x => x.id == id).FirstOrDefault();
            return Ok(emp);

        }
        [HttpPut]
        public IHttpActionResult GetEmployeeByID(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var emp = db.Employees.Where(x => x.id == id).FirstOrDefault();
            if(emp !=null)
            {
               db.Entry(emp).State = EntityState.Deleted;

            }
            db.SaveChanges();
            return Ok();

        }
        [HttpPost]
        public IHttpActionResult GetEmployee(Employee em)
        {
            db.Employees.Add(em);
            db.SaveChanges();
            return Ok();

        }
    }
}
