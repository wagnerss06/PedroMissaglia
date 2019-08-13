using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class UserBookcaseDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("idbookcase")]
        public Guid IdBookcase { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("BookId")]
        public Guid? BookId { get; set; }
    }
}
