namespace CompanySystem.Web.Controllers
{
    using System.Web.Mvc;

    using CompanySystem.Data;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Data = new CompanySystemData();
        }

        protected ICompanySystemData Data { get; set; }
    }
}