namespace CompanySystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using CompanySystem.Data;
    using CompanySystem.Models;
    using CompanySystem.Utilities;

    public class DataController : BaseController
    {
        public DataController(ICompanySystemData data) 
            : base(data)
        {
        }

        [HttpGet]
        public JsonResult Get()
        {
            var data = Data.Employees.All().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Post(Employee employee)
        {
            if (ModelState.IsValid && ValidateIsEmployeeDataCorrect(employee))
            {
                Data.Employees.Add(employee);
                Data.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(Employee employee)
        {
            if (ModelState.IsValid && ValidateIsEmployeeDataCorrect(employee))
            {
                Data.Employees.Update(employee);
                Data.SaveChanges();
            }
        }

        [HttpDelete]
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
            else if (!Validator.EmailIsValid(employee.Email))
            {
                result = false;
            }

            return result;
        }
    }
}
