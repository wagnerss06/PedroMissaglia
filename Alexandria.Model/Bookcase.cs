using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class Bookcase
    {
        //Entidade a ser criada no database. tabela de relacionamento.

        [JsonProperty("id")]// Número gerado automaticamente.
        public Guid Id { get; set; }

        [JsonProperty("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        
        [JsonProperty("BookId")]
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}
