using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class ISBN13DTO
    {
        [JsonProperty("isbn13")]
        public string isbn13 { get; set; }

    }
}