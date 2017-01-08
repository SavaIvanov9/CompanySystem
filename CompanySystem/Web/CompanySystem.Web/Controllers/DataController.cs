using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanySystem.Models;

namespace CompanySystem.Web.Controllers
{
    public class DataController : BaseController
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return Data.Employees.All().ToList();
        }

        public void Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Data.Employees.Add(employee);
                Data.SaveChanges();
            }
        }

        public void Put(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Data.Employees.Update(employee);
                Data.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Employee employee = Data.Employees.All().First(e => e.Id == id);
            if (employee != null)
            {
                Data.Employees.Delete(employee);
                Data.SaveChanges();
            }
        }
    }
}
