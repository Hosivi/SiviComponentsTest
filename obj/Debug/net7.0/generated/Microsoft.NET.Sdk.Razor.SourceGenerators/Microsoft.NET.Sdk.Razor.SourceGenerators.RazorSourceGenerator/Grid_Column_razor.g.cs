﻿#pragma checksum "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Grid\Column.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51d12867a0315eaf865cb4d1ea5ec0fe6e504db1b510888f34bd27c7393dd818"
// <auto-generated/>
#pragma warning disable 1591
namespace SiviComponents.Grid
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
#nullable restore
#line 1 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Grid\Column.razor"
using System.Data.Common;

#line default
#line hidden
#nullable disable
    public partial class Column : SiviDomComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", 
#nullable restore
#line 4 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Grid\Column.razor"
          Id

#line default
#line hidden
#nullable disable
            );
            __builder.AddMultipleAttributes(2, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, object>>>(
#nullable restore
#line 4 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Grid\Column.razor"
                           Attributes

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line (5,3)-(5,15) 24 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Grid\Column.razor"
__builder.AddContent(3, ChildContent);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "E:\RepositoriosDesarrollo\Horelt\SiviComponents\Grid\Column.razor"
       
	string cols;

	[Parameter]
	public int? Cols {
		get => Cols;
		set {
			cols = !value.HasValue ? "col" : (value.Value == 0 ? "col-md-12" : $"col-md-{value.Value}");
			CustomClassList?.Add(cols);
		}
	}

	[Parameter]
	public int? SmCols { get; set; }

	[Parameter]
	public int? XlCols { get; set; }

	[Parameter]
	public bool IfCustomWidth { get; set; } = false;

	protected override void OnInitialized() {
		if(string.IsNullOrEmpty(cols))
		{
			cols = "col";
			CustomClassList?.Add(cols);
		}
		base.OnInitialized();
	}


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
