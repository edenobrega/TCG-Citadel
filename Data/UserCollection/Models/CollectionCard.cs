using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_Citadel.Data.UserCollection.Models
{
    public class CollectionCard
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public int Citadel_ID { get; set; }

        [Required]
        public string Game { get; set; }
        [Required]
        public string Set { get; set; }
        public int NonFoil_Collected { get; set; }
        public int Foil_Collected { get; set; }
    }
}
