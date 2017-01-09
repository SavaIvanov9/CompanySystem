using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using CompanySystem.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace CompanySystem.Web.Controllers
{
    public class DataController : BaseController
    {
        [System.Web.Mvc.HttpGet]
        //[Route("api/campaign/list")]
        public ActionResult Get()
        {
            return Json(Data.Employees.All().ToList(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public void Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Data.Employees.Add(employee);
                Data.SaveChanges();
            }
        }

        [System.Web.Mvc.HttpPut]
        public void Put(Employee employee)
        {
            //if (ModelState.IsValid)
            //{
                Data.Employees.Update(employee);
                Data.SaveChanges();
            //}
        }

        [System.Web.Mvc.HttpDelete]
        public void Delete(int id)
        {
            Employee employee = Data.Employees.All().First(e => e.Id == id);
            if (employee != null)
            {
                //var employees = Data.Employees.All().ToList();
                //var employeeToRemove = employees.First(e => e.Id == id);
                //employees.Remove(employeeToRemove);
                Data.Employees.Delete(employee);
                Data.SaveChanges();
            }
        }
    }
}
