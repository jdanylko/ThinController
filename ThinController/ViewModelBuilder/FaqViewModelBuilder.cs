using System.Linq;
using ThinController.Controllers;
using ThinController.EntityFramework;
using ThinController.Extensions;
using ThinController.Interfaces;
using ThinController.Models;

namespace ThinController.ViewModelBuilder
{
    public class FaqViewModelBuilder : IViewModelBuilder<FaqController, FaqViewModel>
    {
        public FaqViewModelBuilder()
        {
            
        }

        public FaqViewModel Build(FaqController controller, FaqViewModel viewModel)
        {
            viewModel.PageTitle = "FAQ List";
            viewModel.MetaDescription = "This is the Frequently Asked Questions Page.";
            viewModel.MetaKeywords = "FAQ, New Questions, Old Questions, FAQ List";

            // If you have a unit of work with data access.
            var context = controller.ControllerContext.GetDbContext<DemoDbContext>();
            viewModel.FaqList = context.FAQs.ToList();

            return viewModel;
        }
    }

}