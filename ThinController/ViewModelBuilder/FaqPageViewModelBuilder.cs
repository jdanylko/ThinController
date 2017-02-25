using ThinController.Controllers;
using ThinController.Interfaces;
using ThinController.Models;
using ThinController.Repository;

namespace ThinController.ViewModelBuilder
{
    public class FaqViewModelBuilder : IViewModelBuilder<FaqController, FaqViewModel>
    {
        public FaqViewModel Build(FaqController controller, FaqViewModel viewModel)
        {
            viewModel.PageTitle = "FAQ List";
            viewModel.MetaDescription = "This is the Frequently Asked Questions Page.";
            viewModel.MetaKeywords = "FAQ, New Questions, Old Questions, FAQ List";

            // If you have a unit of work with data access.
            // var unitOfWork = controller.ControllerContext.GetUnitOfWork<PrimaryUnitOfWork>();
            // var repository = unitOfWork.GetRepository<FaqRepository>();
            
            // Strictly demo purposes. :-)
            var repository = new FaqRepository();
            viewModel.FaqList = repository.GetAll();

            return viewModel;
        }
    }

}