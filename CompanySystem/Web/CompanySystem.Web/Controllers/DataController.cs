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
using CompanySystem.Utilities;
using Microsoft.Ajax.Utilities;
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
            if (ModelState.IsValid && ValidateIsEmployeeDataCorrect(employee))
            {
                Data.Employees.Add(employee);
                Data.SaveChanges();
            }
        }

        [System.Web.Mvc.HttpPut]
        public void Put(Employee employee)
        {
            if (ModelState.IsValid && ValidateIsEmployeeDataCorrect(employee))
            {
                Data.Employees.Update(employee);
                Data.SaveChanges();
            }
        }

        [System.Web.Mvc.HttpDelete]
        public void Delete(int id)
        {
            Employee employee = Data.Employees.All().First(e => e.Id == id);
            if (employee != null)
            {
                Data.Employees.Delete(employee);
                Data.SaveChanges();
            }
        }

        private bool ValidateIsEmployeeDataCorrect(Employee employee)
        {
            bool result = true;

            if (string.IsNullOrEmpty(employee.FirstName))
            {
                result = false;
            }
            else if (string.IsNullOrEmpty(employee.LastName))
            {
                result = false;
            }
            else if (employee.Age < 15)
            {
                result = false;
            }
            else if (Validator.EmailIsValid(employee.Email))
            {
                result = false;
            }

            return result;
        }
    }
}
