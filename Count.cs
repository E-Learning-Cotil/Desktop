using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    class Count
    {
        [JsonProperty("turmas")]
        public int Turmas { get; set; }
    }
}
