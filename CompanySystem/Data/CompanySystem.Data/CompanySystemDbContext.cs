namespace CompanySystem.Data
{
    using System.Data.Entity;
    using CompanySystem.Data.Migrations;
    using CompanySystem.Models;

    public class CompanySystemDbContext : DbContext, ICompanySystemDbContext
    {
        public CompanySystemDbContext() : base("CompanySystemDb")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CompanySystemDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeArrivalTrackerDbContext>());
        }

        public virtual IDbSet<Employee> Employees { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}