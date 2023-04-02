using SiviComponents.Base;

namespace SiviComponents.Services;

public interface IComponentIdBuilder
{
    string Generate(SiviDomComponentBase component);
}