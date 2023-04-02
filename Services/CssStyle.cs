namespace SiviComponents.Services;

public class CssStyle
{
    public CssStyle(string propertyName, string propertyValue)
    {
        PropertyName = propertyName;
        PropertyValue = propertyValue;
        KeyValueParCss = PropertyName+ ": " +PropertyValue+";";
    }

    public void GetKeyValueCssPair()
    {
        KeyValueParCss = "{PropertyName}: {PropertyValue}; ";
    }
    public string PropertyName { get; set; }
    public string PropertyValue { get; set; }
    public string KeyValueParCss { get; set; }
    

}