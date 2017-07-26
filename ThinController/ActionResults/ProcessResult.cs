using System;
using System.Web.Mvc;

namespace ThinController.ActionResults
{
    public class ProcessResult<T> : ActionResult
    {
        protected readonly T Model;

        public IGeneralFormHandler<T> Handler { get; set; }
        public Func<T, ActionResult> SuccessResult;
        public Func<T, ActionResult> FailureResult;

        public ProcessResult(T model)
        {
            Model = model;
        }

        public ProcessResult(T model,
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
            if (Handler.ProcessForm(context, Model))
            {
                SuccessResult(Model).ExecuteResult(context);
            }
            else
            {
                FailureResult(Model).ExecuteResult(context);
            }
        }
    }

}
