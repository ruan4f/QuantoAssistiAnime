using QuantoAssistiAnime.Model.Servicos;
using QuantoAssistiAnime.View;
using Xamarin.Forms;

namespace QuantoAssistiAnime
{
    public class App : Application
    {
        public static AzureClient AzureClient;

        public App()
        {
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            // The root page of your application
            var content = new ListaAnimeView();

            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            AzureClient = new AzureClient();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
