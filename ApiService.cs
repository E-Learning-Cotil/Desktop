using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    public class QueryParameters
    {
        public string curso { get; set; }
        public string ano { get; set; }
        public string tipo { get; set; }
        public string periodo { get; set; }
    }

    interface ApiService
    {
        [Get("/series/list/")]
        Task<dynamic> GetSeriesAsync();

        [Get("/series/list/")]
        Task<dynamic> GetSeriesFilteredAsync(QueryParameters parametros);
    }
}