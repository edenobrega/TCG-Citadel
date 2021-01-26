using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TCG_Citadel.Data.MTG.Models
{
    [Keyless]
    public class Rarity
    {
        public int ID { get; set; }

        [MaxLength(15)]
        public string Value { get; set; }
    }
}