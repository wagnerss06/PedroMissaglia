using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class AuthorNameDTO
    {
        [JsonProperty("author")]
        public string Author { get; set; }
    }
}