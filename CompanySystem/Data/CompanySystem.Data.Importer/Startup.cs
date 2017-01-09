namespace CompanySystem.Data.Importer
{
    public class Startup
    {
        static void Main()
        {
            DataImporter.Instance().Import();
        }
    }
}
