using Microsoft.AspNetCore.Components;

namespace SiviComponents.Services;

public class CssMapper:ICssMapper
{

    
    public string GetCssClassList(List<string>? classList)
    {
        if (classList!=null)
        {
            return string.Join(" ", classList);
        }
        return ""; 

    }

    public string AddCustomStylesInTag(List<CssStyle> cssStyles, string styles)
    {
        foreach (var css in cssStyles)
        {
            styles=styles+ css.KeyValueParCss;
            //string.Concat(styles, css.KeyValueParCss);

        }
        return styles;

    }

    public string GetCssStringStyle(CssStyle style)
    {
	    return $"{style.PropertyName}: {style.PropertyValue};";
    }
}