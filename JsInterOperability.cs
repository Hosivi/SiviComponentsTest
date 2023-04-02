using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SiviComponents.Forms;

namespace SiviComponents;
/// <summary>
/// Servicios generales de js
/// </summary>
public class JsInterOperability:IAsyncDisposable
{
	private readonly Lazy<Task<IJSObjectReference>> module;

	public JsInterOperability(IJSRuntime js)
	{
		module = new(() => js.InvokeAsync<IJSObjectReference>(
			"import", "./_content/SiviComponents/js/SVDropDownList.js").AsTask());
	}

	public async void OnDetectClick()
	{
		var m = await module.Value;
		 await m.InvokeVoidAsync("onClickDomDetect");
	}

	public async ValueTask DisposeAsync()
	{
		if (module.IsValueCreated)
		{
			var m = await module.Value;
			await m.DisposeAsync();
		}
	}
}