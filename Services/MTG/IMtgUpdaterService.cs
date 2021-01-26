using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_Citadel.Data.MTG.Models;
using TCG_Citadel.Services.MTG.Models;

namespace TCG_Citadel.Services.MTG
{
    public interface IMtgUpdaterService
    {
        Task UpdateCardsTable();
        Task UpdateSetsTable();

    }
}
