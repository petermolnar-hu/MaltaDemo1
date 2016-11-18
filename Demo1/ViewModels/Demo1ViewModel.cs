using System.Windows.Input;
using Xamarin.Forms;

namespace Demo1
{
	public class Demo1ViewModel : BaseViewModel
	{
		public Demo1ViewModel()
		{
			name = "test";
			CheckValidityCommand = new Command(OnCheckValidity);
		}

		string name;
		public string Name
		{
			get { return name; }
			set
			{
				if (name != value)
				{
					name = value;
					RaisePropertyChanged();
				}
			}
		}

		public ICommand CheckValidityCommand { get; }

		void OnCheckValidity(object parameter)
		{
			var newPage = new Demo2Page();
			MessagingCenter.Send(this, "Hello", Name);
			((NavigationPage)App.Current.MainPage).PushAsync(newPage);
		}
	}
}