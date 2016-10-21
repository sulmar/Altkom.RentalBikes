using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;


namespace Altkom.RentalBikes.ConsoleClient
{
    public class RestBikesService
    {
     //   private const string baseUri = "http://localhost:52582/api/";

        public async Task<IList<Bike>> GetBikesAsync()
        {
            using (var client = new HttpClient())
            {
                var request = "http://localhost:52582/api/bikes";

                client.DefaultRequestHeaders.Add("Secret-Key", "12345");

                var response = await client.GetAsync(request);

                // var content = await response.Content.ReadAsStringAsync();

                var bikes = await response.Content.ReadAsAsync<IList<Bike>>();

                return bikes;
            }
        }

        public async Task<Bike> GetBikeAsync(int bikeId)
        {
            using (var client = new HttpClient())
            {
                var request = $"http://localhost:52582/api/bikes/{bikeId}";

                client.DefaultRequestHeaders.Add("Secret-Key", "12345");

                var response = await client.GetAsync(request);

                // var content = await response.Content.ReadAsStringAsync();

                var bike = await response.Content.ReadAsAsync<Bike>();

                return bike;
            }
        }


        public async Task AddBike(Bike bike)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Secret-Key", "12345");

                var request = $"http://localhost:52582/api/bikes";

                var response = await client.PostAsync<Bike>(request, bike, new JsonMediaTypeFormatter());

                bike = await response.Content.ReadAsAsync<Bike>();
            }
        }


        public async Task UpdateBike(Bike bike)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Secret-Key", "12345");

                var request = $"http://localhost:52582/api/bikes/{bike.Id}";

                var response = await client.PutAsync<Bike>(request, bike, new JsonMediaTypeFormatter());
            }
        }

        public async Task Delete(int bikeId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Secret-Key", "12345");

                var request = $"http://localhost:52582/api/bikes/{bikeId}";

                var response = await client.DeleteAsync(request);
            }
        }
    }
}
