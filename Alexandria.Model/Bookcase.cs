using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class Bookcase
    {
        //public Bookcase()
        //{
            //Book = new HashSet<Book>();
        //}

        [JsonProperty("id")]// Número gerado automaticamente.
        public Guid Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("BookId")]
        public Guid? BookId { get; set; }
        //public virtual ICollection<Book> Book { get; set; }

    }
}
