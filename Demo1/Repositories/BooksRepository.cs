using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1
{
	public class BooksRepository : IBooksRepository
	{
		public List<BookViewModel> Get(string filter)
		{
			return Enumerable.Range(0, 10).Select(x => new BookViewModel
			{
				Title = "title " + x,
				Details = "details " + x
			}).ToList();
		}
	}
}
