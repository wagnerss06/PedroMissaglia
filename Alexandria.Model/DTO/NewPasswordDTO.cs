using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class NewPasswordDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("new_password")]
        public string New_Password { get; set; }

        [JsonProperty("confirm_password")]
        public string Confirm_Password { get; set; }

    }
}
