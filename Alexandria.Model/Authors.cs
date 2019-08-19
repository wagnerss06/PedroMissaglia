using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class Authors
    {
        public Authors()
        {
            this.Book = new HashSet<Book>();
        }

        [JsonProperty("id")]// Número gerado automaticamente.
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("author")]
        public string Author { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}