namespace CompanySystem.Web
{
    using System.Data.Entity;
    using CompanySystem.Data;
    using CompanySystem.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initizlize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanySystemDbContext, Configuration>());
        }
    }
}