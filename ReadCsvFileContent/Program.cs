using System;
using System.IO;
using System.Net;

namespace ReadCsvFileContent
{
    class Program
    {
        private static Covid19Model model = new Covid19Model();

        static void Main(string[] args)
        {
            var confirmed = Covid19(model.UrlConfirmed);
            Console.WriteLine($"Bestätigte Fälle: { confirmed.Today } ({ confirmed.DayBeforeDiff })");

            var deaths = Covid19(model.UrlDeaths);
            Console.WriteLine($"Todesfälle: { deaths.Today } ({ deaths.DayBeforeDiff })");

            var recovered = Covid19(model.UrlRecovered);
            Console.WriteLine($"Genesen: { recovered.Today } ({ recovered.DayBeforeDiff })");

            Console.ReadLine();
        }

        private static Covid19Model Covid19(string url)
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(url);
                StreamReader reader = new StreamReader(stream);
                string line;
                

                while ((line = reader.ReadLine()) != null)
                {
                    string[] splitted = line.Split(model.Delimiter);
                    if (splitted[1] == model.Country)
                    {
                        model.DayBefore = Int32.Parse(splitted[splitted.Length - 2]);
                        model.Today = Int32.Parse(splitted[splitted.Length - 1]);
                        model.DayBeforeDiff = model.Today - model.DayBefore;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessage = $"Fehler: { ex.Message }";
                return model;
            }

            return model;
        }
    }
}
