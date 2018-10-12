using System.Web.Mvc;

namespace ReservarSalaoFestas.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            SemearDados S = new SemearDados();
            return View();
        }

        // GET: Default/Details/5
        public ActionResult Sobre()
        {
            return View();
        }
    }
}
