using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using QuantoAssistiAnime.Authentication;
using QuantoAssistiAnime.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuantoAssistiAnime.Services.AzureService))]
namespace QuantoAssistiAnime.Services
{
    public class AzureService
    {
        private static readonly string AppUrl = "https://maratonaxamarininter.azurewebsites.net/";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente.", "Ok");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }

    }
}
