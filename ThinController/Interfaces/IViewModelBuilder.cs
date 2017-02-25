namespace ThinController.Interfaces
{
    public interface IViewModelBuilder<TController, TViewModel>
    {
        TViewModel Build(TController controller, TViewModel viewModel);
    }

    public interface IViewModelBuilder<TController, TViewModel, TInput>
    {
        TViewModel Build(TController controller, TViewModel viewModel, TInput input);
    }

}