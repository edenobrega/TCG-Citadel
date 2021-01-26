using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_Citadel.Services.MTG.Models
{
    public class CardPage
    {
        public string @object { get; set; }
        public int total_cards { get; set; }
        public bool has_more { get; set; }
        public Uri next_page { get; set; }
        public List<CardApi> data { get; set; }
    }
}
