using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using ThaiAirways.Vo;

namespace ThaiAirways.Model
{
    public class ContentModel
    {
		private static ContentModel instance;

		private ContentModel() { }

		public static ContentModel Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContentModel();
				}
				return instance;
			}
		}

        public async System.Threading.Tasks.Task<List<Product>> GetContensAsync()
        {
            var client = new RestClient("http://13.228.187.190");
            var request = new RestRequest("api/home/promocontent", Method.GET);

            var response = await client.Execute(request);

            ContentItem content = null;
            if(response.IsSuccess)
            {
                content = JsonConvert.DeserializeObject<ContentItem>(response.Content);
            }

            return content.ProductList;

        }
    }
}
