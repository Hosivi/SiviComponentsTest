﻿#pragma checksum "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a9a27b78c2edcda8672dc1df183d4a547b190f7daf99afa6d62dcd1db71c8b4e"
// <auto-generated/>
#pragma warning disable 1591
namespace SiviComponents.Modal
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
#nullable restore
#line 1 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
using SiviComponents.EventArgs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
using System.Reflection;

#line default
#line hidden
#nullable disable
    public partial class SVModal : SiviComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
 if (IsOpen)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal" + " fade" + " " + (
#nullable restore
#line 7 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                            Show

#line default
#line hidden
#nullable disable
            ) + " " + (
#nullable restore
#line 7 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                                  NotificatorClass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "id", "staticBackdrop");
            __builder.AddAttribute(3, "data-bs-backdrop", "static");
            __builder.AddAttribute(4, "data-bs-keyboard", "false");
            __builder.AddAttribute(5, "tabindex", "-1");
            __builder.AddAttribute(6, "aria-labelledby", "staticBackdropLabel");
            __builder.AddAttribute(7, "aria-hidden", "true");
            __builder.AddAttribute(8, "style", "display:" + (
#nullable restore
#line 7 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                                                                                                                                                                                                                  Display

#line default
#line hidden
#nullable disable
            ) + ";");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "modal-dialog");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "modal-content");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "modal-header");
            __builder.OpenElement(15, "h5");
            __builder.AddAttribute(16, "class", "h5");
#nullable restore
#line (11,22)-(11,27) 25 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
__builder.AddContent(17, Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n\t\t\t\t\t");
            __builder.OpenElement(19, "button");
            __builder.AddAttribute(20, "type", "button");
            __builder.AddAttribute(21, "class", "btn-close");
            __builder.AddAttribute(22, "data-bs-dismiss", "modal");
            __builder.AddAttribute(23, "aria-label", "Close");
            __builder.AddAttribute(24, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                                                                                                                 OnClose

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n\t\t\t\t");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "modal-body");
#nullable restore
#line (15,7)-(15,16) 25 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
__builder.AddContent(28, ModalBody);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 17 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                 if (ModalFooter is not null)
				{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "modal-footer");
#nullable restore
#line (20,8)-(20,19) 25 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
__builder.AddContent(31, ModalFooter);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 22 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
				}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\t");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "modal-backdrop" + " fade" + " " + (
#nullable restore
#line 26 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                                     Show

#line default
#line hidden
#nullable disable
            ) + " " + (
#nullable restore
#line 26 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
                                           NotificatorBackdrop

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n\t");
            __builder.AddMarkupContent(36, @"<style>

		.modal-header .btn-close {
			padding: 0;
			left: 95%;
			position: absolute;
		}

		.modal-header {
			position: relative;
			display: flex;
			justify-content: center;
			align-content: center;
			padding-top: 1.5rem;
		}

			.modal-header .h5 {
				margin-bottom: 0;
			}

		.modal.show .modal-dialog {
			margin-top: 10rem;
		}
	</style>");
#nullable restore
#line 51 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Modal\SVModal.razor"
       

	[Parameter] public RenderFragment? ModalBody { get; set; }
	[Parameter] public RenderFragment? ModalFooter { get; set; }
	[Parameter] public string Title { get; set; }
	[Parameter] public string Width { get; set; } = "";
	[Parameter] public RenderFragment CustomButtonsFragment { get; set; }
	[Parameter] public bool CustomButtons { get; set; } = false;
	[Parameter] public string SubmitButton { get; set; } = "Enviar";
	[Parameter] public EventCallback OnAfterClose { get; set; }
	[Parameter] public EventCallback OnSubmit { get; set; }
	[Parameter] public string Show { get; set; }
	[Parameter] public string Display { get; set; }
	[Parameter] public bool ItHaveHeader { get; set; } = true;
	[Parameter] public bool IsOpen { get; set; } = false;
	[Parameter] public string? NotificatorClass { get; set; } = "";
	[Parameter] public string? NotificatorBackdrop { get; set; } = "";

	public ElementReference modal;

	/// <summary>
	/// Eventos no usados. 
	/// </summary>
	/// <param name="childComponent"></param>
	public delegate void OnRenderChildComponent(object childComponent);
	public event OnRenderChildComponent RenderChildContent; 
	public void OnRenderChildComponentEvent(object childComponent) {
		if (RenderChildContent is not null) {
			RenderChildContent(childComponent);
		}

	}

	
	
	protected override void OnParametersSet()
	{
		Toggle();
	}

	public void OnOpen(ModalEventArgs? modalArgs)
	{

		if (modalArgs is not null)
		{
			Title = modalArgs.Title;
		}
		IsOpen = true;
		StateHasChanged();
	}

	public void OnClose()
	{
		IsOpen = false;
	}
	public void Toggle()
	{
		if (IsOpen)
		{
			Display = "block";
			Show = "show";
			StateHasChanged();
		}
		else
		{
			Display = "";
			Show = "";
			StateHasChanged();
		}
	}


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
