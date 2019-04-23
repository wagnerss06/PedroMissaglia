using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class Subjects
    {
        public Subjects()
        {
            Book = new HashSet<Book>();
        }

        [JsonProperty("id")]// Número gerado automaticamente.
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("subject")]
        public string Subject { get; set; }

        public virtual ICollection<Book> Book { get; set; }

    }
}
