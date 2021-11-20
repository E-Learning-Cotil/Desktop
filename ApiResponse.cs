using Newtonsoft.Json;
using Refit;
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

    class ApiImageResponse
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    class TeachersApiResponse
    {
        [JsonProperty("rg")]
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
    
    class StudentsApiResponse
    {
        [AliasAs("ra")]
        public int RA { get; set; }

        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }

        [AliasAs("idSerie")]
        public int IdSerie { get; set; }
    }

    class TurmasApiResponse
    {
        [AliasAs("id")]
        public int ID { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("idCores")]
        public int IdCores { get; set; }

        [AliasAs("idIcone")]
        public int IdIcone { get; set; }

        [AliasAs("idSerie")]
        public int IdSerie { get; set; }

        [AliasAs("rgProfessor")]
        public string RgProfessor { get; set; }

        [AliasAs("icone")]
        public IconsApiResponse Icone { get; set; }

        [AliasAs("cores")]
        public ColorsApiResponse Colors { get; set; }
    }

    public class ColorsApiResponse
    {
        [AliasAs("id")]
        public int ID { get; set; }

        [AliasAs("corPrim")]
        public string CorPrim { get; set; }

        [AliasAs("corSec")]
        public string CorSec { get; set; }
    }

    public class IconsApiResponse
    {
        [AliasAs("id")]
        public int ID { get; set; }

        [AliasAs("link")]
        public string Link { get; set; }
    }
}
