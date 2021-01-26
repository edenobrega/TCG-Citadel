using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TCG_Citadel.Data.MTG.Models
{
    public class Card
    {
        #region first region
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Oracle_ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Layout { get; set; }

        [MaxLength(200)]
        public string Image_Small { get; set; }

        [MaxLength(200)]
        public string Image_Normal { get; set; }

        [MaxLength(200)]
        public string Image_Large { get; set; }

        [MaxLength(200)]
        public string Image_Art_Crop { get; set; }

        public int Digital { get; set; }
        public int Rarity { get; set; }

        [MaxLength(200)]
        public string Collector_Number { get; set; }

        [MaxLength(200)]
        public string Set { get; set; }
        public bool Reprint { get; set; }
        public bool Promo { get; set; }

        public bool HasFoil { get; set; }
        public bool HasNonFoil { get; set; }
        #endregion

        #region Gameplay
        [MaxLength(200)]
        public string ManaCost { get; set; }

        public decimal CMC { get; set; }

        [MaxLength(200)]
        public string Type_Line { get; set; }

        [MaxLength(1000)]
        public string Oracle_Text { get; set; }

        [MaxLength(200)]
        public string Power { get; set; }

        [MaxLength(200)]
        public string Toughness { get; set; }

        [MaxLength(200)]
        public string Colors { get; set; }

        [MaxLength(200)]
        public string Color_Identity { get; set; }
        [MaxLength(200)]
        public string Keywords { get; set; }
        public string Loyalty { get; set; }
        #endregion

        #region Gameplay-other
        public string Legalality { get; set; }
        public string Hand_Modifier { get; set; }

        #endregion

        #region Print
        public string Artist { get; set; }
        public bool Booster { get; set; }
        public string Border_Color { get; set; }
        public string Flavor_text { get; set; }
        public string Frame_Effect { get; set; }
        public bool Full_Art { get; set; }
        #endregion

        #region Prices (daily updated via scryfall)
        public decimal? USD { get; set; }
        public decimal? USD_Foil { get; set; }
        public decimal? EUR { get; set; }
        public decimal? EUR_Foil { get; set; }
        #endregion
    }
}