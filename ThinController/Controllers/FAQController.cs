using System.Web.Mvc;
using ThinController.Infrastructure;
using ThinController.Models;

namespace ThinController.Controllers
{
    public class FaqController : Controller
    {
        // Removed
        // private readonly FaqRepository _repository = new FaqRepository();
        private DefaultViewModelFactory _factory = new DefaultViewModelFactory();

        // GET: FAQ
        public ActionResult Index()
        {
            return View(_factory.GetViewModel<FaqController, FaqViewModel>(this));
        }
    }
}