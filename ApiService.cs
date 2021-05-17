using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    interface ApiService
    {
        [Get("/series/list/")]
        Task<dynamic> GetSeriesAsync();
    }
}
