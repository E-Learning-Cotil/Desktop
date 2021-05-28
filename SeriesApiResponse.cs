using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    class SeriesApiResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("curso")]
        public string Curso { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("ano")]
        public int Ano { get; set; }

        [JsonProperty("periodo")]
        public string Periodo { get; set; }

        [JsonProperty("sigla")]
        public string Sigla { get; set; }

        [JsonProperty("_count")]
        public Count _count { get; set; }
    }

    class ApiMessageResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    class TeachersApiResponse
    {
        [JsonProperty("RG")]
        public string RG { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }
    }
}
