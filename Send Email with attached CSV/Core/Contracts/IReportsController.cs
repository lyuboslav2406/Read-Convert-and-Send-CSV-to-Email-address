using System;
using System.Collections.Generic;
using System.Text;

namespace Send_Email_with_attached_CSV.Core.Contracts
{
    interface IReportsController
    {
        List<List<string>> CreateReportByCountry();
    }
}
