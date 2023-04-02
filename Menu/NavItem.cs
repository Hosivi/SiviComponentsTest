using Microsoft.AspNetCore.Components;

namespace SiviComponents.Menu;

public class NavItem
{
    public string Text { get; set; }
    public bool IsActive { get; set; }
    public bool IfIconNav { get; set; } = false;
    public string URI { get; set; } = "/";
    public string IconClass { get; set; }
    public string Title { get; set; }


}