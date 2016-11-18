using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo1
{
	public partial class Demo2Page : ContentPage
	{
		public Demo2Page()
		{
			BindingContext = new Demo2ViewModel();
			InitializeComponent();
		}
	}
}
