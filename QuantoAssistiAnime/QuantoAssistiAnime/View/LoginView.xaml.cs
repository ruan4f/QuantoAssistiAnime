using QuantoAssistiAnime.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuantoAssistiAnime.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}