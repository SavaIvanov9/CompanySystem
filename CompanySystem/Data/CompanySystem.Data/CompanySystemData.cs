namespace CompanySystem.Data
{
    using System;
    using System.Collections.Generic;

    using CompanySystem.Data.Repositories;
    using CompanySystem.Models;

    public class CompanySystemData : ICompanySystemData
    {
        private readonly ICompanySystemDbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public CompanySystemData() 
            : this(new CompanySystemDbContext())
        {

        }

        public CompanySystemData(ICompanySystemDbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public EmployeesRepository Employees
        {
            get
            {
                return (EmployeesRepository)this.GetRepository<Employee>();
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);

            if (!this._repositories.ContainsKey(repositoryType))
            {
                var type = typeof(GenericRepository<T>);

                if (repositoryType.IsAssignableFrom(typeof(Employee)))
                {
                    type = typeof(EmployeesRepository);
                }

                this._repositories.Add(repositoryType, Activator.CreateInstance(type, this._context));
            }

            return (IRepository<T>)this._repositories[repositoryType];
        }
    }
}
