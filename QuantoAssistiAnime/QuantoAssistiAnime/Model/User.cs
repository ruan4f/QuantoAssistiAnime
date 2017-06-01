using Newtonsoft.Json;

namespace QuantoAssistiAnime.Model
{
    public class User
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }
    }
}
