using System;
using Newtonsoft.Json;

namespace Demo1
{
	public class Book
	{
		public string Id { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "details")]
		public string Details { get; set; }
	}
}
