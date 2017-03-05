using System.Collections.ObjectModel;
using QuantoAssistiAnime.Model.Entidades;
using QuantoAssistiAnime.Model.Servicos;
using Xamarin.Forms;

namespace QuantoAssistiAnime.ViewModel
{
    public class ListaAnimeViewModel : ObservableBaseObject
    {

        public ListaAnimeViewModel()
        {
            RefreshCommand = new Command(Load);
            Animes = new ObservableCollection<Anime>();
            
        }
        
        public Command RefreshCommand { get; set; }
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

        #endregion

    }
}
