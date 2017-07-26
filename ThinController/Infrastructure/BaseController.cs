using System;
using System.Web.Mvc;
using StructureMap;
using ThinController.ActionResults;

namespace ThinController.Infrastructure
{
    public class BaseController : Controller
    {
        public IContainer Container { get; set; }

        public BaseController(IContainer container)
        {
            if (container == null)
            {
                throw new Exception("Invalid reference to a container (Container is null).");
            }

            Container = container;
        }

        public ActionResult ProcessValidResult<T>(T model,
            IGeneralFormHandler<T> handler,
            Func<T, ActionResult> successResult,
            Func<T, ActionResult> failureResult)
        {
            return new ProcessValidResult<T>(model, handler, 
                successResult, failureResult);
        }

        public ActionResult ProcessResult<T>(T model,
            IGeneralFormHandler<T> handler,
            Func<T, ActionResult> successResult,
            Func<T, ActionResult> failureResult)
        {
            return new ProcessResult<T>(model, handler, 
                successResult, failureResult);
        }
    }
}