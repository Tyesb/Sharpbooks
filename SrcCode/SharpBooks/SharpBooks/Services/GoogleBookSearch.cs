using SharpBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using SharpBooks.ExtensionMethods;
using System.Diagnostics;

namespace SharpBooks.Services
{
    public class GoogleBookSearch : IBookSearch
    {
        private String ApiKey = "&apikey=AIzaSyCHSTt_Mq4BvLWsGOd1KMSsk2L-Q8jGWNU"; //should be in web config

        public async Task<IEnumerable<Models.Book>> GeneralSearch(string input)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" https://www.googleapis.com/books/v1/volumes"); //should be in web config


                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                String URIEncodedQueryString = HttpUtility.UrlEncode(input);
                string query = "?q=" + URIEncodedQueryString + ApiKey;


                // New code:
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    string peek = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(peek);
; GoogleBookResult result = await response.Content.ReadAsAsync<GoogleBookResult>();
                    if (result.items == null)
                    {
                        result.items = new List<GoogleBookItem>();
                    }
                    return result.ToBooks();
                }
                else
                {
                    throw new Exception("Waaaaaahhaha google book generl search fail");
                }
            }

        }


        public async Task<IEnumerable<Models.Book>> TitleSearch(string input)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" https://www.googleapis.com/books/v1/volumes"); //should be in web config


                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                String URIEncodedQueryString = HttpUtility.UrlEncode(input);

                // New code:
                HttpResponseMessage response = await client.GetAsync("?q=intitle:" + URIEncodedQueryString + ApiKey);
                if (response.IsSuccessStatusCode)
                {
                    string peek = await response.Content.ReadAsStringAsync();
                    GoogleBookResult result = await response.Content.ReadAsAsync<GoogleBookResult>();
                    if (result.items == null)
                    {
                        result.items = new List<GoogleBookItem>();
                    }
                    return result.ToBooks();
                }
                else
                {
                    throw new Exception("Waaaaaahhaha google book by title fail");
                }
            }

        }















    }
}