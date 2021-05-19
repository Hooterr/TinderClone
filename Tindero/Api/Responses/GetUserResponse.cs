using Newtonsoft.Json;

namespace Tindero.Api.Responses
{
    public class GetUserResponse
    {
        [JsonProperty("data")]
        public UserItem Data { get; set; }
    }
}
