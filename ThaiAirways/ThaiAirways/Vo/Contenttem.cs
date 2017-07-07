using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ThaiAirways.Vo
{
    public class ContentItem
    {

		[JsonProperty("Message")]
		public string Message { get; set; }

		[JsonProperty("Success")]
        public bool Success { get; set; }

		[JsonProperty("Content")]
		public List<Product> ProductList { get; set; }
	}

	public class Product
	{

		[JsonProperty("Title")]
		public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Image")]
		public string Image { get; set; }
	}



}
