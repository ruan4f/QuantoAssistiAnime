using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuantoAssistiAnime.Model.Servicos
{
    public class NavigationService : INavigationService
    {


        public async Task Voltar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
