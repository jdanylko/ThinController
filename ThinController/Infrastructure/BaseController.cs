using System;
using System.Web.Mvc;
using StructureMap;

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
    }
}