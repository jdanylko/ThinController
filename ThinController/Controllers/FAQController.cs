using System.Web.Mvc;
using StructureMap;
using ThinController.Infrastructure;
using ThinController.Models;

namespace ThinController.Controllers
{
    public class FaqController : BaseController
    {
        private DefaultViewModelFactory _factory;

        public FaqController() : this(new DefaultViewModelFactory()) { }

        public FaqController(DefaultViewModelFactory factory, 
            IContainer container = null) : base(container)
        {
            _factory = factory;
        }

        // GET: FAQ
        public ActionResult Index()
        {
            return View(_factory.GetViewModel<FaqController, FaqViewModel>(this));
        }
    }
}