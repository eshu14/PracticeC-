using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticeCSharp
{
    class Country
    {
        public string Name { get; }
        public string Code { get; }
        public string Region { get; }
        public int Population { get; }

        public Country(string name, string code, string region, int population)
        {
            this.Population = population;
            this.Name = name;
            this.Code = code;
            this.Region = region;
        }

        public void Display(params Country[] part1)
        {
            Console.WriteLine(part1);
        }
    }
}
