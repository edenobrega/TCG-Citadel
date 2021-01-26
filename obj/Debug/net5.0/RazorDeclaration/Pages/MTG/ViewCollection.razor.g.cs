// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TCG_Citadel.Pages.MTG
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using TCG_Citadel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\_Imports.razor"
using TCG_Citadel.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\MTG\ViewCollection.razor"
using TCG_Citadel.Data.CollectionManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\MTG\ViewCollection.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\MTG\ViewCollection.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/MTG/ViewCollection/{Set_Code}")]
    public partial class ViewCollection : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\MTG\ViewCollection.razor"
       
    [Parameter]
    public string Set_Code { get; set; }

    private void KeyboardInputHandler(KeyboardEventArgs args)
    {
        if (args.Key == "+")
        {
            if (singleShown)
            {
                UpdateCount(false ,1);
            }
        }
        else if (args.Key == "-")
        {
            if (singleShown)
            {
                UpdateCount(false, -1);
            }
        }
        if (args.Key == "/")
        {
            if (singleShown)
            {
                UpdateCount(true, 1);
            }
        }
        else if (args.Key == "*")
        {
            if (singleShown)
            {
                UpdateCount(true, -1);
            }
        }
        else if (args.Key == ".")
        {
            filterInput = "";
        }
    }

    private void UpdateCount(bool foil, int change)
    {
        if(change == -1)
        {
            if (foil && cards[singleLocation].collectionCard.Foil_Collected == 0)
            {
                return;
            }
            else if(foil == false && cards[singleLocation].collectionCard.NonFoil_Collected == 0)
            {
                return;
            }
        }
        if (foil)
        {
            cards[singleLocation].collectionCard.Foil_Collected += change;
        }
        else
        {
            cards[singleLocation].collectionCard.NonFoil_Collected += change;
        }
    }

    #region filter stuff
    private bool singleShown = false;
    private int singleLocation = 0;

    private string _filterInput;
    public string filterInput
    {
        get
        {
            return _filterInput;
        }

        set
        {
            if (value.Contains('+') || value.Contains('-') || value.Contains('/') || value.Contains('*'))
            {

            }
            else if (value.Contains('.'))
            {
                foreach (MtgCollectionTableCard card in cards)
                {
                    card.Css.IsVisible = "visible";
                    card.Css.Display = "table-row";
                }
            }
            else
            {
                _filterInput = value;
            }
            Filter();
        }
    }

    private void Filter()
    {
        if (string.IsNullOrEmpty(filterInput))
        {
            return;
        }
        foreach (MtgCollectionTableCard card in cards)
        {
            if (card.card.Collector_Number.ToLower() == filterInput.ToLower())
            {
                card.Css.IsVisible = "visible";
                card.Css.Display = "table-row";
            }
            else
            {
                card.Css.IsVisible = "hidden";
                card.Css.Display = "none";
            }
        }
        singleShown = cards.Count(x => x.Css.IsVisible == "visible") == 1;
        if (singleShown)
        {
            singleLocation = cards.FindIndex(x => x.Css.IsVisible == "visible");
        }
        else
        {
            singleLocation = -1;
        }
    }
    #endregion

    private List<MtgCollectionTableCard> cards;
    string userAuthenticated;
    private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

    void UpdateCards()
    {
        var x = cards.Select(y => y.collectionCard).ToList();
        _db.UpdateCollection(x);
    }

    protected override async Task OnInitializedAsync()
    {
        var authState = await auth.GetAuthenticationStateAsync();

        var user = authState.User;

        _claims = user.Claims;

        if (user.Identity.IsAuthenticated)
        {
            userAuthenticated = $"{user.Identity.Name} is authenticated";
        }
        else
        {
            userAuthenticated = "user is not authenticated";
        }

        cards = await _db.GetPreparedSet(Set_Code, user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider auth { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MtgCollectionManager _db { get; set; }
    }
}
#pragma warning restore 1591
