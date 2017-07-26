using System.Web.Mvc;

namespace ThinController.ActionResults
{
    public interface IGeneralFormHandler<TModel>
    {
        bool ProcessForm(ControllerContext context, TModel model);
    }
}