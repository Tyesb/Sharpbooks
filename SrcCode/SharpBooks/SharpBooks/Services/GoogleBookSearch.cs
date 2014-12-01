using SharpBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace SharpBooks.Services
{
    public class GoogleBookSearch : IBookSearch
    {
        private String ApiKey = "&apikey=AIzaSyCHSTt_Mq4BvLWsGOd1KMSsk2L-Q8jGWNU";

        public async Task<IEnumerable<Models.Book>> Search(string input)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" https://www.googleapis.com/books/v1/volumes");


                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("?q=" + input + ApiKey);
                if (response.IsSuccessStatusCode)
                {
                    GoogleBookResult product = await response.Content.ReadAsAsync<GoogleBookResult>();
                }
            }
            throw new NotImplementedException();
        }




    }
}