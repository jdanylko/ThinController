namespace ThinController.Interfaces
{
    public interface IViewModelFactory
    {
        TViewModel GetViewModel<TController, TViewModel>(TController controller);
        TViewModel GetViewModel<TController, TViewModel, TInput>(TController controller, TInput input);
    }
}