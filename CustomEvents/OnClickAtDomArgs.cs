using Microsoft.AspNetCore.Components;

namespace SiviComponents.CustomEvents;
  /// <summary>
  /// En desuso
  /// </summary>
public class OnClickAtDomArgs:System.EventArgs
{
	public bool Click { get; set; }
}

[EventHandler("onclickdom", typeof(OnClickAtDomArgs), enableStopPropagation:true, enablePreventDefault:true)]
public static class EventHandlers
{

}