namespace CompanySystem.Data.Importer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using CompanySystem.Models;

    public class DataImporter
    {
        private static readonly Lazy<DataImporter> Lazy =
            new Lazy<DataImporter>(() => new DataImporter());

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DataImporter Instance() => Lazy.Value;

        public void Import()
        {
            Console.WriteLine("Press any key to continue and recreate database. Current data will be lost.");
            Console.ReadKey();

            Console.WriteLine(Environment.NewLine + "Creating new database...");
            var db = new CompanySystemData();
            Database.SetInitializer(new DropCreateDatabaseAlways<CompanySystemDbContext>());
            db.Employees.All().ToList();
            Console.WriteLine("Database recreated.");

            GenerateSomeFakeData(10);
        }

        private static void GenerateSomeFakeData(int count)
        {
            Console.WriteLine("Seeding fake data...");

            var db = new CompanySystemData();
            for (int i = 0; i < count; i++)
            {
                db.Employees.Add(new Employee
                {
                    FirstName = "SomeFirstName" + i,
                    LastName = "SomeLastName" + i,
                    Age = i + 20,
                    Email = $"somename{i}@fakemail.com"
                });

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                }
            }
            db.SaveChanges();

            Console.WriteLine($"{count} fake employees seeded.");
        }
    }
}
