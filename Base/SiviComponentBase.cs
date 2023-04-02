using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SiviComponents.Base;

public class SiviComponentBase : ComponentBase
{
	[Inject] protected IJSRuntime? Js { get; set; }
	public IJSObjectReference module;
}