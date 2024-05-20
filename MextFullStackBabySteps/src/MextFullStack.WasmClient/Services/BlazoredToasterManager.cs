using Blazored.Toast.Services;

namespace MextFullStack.WasmClient.Services
{
    public class BlazoredToasterManager : IToasterService
    {
        private readonly IToastService _toasterService;

        public BlazoredToasterManager(IToastService toasterService)
        {
            _toasterService = toasterService;
        }

        public void ShowError(string message)
        {
            _toasterService.ShowError(message);
        }

        public void ShowInfo(string message)
        {
            _toasterService.ShowInfo(message);
        }

        public void ShowSuccess(string message)
        {
            _toasterService.ShowSuccess(message);
        }

        public void ShowWarning(string message)
        {
            _toasterService.ShowWarning(message);
        }
    }
}
