using Newtonsoft.Json;
using Refit;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    public class SerieQueryParameters
    {
        public string curso { get; set; }
        public string ano { get; set; }
        public string tipo { get; set; }
        public string periodo { get; set; }
    }

    public class TeacherQueryParameters
    {
        [AliasAs("RG")]
        public string RG { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }
    }

    interface ApiService
    {
        [Get("/series/list/")]
        Task<dynamic> GetSeriesAsync();

        [Get("/series/list/")]
        Task<dynamic> GetSeriesFilteredAsync(SerieQueryParameters parametros);

        [Post("/series/create/")]
        Task<dynamic> InsertSeriesAsync([Body] SerieQueryParameters parametros);

        [Get("/professores/list/")]
        Task<dynamic> GetTeachersAsync();

        [Get("/professores/list/")]
        Task<dynamic> GetTeachersFilteredAsync(TeacherQueryParameters parametros);

        [Post("/professores/create/")]
        Task<dynamic> InsertTeachersAsync([Body] TeacherQueryParameters parametros);
    }
}