using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SiviComponents.Services;
using Utils;

namespace SiviComponents.Base;

public class SiviDomComponentBase: ComponentBase
{
	/// <summary>
	/// INYECCIÓN DE DEPENDECIAS
	/// </summary>
	[Inject] protected IJSRuntime? Js { get; set; }
	public IJSObjectReference module;
	[Inject]
    private IComponentIdBuilder ComponentIdBuilder { get; set; }
    [Inject]
    private ICssMapper CssMapper { get; set; }
    /// <summary>
    /// PARÁMETROS
    /// </summary>
    [Parameter] public List<CssStyle>? CustomCssStyles { get; set; }

    [Parameter]
    public string NewClass
    {
        get => classList;
	    set => CustomClassList.Add(value);
    }

    [Parameter] public List<string> CustomClassList { get; set; } = new List<string>();
    [Parameter]  public RenderFragment? ChildContent { get;set; }
    ///Custom Styles
    [Parameter]
    public string? Width
    {
	    get => Width; 
	    set
	    {
		    CreateCssStyle("width", value);
		}
    }

    [Parameter]
    public string? Height
    {
		get => Height;
		set
	    {
			CreateCssStyle("height", value);
		}
	}

    [Parameter]
    public string? Margin
    {
	    get => Margin;
	    set
	    {
		    CreateCssStyle("margin", value);
	    }
    }

    [Parameter]
    public string? Padding
    {
	    get => Margin;
	    set
	    {
		    CreateCssStyle("padding", value);
	    }
	}
    [Parameter]
    public string? BackgroundColor
    {
	    get => BackgroundColor;
		set
	    {
			CreateCssStyle("background-color", value);
		}
	}
    [Parameter] public List<CssStyle> DefaultCssStyles { get; set; }= new List<CssStyle>();
    public string Id { get; set; }
    public void AddAttributes(string? attrName, object? attr)
    {
	    if (attr != null) Attributes.Add(attrName, attr);
    }
    public ElementReference Ref { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    /// <summary>
    ///CAMPOS
    /// </summary>
    protected string classList = "";

    public string styles;

    protected void CreateCssStyle(string cssPropertyName, string cssProperyValue)
    {
        if (!string.IsNullOrEmpty(cssProperyValue))
        {
            DefaultCssStyles.Add(new CssStyle(cssPropertyName, cssProperyValue));
        }

    }

    public void GetStyles()
    {
	    styles = CssMapper.AddCustomStylesInTag(DefaultCssStyles, styles);
	}
    
    protected override void OnInitialized()
    {
		Id= ComponentIdBuilder.Generate(this);
		GetStyles();
		AddAttributes("style", styles);
		//CreateCssStyle("width", Width);
		//CreateCssStyle("height", Height);
		//CreateCssStyle("margin", Margin);
		//CreateCssStyle("padding", Padding);
		//CreateCssStyle("background-color", BackgroundColor);
		if (CustomClassList.Any())
        {
            classList = CssMapper.GetCssClassList(this.CustomClassList);
            AddAttributes("class", classList);

		}
      
    }

}