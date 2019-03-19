using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class Avatar
    {
        //Entidade a ser criada no database

        public Avatar()
        {
            Users = new HashSet<User>();
        }

        [JsonProperty("id")]// Número gerado automaticamente.
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("literary_genre")]
        public string Literary_genre { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [Required]
        [JsonProperty("image")]
        public string Image { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }

}
