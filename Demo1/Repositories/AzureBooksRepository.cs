using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace Demo1
{
	public class AzureBooksRepository : IBooksRepository
	{
		MobileServiceClient client;
		IMobileServiceSyncTable<Book> bookTable;

		public AzureBooksRepository()
		{
			try
			{
				client = new MobileServiceClient("https://demobooks.azurewebsites.net");
				var store = new MobileServiceSQLiteStore("test.db");
				store.DefineTable<Book>();
				client.SyncContext.InitializeAsync(store);

				bookTable = client.GetSyncTable<Book>();
			}
			catch (Exception ex)
			{
			}
		}

		public List<BookViewModel> Get(string filter)
		{
			bookTable.InsertAsync(new Book { Title = "a", Details = "b" }).ConfigureAwait(true);

			return bookTable.ToEnumerableAsync().Result.Select(x => new BookViewModel
			{
				Title = x.Title,
				Details = x.Details
			}).ToList();
		}
	}
}
