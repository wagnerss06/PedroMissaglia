using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class UserDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
