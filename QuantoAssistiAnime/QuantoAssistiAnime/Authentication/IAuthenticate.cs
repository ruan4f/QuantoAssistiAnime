using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace QuantoAssistiAnime.Authentication
{
    public interface IAuthenticate
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
    }
}
