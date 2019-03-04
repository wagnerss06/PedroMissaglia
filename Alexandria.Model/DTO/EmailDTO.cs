using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class EmailDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
