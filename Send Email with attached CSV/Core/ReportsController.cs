using Send_Email_with_attached_CSV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static Send_Email_with_attached_CSV.Program;

namespace Send_Email_with_attached_CSV.Core
{
    public class ReportsController : IReportsController
    {
        private readonly List<Employee> employees;

        public ReportsController(List<Employee> employees)
        {
            this.employees = employees;
        }

        public List<List<string>> CreateReportByCountry()
        {
            var finalResult = employees.GroupBy(e => e.Country);

            var readyForImport = new List<List<string>>();

            foreach (var item in finalResult)
            {
                var country = new List<string>();

                var medianCount = Math.Ceiling(item.Count() / 2.0);

                country.Add(item.Key);
                country.Add(item.Average(s => s.Score).ToString());
                country.Add(item.OrderBy(s => s.Score).Skip((int)medianCount - 1).FirstOrDefault().Score.ToString());
                country.Add(item.Max(s => s.Score).ToString());
                country.Add(item.OrderByDescending(s => s.Score).FirstOrDefault().FirstName + " "
                    + item.OrderByDescending(s => s.Score).FirstOrDefault().LastName);
                country.Add(item.Min(s => s.Score).ToString());
                country.Add(item.OrderBy(s => s.Score).FirstOrDefault().FirstName + " "
                    + item.OrderBy(s => s.Score).FirstOrDefault().LastName);
                country.Add(item.Count().ToString());

                readyForImport.Add(country);
            }
            var orderedReadyFormImport = readyForImport.OrderByDescending(a => a[1]).ToList();

            return orderedReadyFormImport;
            ;
        }
    }
}
