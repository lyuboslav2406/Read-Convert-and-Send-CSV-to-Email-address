
namespace Send_Email_with_attached_CSV.Messages
{
    public static class OutputMessages
    {
        //Input
        public const string inputFilePath = "Please enter the path to your file. \n Example: D:\\Employees.csv";       

        public const string emailSender = "Please enter your email address. \n Test email: testcsvreport@gmail.com";

        public const string emailPassword = "Please enter your password. \n Test password: sendreport";

        public const string emailReceiver = "Please enter the recipient's email";

        //Еrrors
        public const string incorrectPath = "The path is incorrect, please try again!";

        public const string incorrectEmail = "Email doesn't exist. Please enter a valid email address!";

        //Email
        public const string emailTitle = "CSV Report";
        
        public const string emailBody = "CSV file is attached to the email: ReportByCountry"; 

        public const string sendBy = "Lyuboslav Pashaliyski";
        
        public const string sendTo = "Hitachi Solutions BG";
        
        public const string successfullySend = "Email sent successfully!";         
    }
}
