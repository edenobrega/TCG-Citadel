using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TCG_Citadel.Data.MTG.Models
{
    public class Set
    {

        [Key]
        public int Citadel_ID { get; set; }
        public DateTime DateReleased { get; set; }
        public string Set_Code { get; set; }

        public string Name { get; set; }

        public string Set_Type { get; set; }
        public string Block_Code { get; set; }
        public string Block { get; set; }
        public string Parent_set_code { get; set; }
        public int Card_Count { get; set; }
        public bool Digital { get; set; }
        public bool Foil_Only { get; set; }
        public bool NonFoil_Only { get; set; }
        public Uri Cards_Api_Call { get; set; }
        public Uri Icon_Svg_Uri { get; set; }




    }
}