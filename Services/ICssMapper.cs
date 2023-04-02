namespace SiviComponents.Services;

public interface ICssMapper
{
    string GetCssClassList(List<string> classList);
    string AddCustomStylesInTag(List<CssStyle> cssStyles,string styles);

    string GetCssStringStyle(CssStyle style);
    //List<CssStyle> DefaultCssStyles();
}