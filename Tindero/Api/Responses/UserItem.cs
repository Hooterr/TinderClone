using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Tindero.Models;

namespace Tindero.Api.Responses
{
    public class UserItem : NotifyPropertyChanged
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public int Age { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; }

        public SwipeStatus Status { get; set; }

        public UserItem()
        {
            Age = new Random().Next(18, 30);
        }
    }
}
