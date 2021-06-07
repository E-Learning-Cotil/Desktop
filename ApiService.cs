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
        [AliasAs("rg")]
        public string RG { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }
    }


    interface ApiService
    {
    // Rotas de Séries
        [Get("/series/list/")]
        Task<dynamic> GetSeriesAsync();

        [Get("/series/list/")]
        Task<dynamic> GetSeriesFilteredAsync(SerieQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/series/create/")]
        Task<dynamic> InsertSeriesAsync([Body] SerieQueryParameters parametros);

    // Rotas de Professores
        [Get("/professores/list/")]
        Task<dynamic> GetTeachersAsync();

        [Get("/professores/list/")]
        Task<dynamic> GetTeachersFilteredAsync(TeacherQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/professores/create/")]
        Task<dynamic> InsertTeachersAsync([Body] TeacherQueryParameters parametros);
    }
}