using System.Data;

namespace Send_Email_with_attached_CSV
{
    public partial class Program
    {
        public class Employee
        {
            public Employee(int id, string firstName, string lastName, string country, string city, int score)
            {
                this.Id = id;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Country = country;
                this.City = city;
                this.Score = score;
            }

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public int Score { get; set; }
        }
    }
}
