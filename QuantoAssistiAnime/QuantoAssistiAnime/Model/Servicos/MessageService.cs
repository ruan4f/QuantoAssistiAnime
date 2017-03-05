using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuantoAssistiAnime.Model.Servicos
{
    public class MessageService : IMessageService
    {
        public MessageService()
        {

        }

        public async Task ShowAsync(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Quanto Assisti Anime", message, "OK");
        }

    }
}
