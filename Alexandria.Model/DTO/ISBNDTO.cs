using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class ISBNDTO
    {
        [JsonProperty("isbn")]
        public string isbn { get; set; }

    }
}
