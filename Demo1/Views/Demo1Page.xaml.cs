using Xamarin.Forms;

namespace Demo1
{
	public partial class Demo1Page : ContentPage
	{
		public Demo1Page()
		{
			BindingContext = new Demo1ViewModel();
			InitializeComponent();
		}
	}
}
