using CsvHelper;
using Send_Email_with_attached_CSV.Core.Contracts;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using static Send_Email_with_attached_CSV.Program;

namespace Send_Email_with_attached_CSV.Core
{
    public class CsvController : ICsvController
    {
        private readonly string path;

        public CsvController(string path)
        {
            this.path = path;
        }

        public List<string> ReadInCSV()
        {
            var result = new List<string>();
            string value;

            using (TextReader fileReader = File.OpenText(path))
            {
                var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value.Trim());
                    }
                }
            }
            return result;
        }

        public List<Employee> ConvertListToEmpleyees(List<string> csvList)
        {
            var employees = new List<Employee>();

            for (int i = 6; i < csvList.Count; i += 6)
            {
                var id = int.Parse(csvList[i]);
                var firstName = csvList[i + 1];
                var lastNameName = csvList[i + 2];
                var country = csvList[i + 3];
                var city = csvList[i + 4];
                var score = int.Parse(csvList[i + 5]);

                var employer = new Employee(id, firstName, lastNameName, country, city, score);

                employees.Add(employer);
            }
            return employees;
        }

        public void WriteInCsv(List<List<string>> readyForImport)
        {
            string[] titleLine = { "Country", "Average Score", "Median Score", "Max Score", "Max Score Name", "Min Score", "Min Score Name", "Count" };

            using (var writer = new StreamWriter(@"..\..\..\result.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (var word in titleLine)
                {
                    csv.WriteField(word);
                }
                csv.NextRecord();

                foreach (var country in readyForImport)
                {
                    foreach (var item in country)
                    {
                        csv.WriteField(item);
                    }
                    csv.NextRecord();
                }
            };
        }
    }
}
