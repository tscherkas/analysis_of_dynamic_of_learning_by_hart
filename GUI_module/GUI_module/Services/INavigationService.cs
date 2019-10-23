using GUI_module.ViewModels;

namespace GUI_module.Services
{
    public interface INavigationService
    {
        void setupContainer(IViewContainer container, IViewModel model = null);
        void navigateToLogin();
        void navigateToTests(bool adminAccess = false);
        void navigateToAdminMenu();
    }
}