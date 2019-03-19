using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alexandria.Model
{
    public class Book
    {
        //Entidade a ser criada no database de acordo com a API de ISBN

        public Book()
        {
            Bookcase = new HashSet<Bookcase>();
        }

        [JsonProperty("id")]// Número gerado automaticamente.
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_long")]
        public string Title_long { get; set; }

        [Required]
        [JsonProperty("isbn")]
        public string ISBN { get; set; }

        [Required]
        [JsonProperty("authors")] //Array de String. verificar implementação
        public string Authors { get; set; }

        [Required]
        [JsonProperty("editora")]
        public string Editora { get; set; }

        [Required]
        [JsonProperty("edition")]
        public string Edition { get; set; }

        [JsonProperty("date_published")]
        public DateTime Date_published { get; set; }

        [Required]
        [JsonProperty("language")]
        public string Language { get; set; }

        [Required]
        [JsonProperty("páginas")]
        public int Pages { get; set; }

        [Required]
        [JsonProperty("gender")]
        public string Literary_genre { get; set; }

        public virtual ICollection<Bookcase> Bookcase { get; set; }
        
        /*
        //Campos a serem criados após a implementacao da API
        [Required]
        [JsonProperty("isbn13")]
        public string ISBN13 { get; set; }

        [Required]
        [JsonProperty("dewey_decimal")]// Codigo bibliotecario
        public string dewey_decimal { get; set; }

        [Required]
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("msrp")]// verificar
        public string Price { get; set; }

        [Required]
        [JsonProperty("binding")] // Analisar
        public string Binding { get; set; }

        [Required]
        [JsonProperty("dimensões")]
        public string Dimensions { get; set; }

        [Required]
        [JsonProperty("visão geral")]
        public string Overview { get; set; }

        [Required]
        [JsonProperty("excerto")]//Resumo
        public string Excerpt { get; set; }

        [Required]
        [JsonProperty("synopsys")]
        public string Synopsys { get; set; }

        [Required]
        [JsonProperty("subject")] //Array de String. verificar implementação
        public string Subject { get; set; }

        [JsonProperty("reviews")] //Array de String. verificar implementação. Verifica a lingua dos reviews.
        public string Reviews { get; set; }

        */

    }
}
