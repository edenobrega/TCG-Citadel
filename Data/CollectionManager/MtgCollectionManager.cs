using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_Citadel.Data.MTG;
using TCG_Citadel.Data.UserCollection;
using TCG_Citadel.Data.MTG.Models;
using TCG_Citadel.Data.UserCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace TCG_Citadel.Data.CollectionManager
{
    public class MtgCollectionManager
    {
        private readonly MtgDbContext mtg_context;
        private readonly UserCollectionDbContext collection_context;

        public MtgCollectionManager(MtgDbContext mtg_context, UserCollectionDbContext collection_context)
        {
            this.mtg_context = mtg_context;
            this.collection_context = collection_context;
        }

        /// <summary>
        /// Gets a list of cards ready to be viewed, and sent back to server to update collection
        /// </summary>
        /// <param name="Set_Code">e.g. cmr, m20, khr</param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public async Task<List<MtgCollectionTableCard>> GetPreparedSet(string Set_Code, string UserID)
        {
            List<MtgCollectionTableCard> cards_table = new List<MtgCollectionTableCard>();
            List<Card> cards_raw = await mtg_context.MTG_Cards.Where(x => x.Set == Set_Code).OrderBy(x => x.Collector_Number).ToListAsync();
            List<CollectionCard> cards_collected = await collection_context.UserCollectedCards.Where(x => 
                x.Set == Set_Code && 
                x.UserID == UserID && 
                x.Game == "MTG")
                    .ToListAsync();
            foreach (var raw in cards_raw)
            {
                MtgCollectionTableCard newCard = new MtgCollectionTableCard();
                newCard.card = raw;
                newCard.collectionCard = cards_collected.Any(x => x.Citadel_ID == raw.ID) ? 
                    cards_collected.Single(x => x.Citadel_ID == raw.ID) : 
                    new CollectionCard 
                    { 
                        UserID = UserID, 
                        Citadel_ID = raw.ID,
                        Game = "MTG",
                        Set = Set_Code,
                        NonFoil_Collected = 0,
                        Foil_Collected = 0
                    };
                cards_table.Add(newCard);
            }

            return cards_table;
        }

        public void UpdateCollection(List<CollectionCard> cards)
        {
            var g = collection_context.UserCollectedCards.ToList();
            foreach (var card in cards)
            {
                bool x = g.Any(y =>
                    y.UserID == card.UserID &&
                    y.Citadel_ID == card.Citadel_ID &&
                    y.Game == card.Game);
                if(x && card.Foil_Collected == 0 && card.NonFoil_Collected == 0)
                {
                    collection_context.UserCollectedCards.Remove(card);
                }
                else if (x == false && card.Foil_Collected == 0 && card.NonFoil_Collected == 0)
                {
                    continue;
                }
                else if (x)
                {
                    collection_context.UserCollectedCards.Single(p => 
                        p.UserID == card.UserID &&
                        p.Citadel_ID == card.Citadel_ID &&
                        p.Game == card.Game).NonFoil_Collected = card.NonFoil_Collected;

                    collection_context.UserCollectedCards.Single(p =>
                        p.UserID == card.UserID &&
                        p.Citadel_ID == card.Citadel_ID &&
                        p.Game == card.Game).Foil_Collected = card.Foil_Collected;
                }
                else
                {
                    collection_context.Add(card);
                }
            }
            collection_context.SaveChanges();
        }
    }
}
