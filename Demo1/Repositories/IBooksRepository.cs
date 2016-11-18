using System;
using System.Collections.Generic;

namespace Demo1
{
	public interface IBooksRepository
	{
		List<BookViewModel> Get(string filter);
	}
}
