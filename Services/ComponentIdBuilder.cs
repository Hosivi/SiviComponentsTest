using SiviComponents.Base;

namespace SiviComponents.Services;

public class ComponentIdBuilder : IComponentIdBuilder
{
    public string Generate(SiviDomComponentBase component)
    {
        return "sv-" + Guid.NewGuid();
    }
}
