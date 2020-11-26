using System;
using System.Collections.Generic;

namespace PracticeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            string filePath = @"C:\Users\ramanie_adm\source\repos\PracticeCSharp\PracticeCSharp\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);
            Country[] countries = reader.ReadFirstNCountries(10);

            List<Country> countriesList = reader.ReadAllCountries();
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countriesList.FindIndex((x => x.Population < 2_000_000));
            countriesList.Insert(lilliputIndex, lilliput);

            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population)} : {country.Name}");
                
            }
            Console.WriteLine("Entering a new line for the List display");
            foreach (Country country in countriesList)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population)} : {country.Name}");

            }

        }
    }
}
