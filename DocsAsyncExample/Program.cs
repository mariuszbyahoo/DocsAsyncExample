using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocsAsyncExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Now the tasks will start concurrently, and will finish 
            // after completion of each one of them.
            Console.WriteLine("Starting the countdown");
            Task<Toast> toastTask = ToastBread();
            Task<Bacon> baconTask = FryBacon();
            Task<Coffee> cupTask = PourCoffee();

            var cup = await cupTask;
            var bacon = await baconTask;
            var toast = await toastTask;
            Console.WriteLine("Toast is ready");
        }

        static async Task<Coffee>  PourCoffee()
        {
            Coffee coffee;
            await Task.Delay(5000).ContinueWith(t =>
                  coffee = new Coffee()
            );
            Console.WriteLine("Coffee is ready 5s");

            return new Coffee();
        }
        static async Task<Bacon> FryBacon()
        {
            Bacon bacon;
            await Task.Delay(10000).ContinueWith(t =>
                bacon = new Bacon());
            Console.WriteLine("Bacon is ready 10s"); ;
            return new Bacon();
        }

        static async Task<Toast> ToastBread()
        {
            Toast toast;
            await Task.Delay(3000).ContinueWith(t =>
                toast = new Toast()
            );
            Console.WriteLine("Toast is ready 3s");
            return new Toast();
        }
    }
}
