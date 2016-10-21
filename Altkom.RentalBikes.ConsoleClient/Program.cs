using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // Task.Run(()=> GetBikesTest());

            // Task.Run(() => GetBikeTest());

            // Task.Run(() => AddBikeTest());

           // Task.Run(() => UpdateBikeTest());

        //    Task.Run(() => DeleteBikeTest());

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();

        }

       

        private static async void GetBikeTest()
        {
            var bikesService = new RestBikesService();

            var bike = await bikesService.GetBikeAsync(1);

            Console.WriteLine(bike);


        }

        private static async void GetBikesTest()
        {
            var bikesService = new RestBikesService();

            var bikes = await bikesService.GetBikesAsync();

            bikes.ToList()                
                .ForEach(bike => Console.WriteLine(bike));
        }


        private static async void AddBikeTest()
        {
            var bikesService = new RestBikesService();

            var bike = new Bike { Number = "R010", BikeType = BikeType.Kids, Color = "Pink", IsActive = true };

            await bikesService.AddBike(bike);
        }

        private static async void UpdateBikeTest()
        {
            var bikesService = new RestBikesService();

            var bike = new Bike { BikeId = 1, Number = "R010", BikeType = BikeType.Kids, Color = "Pink", IsActive = true };

            await bikesService.UpdateBike(bike);
        }

        private static async void DeleteBikeTest()
        {
            var bikesService = new RestBikesService();

            await bikesService.Delete(2);
        }
    }
}
