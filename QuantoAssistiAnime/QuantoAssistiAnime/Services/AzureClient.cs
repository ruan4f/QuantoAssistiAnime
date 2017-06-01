using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using QuantoAssistiAnime.Model;

namespace QuantoAssistiAnime.Services
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceSyncTable<Anime> _table;
        private const string DbPath = "Anime";
        private const string ServiceUri = "https://maratonaxamarininter.azurewebsites.net/";

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

            // Simple error/conflict handling.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.",
                        error.TableName, error.Item["id"]);
                }
            }
        }

    }
}
