
namespace CompanySystem.Data.Repositories
{
    using CompanySystem.Models;

    public class EmployeesRepository : GenericRepository<Employee>, IRepository<Employee>
    {
        public EmployeesRepository(ICompanySystemDbContext context)
            : base(context)
        {
        }
    }
}