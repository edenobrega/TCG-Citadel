using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_Citadel.Data.CollectionManager.Models;
using TCG_Citadel.Data.MTG.Models;
using TCG_Citadel.Data.UserCollection.Models;

namespace TCG_Citadel.Data.CollectionManager
{
    public class MtgCollectionTableCard
    {
        public Card card { get; set; }
        public CollectionCard collectionCard { get; set; }
        public Css Css { get; set; } = new Css();
    }
}
