using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace QuantoAssistiAnime.Model.Entidades
{
    [DataTable("Anime")]
    public class Anime
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("EpisodioAtual")]
        public int EpisodioAtual { get; set; }

        [JsonProperty("TotalEpisodios")]
        public int TotalEpisodios { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
