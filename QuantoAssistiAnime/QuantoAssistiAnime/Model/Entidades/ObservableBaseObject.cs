using System.ComponentModel;
using System.Runtime.CompilerServices;
using QuantoAssistiAnime.Model.Servicos;

namespace QuantoAssistiAnime.Model.Entidades
{
    public class ObservableBaseObject : INotifyPropertyChanged
    {
        protected INavigationService NavigationService;
        protected IMessageService MessageService;

        public ObservableBaseObject()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate {

        };

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
