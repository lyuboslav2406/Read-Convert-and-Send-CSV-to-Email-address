using System;
using System.Collections.Generic;
using System.Text;
using static Send_Email_with_attached_CSV.Program;

namespace Send_Email_with_attached_CSV.Core.Contracts
{
    interface ICsvController
    {
        public List<string> ReadInCSV();

        public List<Employee> ConvertListToEmpleyees(List<string> csvList);

        public void WriteInCsv(List<List<string>> readyForImport);

        //sendreport
        //testcsvreport@gmail.com
    }
}
