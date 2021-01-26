using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_Citadel.Services.MTG.Models
{
    public class SetsCall
    {
        public string @object { get; set; }
        public string has_more { get; set; }
        public List<SetApi> data { get; set; }
    }
}
