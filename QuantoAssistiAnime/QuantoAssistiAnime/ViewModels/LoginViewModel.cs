using System.Threading.Tasks;
using QuantoAssistiAnime.Helpers;
using QuantoAssistiAnime.Services;
using Xamarin.Forms;

namespace QuantoAssistiAnime.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AzureService _azureService;

        public Command LoginCommand { get; }

        private bool _isBusy;

        public LoginViewModel()
        {
            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;

            _azureService = DependencyService.Get<AzureService>();

            LoginCommand = new Command(async () => await ExecuteLoginCommandAsync());
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (_isBusy || !(await LoginAsync()))
            {
                return;
            }
            else
            {
                await PushAsync<ListaAnimeViewModel>();
            }

            _isBusy = false;
        }

        public Task<bool> LoginAsync()
        {
            _isBusy = true;

            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return _azureService.LoginAsync();
        }
    }
}
