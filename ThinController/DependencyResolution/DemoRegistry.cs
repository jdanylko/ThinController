using StructureMap;
using ThinController.Interfaces;
using ThinController.UnitOfWork;

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
                    scan.AddAllTypesOf<AbstractUnitOfWork>();
                    scan.ConnectImplementationsToTypesClosing(typeof(IViewModelBuilder<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof(IViewModelBuilder<,,>));
                });
        }

        #endregion
    }
}