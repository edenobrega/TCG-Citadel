#pragma checksum "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4b2f68388ceda249ecc36ec0149d00f3dcdf582"
// <auto-generated/>
#pragma warning disable 1591
namespace TCG_Citadel.Pages.Harbour
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
#line 2 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor"
using TCG_Citadel.Services.MTG;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor"
using TCG_Citadel.Services.MTG.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor"
using Data.MTG;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor"
using Data.MTG.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/MTG/Harbour")]
    public partial class MtgHarbour : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "table");
            __builder.AddMarkupContent(1, "<thead><tr><th></th>\r\n            <th>Message</th>\r\n            <th>Sets Added</th>\r\n            <th>Sets that were missing</th></tr></thead>\r\n    ");
            __builder.OpenElement(2, "tbody");
            __builder.OpenElement(3, "tr");
            __builder.OpenElement(4, "td");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor"
                                  service.UpdateSetsTable

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(7, "Populate Sets Table");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<td>n/a</td>\r\n            ");
            __builder.AddMarkupContent(10, "<td>n/a</td>\r\n            ");
            __builder.AddMarkupContent(11, "<td>n/a</td>");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n\r\n        ");
            __builder.OpenElement(13, "tr");
            __builder.OpenElement(14, "td");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "X:\programming projects\TCGC\TCG Citadel\TCG-Citadel\Pages\Harbour\MtgHarbour.razor"
                                  service.UpdateCardsTable

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(17, "Populate Cards Table");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n            ");
            __builder.AddMarkupContent(19, "<td>n/a</td>\r\n            ");
            __builder.AddMarkupContent(20, "<td>n/a</td>\r\n            ");
            __builder.AddMarkupContent(21, "<td>n/a</td>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMtgUpdaterService service { get; set; }
    }
}
#pragma warning restore 1591
