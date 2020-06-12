using Send_Email_with_attached_CSV.Core.Contracts;
using Send_Email_with_attached_CSV.Messages;
using System;
using System.IO;

namespace Send_Email_with_attached_CSV.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {           
            //CSV path input
            Console.WriteLine(OutputMessages.inputFilePath);

            string path = Console.ReadLine();

            while (!File.Exists(path))
            {
                Console.WriteLine(OutputMessages.incorrectPath);
                path = Console.ReadLine();
            }

            //Sender email adress and password input
            Console.WriteLine(OutputMessages.emailSender);

            string emailSender = Console.ReadLine();

            var email = new EmailController();

            while (!email.IsValidEmail(emailSender))
            {
                Console.WriteLine(OutputMessages.incorrectEmail);
                emailSender = Console.ReadLine();
            }            

            Console.WriteLine(OutputMessages.emailPassword);

            string emailPassword = Console.ReadLine();

            //Receiver email adress input
            Console.WriteLine(OutputMessages.emailReceiver);

            string emailReceiver = Console.ReadLine();

            while (!email.IsValidEmail(emailReceiver))
            {
                Console.WriteLine(OutputMessages.incorrectEmail);
                emailReceiver = Console.ReadLine();
            }

            //CSV Read
            var csv = new CsvController(path);

            var list = csv.ReadInCSV();

            //Convert CSV in empleyees list
            var allEmpleyees = csv.ConvertListToEmpleyees(list);

            //Create new report by country
            var readyForImport = new ReportsController(allEmpleyees);

            csv.WriteInCsv(readyForImport.CreateReportByCountry());

            //Send email with report           
            email.sendMail(emailSender, emailPassword, emailReceiver);
        }       
    }    
}