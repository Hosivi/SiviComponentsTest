//using System.Data;

//namespace SiviComponents.Services;

//public class  MessagingCenter
//{
//	public delegate void StateNotify(object sender, StateArgs args);
//}

//public class StateArgs
//{
//	public string? State { get; set; }
//	public string? Message { get; set; }
//	public Action? ActionBeforeEvent { get; set; }
//	public Action? ActionAfterEvent { get; set; }

//}

//public class SVComponentEvents : MessagingCenter
//{
//	public event  StateNotify OnNotify;

//	public void Notify(object sender, StateArgs e)
//	{
//		if (OnNotify is not null)
//		{
//			OnNotify(sender, e);
//		}
//	}
//}