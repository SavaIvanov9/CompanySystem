namespace CompanySystem.Web.Controllers
{
    using System.Web.Mvc;
    using CompanySystem.Data;

    public class BaseController : Controller
    {
        protected BaseController(ICompanySystemData data)
        {
            this.Data = data;
        }

        protected ICompanySystemData Data { get; set; }
    }
}