using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using QuantoAssistiAnime.Authentication;
using QuantoAssistiAnime.Droid.Authentication;
using QuantoAssistiAnime.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace QuantoAssistiAnime.Droid.Authentication
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception e)
            {
                //Todo log error
                throw;
            }
        }
    }
}