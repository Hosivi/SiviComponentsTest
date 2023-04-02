namespace SiviComponents.Modal;

public interface INotiticatorComponentService
{
	public void ShowNotification(string message, Action AfterAcept);
}
