using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySystem.Models;

namespace CompanySystem.Data.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new CompanySystemData();
            var e = db.Employees.All().Count();
            for (int i = 0; i < 5; i++)
            {
                db.Employees.Add(new Employee
                {
                    FirstName = "SomeFirstName" + i,
                    LastName = "SomeLastName" + i,
                    Age = i,
                    Email = $"fake{i}@somemail.com"
                });
            }
            db.SaveChanges();
        }
    }
}
