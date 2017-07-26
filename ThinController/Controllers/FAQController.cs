using System.Web.Mvc;
using StructureMap;
using ThinController.FormHandlers;
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

        // Can be used when a new FaqItem is posted back.
        public ActionResult Index(FaqViewModel model)
        {
            return ProcessValidResult(
                model,
                new CreateFaqFormHandler(),
                viewModel => Redirect(Url.Content("/")),
                viewModel => View(viewModel));
        }
    }
}