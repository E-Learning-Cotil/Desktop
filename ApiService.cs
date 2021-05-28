using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public string telefone { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
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
    }
}