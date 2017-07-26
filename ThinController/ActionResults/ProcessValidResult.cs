using System;
using System.Web.Mvc;

namespace ThinController.ActionResults
{
    public class ProcessValidResult<T> : ActionResult
    {
        protected readonly T Model;

        public IGeneralFormHandler<T> Handler { get; set; }
        public Func<T, ActionResult> SuccessResult;
        public Func<T, ActionResult> FailureResult;

        public ProcessValidResult(T model)
        {
            Model = model;
        }

        public ProcessValidResult(T model,
            IGeneralFormHandler<T> handler,
            Func<T, ActionResult> successResult,
            Func<T, ActionResult> failureResult)
        {
            Model = model;
            Handler = handler;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var viewData = context.Controller.ViewData;

            if (viewData.ModelState.IsValid)
            {
                Handler.ProcessForm(context, Model);
                SuccessResult(Model).ExecuteResult(context);
            }
            else
            {
                FailureResult(Model).ExecuteResult(context);
            }
        }
    }
}