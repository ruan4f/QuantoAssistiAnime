using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using QuantoAssistiAnime.Model.Entidades;

namespace QuantoAssistiAnime.Model.Servicos
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceSyncTable<Anime> _table;
        private const string DbPath = "Anime";
        private const string ServiceUri = "http://quantoassistianime.azurewebsites.net/";

        public AzureClient()
        {
            _client = new MobileServiceClient(ServiceUri);
            var store = new MobileServiceSQLiteStore(DbPath);
            store.DefineTable<Anime>();
            _client.SyncContext.InitializeAsync(store);
            _table = _client.GetSyncTable<Anime>();
        }

        public async Task<IEnumerable<Anime>> GetAnimes()
        {
            var empty = new Anime[0];
            try
            {
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                    await SyncAsync();

                return await _table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }

        public async void AddAnime(Anime anime)
        {
            await _table.InsertAsync(anime);
        }

        public async void DeleteAnime(Anime anime)
        {
            await _table.DeleteAsync(anime);
        }

        public async void UpdateAnime(Anime anime)
        {
            await _table.UpdateAsync(anime);
        }
        
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await _client.SyncContext.PushAsync();

                await _table.PullAsync("allAnimes", _table.CreateQuery());
            }
            catch (MobileServicePushFailedException pushEx)
            {
                if (pushEx.PushResult != null)
                    syncErrors = pushEx.PushResult.Errors;
            }
        }
        
    }
}
