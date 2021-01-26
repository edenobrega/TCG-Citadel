using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCG_Citadel.Data.MTG.Models;
using RestSharp;
using Newtonsoft.Json;
using TCG_Citadel.Services.MTG.Models;
using TCG_Citadel.Data.MTG;
using System.Net;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TCG_Citadel.Services.MTG
{
    // TODO: None of these should probably return anything, it should update the db in the methods, or they should atleast not return (next line)
    //       scryfall format data and be returning TCG-Citadel formated data
    /// <summary>
    /// Built around the scryfall api
    /// </summary>
    public class MtgUpdaterService : IMtgUpdaterService
    {
        private readonly MtgDbContext context;
        private readonly HttpClient httpClient;
        public MtgUpdaterService(HttpClient httpClient, MtgDbContext context)
        {
            this.httpClient = httpClient;
            this.context = context;
        }

        // TODO: Should not be bulk inserting with EF
        /// <summary>
        /// Requires MTG_Sets table to have values
        /// </summary>
        /// <returns></returns>
        public async Task UpdateCardsTable()
        {
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            //https://scryfall.com/docs/api/bulk-data

            Console.WriteLine("Starting update cards tables");

            List<CardApi> cards = new List<CardApi>();
            List<Card> current_cards = context.MTG_Cards.ToList();

            IRestClient client = new RestClient();
            
            string json;

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://c2.scryfall.com/file/scryfall-bulk/default-cards/default-cards-20210119220408.json");
            }
            
            cards = JsonConvert.DeserializeObject<List<CardApi>>(json);
            Console.WriteLine("Converted to object");

            int i = 0;
            foreach (CardApi item in cards)
            {
                if(current_cards.Any(x => x.Oracle_ID == item.oracle_id && x.Set == item.set))
                {
                    continue;
                }

                Card card = new Card 
                { 
                    Oracle_ID = item.oracle_id,
                    Name = item.Name,
                    Layout = item.layout,
                    Image_Small = item.image_uris?.small.ToString(),
                    Image_Normal = item.image_uris?.normal.ToString(),
                    Image_Large = item.image_uris?.large.ToString(),
                    Image_Art_Crop = item.image_uris?.art_crop.ToString(),
                    Digital = Convert.ToInt32(item.digital),
                    Rarity = (int)Enum.Parse(typeof(eRarity), item.rarity),
                    Collector_Number = item.collector_number,
                    Set = item.set,
                    Reprint = item.reprint,
                    Promo = item.promo,
                    HasFoil = item.foil,
                    HasNonFoil = item.nonfoil,

                    ManaCost = item.mana_cost,
                    CMC = item.cmc,
                    Type_Line = item.type_line,
                    Oracle_Text = item.oracle_text,
                    Power = item.power,
                    Toughness = item.toughness,
                    Colors = item.colors is null ? null : string.Join(',', item.colors),
                    Color_Identity = string.Join(',', item.color_identity),
                    Keywords = string.Join(',', item.keywords),
                    Loyalty = item.loyalty,

                    Legalality = item.legalities.ToString(),
                    Hand_Modifier = item.hand_modifier,

                    Artist = item.artist,
                    Booster = item.booster,
                    Border_Color = item.border_color,
                    Flavor_text = item.flavor_text,
                    Frame_Effect = item.frame_effects is null ? null : string.Join(',', item.frame_effects),
                    Full_Art = item.full_art,

                    USD = item.prices.usd,
                    USD_Foil = item.prices.usd_foil,
                    EUR = item.prices.eur,
                    EUR_Foil = item.prices.eur_foil                    
                };

                context.MTG_Cards.Add(card);
                i++;
                if (i == 200)
                {
                    i = 0;
                    context.SaveChanges();
                }
            }
            context.SaveChanges();
            
            context.ChangeTracker.AutoDetectChangesEnabled = true;

        }

        public async Task UpdateSetsTable()
        {
            IRestClient client = new RestClient();
            IRestRequest request = new RestRequest(httpClient.BaseAddress + "/sets");
            IRestResponse response = await client.ExecuteGetAsync(request);
            SetsCall x = JsonConvert.DeserializeObject<SetsCall>(response.Content);

            foreach (var item in context.MTG_Sets)
            {
                try
                {
                    x.data.RemoveAt(x.data.FindIndex(x => x.code == item.Set_Code));
                }
                catch (ArgumentException e)
                {

                }
            }

            if (x.data.Count == 0)
            {
                return;
            }

            foreach (var item in x.data)
            {
                context.Add<Set>(new Set
                {
                    DateReleased = item.released_at,
                    Set_Code = item.code,
                    Name = item.name,
                    Set_Type = item.set_type,
                    Block_Code = item.block_code,
                    Block = item.block,
                    Parent_set_code = item.parent_set_code,
                    Card_Count = item.card_count,
                    Digital = item.digital,
                    Foil_Only = item.foil_only,
                    NonFoil_Only = item.nonfoil_only,
                    Cards_Api_Call = item.search_uri,
                    Icon_Svg_Uri = item.icon_svg_uri
                });
            }
            context.SaveChanges();
        }
    }
}
