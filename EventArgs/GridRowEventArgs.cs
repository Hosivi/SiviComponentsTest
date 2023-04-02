using SiviComponents.DataGrid;
using SiviComponents.Modal;

namespace SiviComponents.EventArgs;

/// <summary>
/// Debe irse a custom events
/// </summary>
/// <typeparam name="T"></typeparam>
public class GridRowEventArgs<T> : System.EventArgs
{
	public SVRow<T> Row { get; set; }
}

public class ModalEventArgs : System.EventArgs
{
	public ModalEventArgs(string? title)
	{
		Title = title;
	}


	public string Title { get; set; }
	public SVModal Modal { get; set; }
}