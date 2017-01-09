namespace CompanySystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using CompanySystem.Models;

    public interface ICompanySystemDbContext : IDisposable
    {
        IDbSet<Employee> Employees { get; set; }
        
        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}