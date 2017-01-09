namespace CompanySystem.Web.Controllers
{
    using System.Web.Mvc;
    using CompanySystem.Data;

    public class HomeController : BaseController
    {
        public HomeController(ICompanySystemData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
