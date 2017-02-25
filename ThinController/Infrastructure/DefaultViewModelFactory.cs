using System;
using StructureMap;
using ThinController.Interfaces;

namespace ThinController.Infrastructure
{
    public class DefaultViewModelFactory: IViewModelFactory
    {
        public TViewModel GetViewModel<TController, TViewModel>(TController controller)
        {
            var container = new Container(_ =>
                _.Scan(e =>
                {
                    e.AssembliesFromApplicationBaseDirectory();
                    e.WithDefaultConventions();
                    e.ConnectImplementationsToTypesClosing(typeof(IViewModelBuilder<,>));
                }));

            var model = container.GetInstance<TViewModel>();
            var modelBuilder = container.GetInstance<IViewModelBuilder<TController, TViewModel>>();

            // Redirect and assist developers in adding their own modelbuilder/viewmodel
            if (modelBuilder == null)
                throw new Exception(
                    string.Format(
                        "Could not find a ModelBuilder with a {0} Controller/{1} ViewModel pairing. Please create one.",
                        typeof(TController).Name, typeof(TViewModel).Name));

            return modelBuilder.Build(controller, model);
        }

        public TViewModel GetViewModel<TController, TViewModel, TInput>(TController controller, TInput data)
        {
            var container = new Container(_ =>
                _.Scan(e =>
                {
                    e.AssembliesFromApplicationBaseDirectory();
                    e.WithDefaultConventions();
                    e.ConnectImplementationsToTypesClosing(typeof(IViewModelBuilder<,,>));
                }));

            var model = container.GetInstance<TViewModel>();
            var modelBuilder = container.GetInstance<IViewModelBuilder<TController, TViewModel, TInput>>();

            // Redirect and assist developers in adding their own modelbuilder/viewmodel
            if (modelBuilder == null)
                throw new Exception(
                    string.Format(
                        "Could not find a ModelBuilder with a {0} Controller/{1} ViewModel/{2} TInput pairing. Please create one.",
                        typeof(TController).Name,
                        typeof(TViewModel).Name,
                        typeof(TInput).Name)
                    );

            return modelBuilder.Build(controller, model, data);
        }
    }
}
