using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{

    //Entidade a ser criada no database
    public class User
    {
        public User()
        {
            Bookcase = new HashSet<Bookcase>();
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [Required]
        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("gender")]
        public string Gender{ get; set; }

        [JsonProperty("coin")]
        public int Coin { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("AvatarId")]
        public Guid AvatarId { get; set; }
        public virtual Avatar Avatar { get; set; }

        public virtual ICollection<Bookcase> Bookcase { get; set; }

    }
}
