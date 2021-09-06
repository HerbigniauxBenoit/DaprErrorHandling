using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DaprApiCall
{
    class Program
    {
        static HttpClient client = new();

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:3500/v1.0/invoke/apiapp/method/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(
                $"product");

                // Deserialize the updated product from the response body.
                var product = await response.Content.ReadAsStringAsync();
                Console.WriteLine(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
