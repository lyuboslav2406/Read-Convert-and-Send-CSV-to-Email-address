using Send_Email_with_attached_CSV.Core;
using Send_Email_with_attached_CSV.Core.Contracts;

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