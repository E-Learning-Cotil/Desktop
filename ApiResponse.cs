using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    class ApiResponse
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
}
