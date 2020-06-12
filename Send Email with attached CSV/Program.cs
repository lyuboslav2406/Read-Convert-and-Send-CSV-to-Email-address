using CsvHelper;
using Send_Email_with_attached_CSV.Core;
using Send_Email_with_attached_CSV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Send_Email_with_attached_CSV
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}