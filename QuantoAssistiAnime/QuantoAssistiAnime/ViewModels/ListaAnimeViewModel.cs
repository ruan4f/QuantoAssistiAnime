using System.Collections.ObjectModel;
using QuantoAssistiAnime.Model;
using Xamarin.Forms;

namespace QuantoAssistiAnime.ViewModels
{
    public class ListaAnimeViewModel : BaseViewModel
    {

        public ListaAnimeViewModel()
        {
            RefreshCommand = new Command(Load);
            Animes = new ObservableCollection<Anime>();
            DetalhaAnimeCommand = new Command<Anime>(ExecuteDetalhaAnimeCommand);
            AdicionaAnimeCommand = new Command(ExecuteAdicionaAnimeCommand);
        }
        
        public Command RefreshCommand { get; set; }
        public Command AdicionaAnimeCommand { get; set; }
        public Command<Anime> DetalhaAnimeCommand { get; }
        public ObservableCollection<Anime> Animes { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value; 
                OnPropertyChanged();
            }
        }

        private int episodioAtual;

        public int EpisodioAtual
        {
            get { return episodioAtual; }
            set
            {
                episodioAtual = value;
                OnPropertyChanged();
            }
        }

        #region Métodos

        public async void Load()
        {
            IsBusy = true;
            var result = await App.AzureClient.GetAnimes();

            Animes.Clear();

            foreach (var item in result)
            {
                Animes.Add(item);
            }
            IsBusy = false;
        }

        private async void ExecuteAdicionaAnimeCommand()
        {
            await PushAsync<NovoAnimeViewModel>();
        }

        private async void ExecuteDetalhaAnimeCommand(Anime anime)
        {
            await PushAsync<DetalheAnimeViewModel>(anime);
        }

        #endregion

    }
}
