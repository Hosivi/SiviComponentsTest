﻿#pragma checksum "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "71b5da24a08ec7d2835d027ca6b061d7fe8cb4aa9e2444dd91dfbbcab7bfa2e5"
// <auto-generated/>
#pragma warning disable 1591
namespace SiviComponents.Forms
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.Base;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.EventArgs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.SVDropDownSelect;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.SVFormBuilder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.DateComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.SVStepper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\_Imports.razor"
using SiviComponents.Timer;

#line default
#line hidden
#nullable disable
    public partial class SVSwitch : SVInputRadio
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 2 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
 if (ConditionalRendering) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "form-check form-switch");
            __builder.OpenElement(2, "input");
            __builder.AddAttribute(3, "class", "form-check-input");
            __builder.AddAttribute(4, "type", "checkbox");
            __builder.AddAttribute(5, "id", 
#nullable restore
#line 4 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
                                                             Id

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(6, "oninput", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 5 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
                           async (ChangeEventArgs e) =>{
			                 await OnValueChanged(e);
			                 await OnValueStringChanged(e);
			                 if (ConditionalAction.HasDelegate)
			                 { await ConditionalAction.InvokeAsync();} }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "disabled", 
#nullable restore
#line 10 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
                          IsDisabled

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(8, "value", 
#nullable restore
#line 10 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
                                              Value

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\t\t");
            __builder.OpenElement(10, "label");
            __builder.AddAttribute(11, "class", "form-check-label");
            __builder.AddAttribute(12, "for", 
#nullable restore
#line 11 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
                                              Id

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line (11,46)-(11,51) 25 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
__builder.AddContent(13, Label);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 13 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Forms\SVSwitch.razor"
       
	[Parameter] public EventCallback ConditionalAction { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591