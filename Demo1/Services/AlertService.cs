using System;
namespace Demo1
{
	public class AlertService : Demo1.IAlertService
	{
		public void Show(string message)
		{
			App.Current.MainPage.DisplayAlert("", message, "Cancel");
		}
	}
}
