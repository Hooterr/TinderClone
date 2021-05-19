using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tindero.Api.Responses
{
    public class GetUsersResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public List<UserItem> Users { get; set; }
    }
}
