namespace NancyOnHeroku
{
    using System;
    using Nancy.Hosting.Self;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            var uri = new Uri("http://localhost:" + port);

            using (var host = new NancyHost(uri))
            {
                host.Start();

                Console.WriteLine("Running on {0}", uri);

#if DEBUG
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
#else
                Console.WriteLine("Type 'quit' and press ENTER to exit");
                while (Console.ReadLine() != "quit") ;
#endif

                host.Stop();
            }
        }
    }
}
