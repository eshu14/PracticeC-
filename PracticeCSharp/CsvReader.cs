using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeCSharp
{
    class CsvReader
    {
        private string _csvFilePath;//the path for csv data source.

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine(); // reads the next line in the file.
                for (int i = 0; i < nCountries; i++)
                {
                    string csvLine = sr.ReadLine();
                    countries[i] = ReadCountryFromCsvLine(csvLine);
                }
            }
            return countries;
        }

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine();
                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvFile(csvLine));
                }

            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split((','));
            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse((parts[3]));
            return new Country(name, code, region, population);
        }

        public Country ReadCountryFromCsvFile(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            string name;
            string code;
            string region;
            string popText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            // TryParse leaves population=0 if can't parse
            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);


        }
    }
}
