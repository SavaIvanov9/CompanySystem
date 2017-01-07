namespace CompanySystem.Data
{
    using CompanySystem.Data.Repositories;

    public interface ICompanySystemData
    {
        EmployeesRepository Employees
        {
            get;
        }

        void SaveChanges();
    }
}
