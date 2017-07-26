using System;
using System.Data.Entity;
using System.Web.Mvc;
using ThinController.Infrastructure;

namespace ThinController.Extensions
{
    public static class ControllerContextExtension
    {
        public static T GetDbContext<T>(this ControllerContext webContext) where T : DbContext
        {
            var objectContextKey = String.Format("{0}-{1}", typeof(T),
                webContext.GetHashCode().ToString("x"));

            if (webContext.HttpContext.Items.Contains(objectContextKey))
                return webContext.HttpContext.Items[objectContextKey] as T;

            var container = (webContext.Controller as BaseController).Container;

            var unitOfWork = container.GetInstance<T>();

            webContext.HttpContext.Items.Add(objectContextKey, unitOfWork);

            return webContext.HttpContext.Items[objectContextKey] as T;
        }
    }
}