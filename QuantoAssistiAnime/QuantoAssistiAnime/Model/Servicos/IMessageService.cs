using System.Threading.Tasks;

namespace QuantoAssistiAnime.Model.Servicos
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
