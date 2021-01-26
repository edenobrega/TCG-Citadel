using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_Citadel.Services.MTG.Models
{
    public class CardApi
    {
        #region Core Card Fields
        public int arena_id { get; set; }
        public string id { get; set; }
        public string lang { get; set; }
        public int mtgo_id { get; set; }
        public int mtgo_foil_id { get; set; }
        public List<int> multiverse_ids { get; set; }
        public int tcgplayer_id { get; set; }
        public int cardmarket_id { get; set; }
        public string oracle_id { get; set; }
        public Uri prints_search_uri { get; set; }
        public Uri rulings_uri { get; set; }
        public Uri scryfall_uri { get; set; }
        public Uri Uri { get; set; }
        #endregion

        #region Gameplay Fields
        public List<RelatedCard> all_parts { get; set; }
        public List<CardFace> card_faces { get; set; }
        public decimal cmc { get; set; }
        public List<char> color_identity { get; set; }
        public List<char> colors { get; set; }
        public int edhrec_rank { get; set; }
        public bool foil { get; set; }
        public string hand_modifier { get; set; }
        public List<string> keywords { get; set; }
        public string layout { get; set; }
        public Legals legalities { get; set; }
        public string life_modifier { get; set; }
        public string loyalty { get; set; }
        public string mana_cost { get; set; }
        public string Name { get; set; }
        public bool nonfoil { get; set; }
        public string oracle_text { get; set; }
        public bool oversized { get; set; }
        public string power { get; set; }
        public List<char> produced_mana { get; set; }
        public bool reserved { get; set; }
        public string toughness { get; set; }
        public string type_line { get; set; }
        #endregion

        #region Print Fields
        public string artist { get; set; }
        public bool booster { get; set; }
        public string border_color { get; set; }
        public string card_back_id { get; set; }
        public string collector_number { get; set; }
        public bool digital { get; set; }
        public string flavor_name { get; set; }
        public string flavor_text { get; set; }
        public List<string> frame_effects { get; set; }
        public string frame { get; set; }
        public bool full_art { get; set; }
        public List<string> games { get; set; }
        public bool highres_image { get; set; }
        public string illustration_id { get; set; }
        public ImageUri image_uris { get; set; }
        public Prices prices { get; set; }
        public string printed_name { get; set; }
        public string printed_text { get; set; }
        public string printed_type_line { get; set; }
        public bool promo { get; set; }
        public List<string> promo_types { get; set; }
        public PurchaseUris purchase_uris { get; set; }
        public string rarity { get; set; }
        public DateTime released_at { get; set; }
        public bool reprint { get; set; }
        public Uri scryfall_set_uri { get; set; }
        public string set_name { get; set; }
        public Uri set_search_uri { get; set; }
        public string set_type { get; set; }
        public Uri set_uri { get; set; }
        public string set { get; set; }
        public bool story_spotlight { get; set; }
        public bool textless { get; set; }
        public bool variation { get; set; }
        public string variation_of { get; set; }
        public string watermark { get; set; }

        #endregion
    }

    public class RelatedCard
    {
        public string id { get; set; }
        public string component { get; set; }
        public string name { get; set; }
        public string type_line { get; set; }
        public Uri uri { get; set; }
    }

    public class CardFace
    {
        public string artist { get; set; }
        public List<char> color_indicator { get; set; }
        public List<char> colors { get; set; }
        public string flavor_text { get; set; }
        public string illustration_id { get; set; }
        public ImageUri image_uris { get; set; }
        public string loyalty { get; set; }
        public string mana_cost { get; set; }
        public string name { get; set; }
        public string oracle_text { get; set; }
        public string power { get; set; }
        public string printed_name { get; set; }
        public string printed_text { get; set; }
        public string printed_type_line { get; set; }
        public string toughness { get; set; }
        public string type_line { get; set; }
        public string watermark { get; set; }
    }

    public class ImageUri
    {
        public Uri small { get; set; }
        public Uri normal { get; set; }
        public Uri large { get; set; }
        public Uri png { get; set; }
        public Uri art_crop { get; set; }
        public Uri border_crop { get; set; }
    }

    public class Legals
    {
        public string standard { get; set; }
        public string future { get; set; }
        public string historic { get; set; }
        public string gladiator { get; set; }
        public string pioneer { get; set; }
        public string modern { get; set; }
        public string legacy { get; set; }
        public string pauper { get; set; }
        public string vintage { get; set; }
        public string penny { get; set; }
        public string commander { get; set; }
        public string brawl { get; set; }
        public string duel { get; set; }
        public string oldschool { get; set; }
        public string premodern { get; set; }

        public override string ToString()
        {
            return standard + "," +
                future + "," +
                historic + "," +
                gladiator + "," +
                pioneer + "," +
                modern + "," +
                legacy + "," +
                pauper + "," +
                vintage + "," +
                penny + "," +
                commander + "," +
                brawl + "," +
                duel + "," +
                oldschool + "," +
                premodern;
        }

        public Legals()
        {

        }
        public Legals(string import)
        {
            throw new NotImplementedException("dont think i even need this shit");

            string[] list = import.Split(',');

            standard = list[0];
            future = list[1];
            historic = list[2];
            gladiator = list[3];
            pioneer = list[4];

        }
    }

    public class Prices
    {
        public decimal? usd { get; set; }
        public decimal? usd_foil { get; set; }
        public decimal? eur { get; set; }
        public decimal? eur_foil { get; set; }
        public decimal? tix { get; set; }
    }

    public class PurchaseUris
    {
        public Uri tcgplayer { get; set; }
        public Uri cardmarket { get; set; }
        public Uri cardhoarder { get; set; }
    }
}
