using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class IdDTO
    {

        public IdDTO(Guid item)
        {
            this.Id = item;
        }


        [JsonProperty("id")]
        public Guid Id { get; set; }
    }

}
