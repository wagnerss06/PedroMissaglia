using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace Alexandria.Model
{
    public class Token
    {
        //Entidade a ser criada no database
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("token")]
        public int TokenHash { get; set; }


        [Required]
        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }


        [Required]
        [JsonProperty("used")]
        public bool Used { get; set; }


    }
}
