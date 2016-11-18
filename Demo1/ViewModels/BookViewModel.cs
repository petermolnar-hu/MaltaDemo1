using System;
namespace Demo1
{
	public class BookViewModel : BaseViewModel
	{
		string title;
		public string Title
		{
			get { return title; }
			set
			{
				if (title != value)
				{
					title = value;
					RaisePropertyChanged();
				}
			}
		}

		string details;
		public string Details
		{
			get { return details; }
			set
			{
				if (details != value)
				{
					details = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
