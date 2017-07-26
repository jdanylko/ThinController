using System.Data.Entity;
using StructureMap;
using ThinController.EntityFramework;
using ThinController.Interfaces;

namespace ThinController.DependencyResolution
{
    public class DemoRegistry : Registry
    {
        #region Constructors and Destructors

        public DemoRegistry()
        {
            Scan(
                scan => {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.AddAllTypesOf(typeof(DbContext));
                    scan.ConnectImplementationsToTypesClosing(typeof(IViewModelBuilder<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof(IViewModelBuilder<,,>));
                });
            For<DbContext>().Use<DemoDbContext>();
        }

        #endregion
    }
}