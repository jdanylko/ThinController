using System.Web.Mvc;
using ThinController.ActionResults;
using ThinController.EntityFramework;
using ThinController.Extensions;
using ThinController.Infrastructure;
using ThinController.Models;

namespace ThinController.FormHandlers
{
    public class CreateFaqFormHandler : IGeneralFormHandler<FaqViewModel>
    {
        public bool ProcessForm(ControllerContext context, FaqViewModel viewModel)
        {
            var dbContext = context.GetDbContext<DemoDbContext>();
            var result = false;
            try
            {
                // dbContext.FAQs.Add(viewModel.FaqItem);
                // dbContext.SaveChanges();
            }
            finally
            {
                result = true;
            }
            /* 
             * If you want, you can have your success page display a message to the user.
             *   context.Controller.TempData["Message"] = 
                     viewModel.Faq.Question + " has been successfully saved.";
             * */

            return result;
        }
    }
}