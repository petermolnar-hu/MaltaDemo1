using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Demo1
{
	public class Demo2ViewModel : BaseViewModel
	{
		readonly IBooksRepository booksRepository;
		readonly IAlertService alertService;

		public Demo2ViewModel()
		{
			booksRepository = DependencyService.Get<IBooksRepository>();
			alertService = DependencyService.Get<IAlertService>();
			MessagingCenter.Subscribe<Demo1ViewModel, string>(this, "Hello", (s, args) =>
			{
				Name = args;
				books = booksRepository.Get(Name);
				RaisePropertyChanged("Books");
			});
			DetailsCommand = new Command(OnDetails);
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

		List<BookViewModel> books = new List<BookViewModel>();
		public List<BookViewModel> Books
		{
			get 
			{
				return books; 
			}
		}

		public ICommand DetailsCommand { get; }

		void OnDetails(object item)
		{
			//BookViewModel bookItem = (BookViewModel)item;
			alertService.Show("Enough, i'm jsut a demo");
		}
	}
}
