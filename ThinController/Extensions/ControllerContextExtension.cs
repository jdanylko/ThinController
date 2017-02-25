using System;
using System.Web.Mvc;
using StructureMap;
using ThinController.UnitOfWork;

namespace ThinController.Extensions
{
    public static class ControllerContextExtension
    {
        public static T GetUnitOfWork<T>(this ControllerContext webContext) where T : AbstractUnitOfWork
        {
            var objectContextKey = String.Format("{0}-{1}", typeof(T),
                webContext.GetHashCode().ToString("x"));

            if (webContext.HttpContext.Items.Contains(objectContextKey))
                return webContext.HttpContext.Items[objectContextKey] as T;

            // Old way...
            // var type = Activator.CreateInstance<T>();
            // New DI way.

            var container = new Container(_ =>
                _.Scan(e =>
                {
                    e.AssembliesFromApplicationBaseDirectory();
                    e.AddAllTypesOf<AbstractUnitOfWork>();
                }));

            var unitOfWork = container.GetInstance<T>();

            webContext.HttpContext.Items.Add(objectContextKey, unitOfWork);

            return webContext.HttpContext.Items[objectContextKey] as T;
        }
    }
}