using Test.Models;

namespace Test.Data
{
    public static class CustomerRepository
    {
        private static readonly List<Customer> _customers = new()
        {
            new Customer { Id = 1, Name = "Thomas Hardy", Address = "89 Chiaroscuro Rd.", City = "Portland", PinCode = "97219", Country = "USA" },
            new Customer { Id = 2, Name = "Maria Anders", Address = "Obere Str. 57", City = "New York", PinCode = "12209", Country = "USA" },
            new Customer { Id = 3, Name = "Fran Wilson", Address = "C/ Araquil, 67", City = "Buffalo", PinCode = "28023", Country = "USA" },
            new Customer { Id = 4, Name = "Dominique Perrier", Address = "25, rue Lauriston", City = "Albany", PinCode = "75016", Country = "USA" },
            new Customer { Id = 5, Name = "Martin Blank", Address = "Via Monte Bianco 34", City = "California", PinCode = "10100", Country = "USA" },
            new Customer { Id = 6, Name = "Mark", Address = "Via Monte Bianco 34", City = "California", PinCode = "12345", Country = "USA" },
            new Customer { Id = 7, Name = "Justin", Address = "Via Monte Bianco 34", City = "California", PinCode = "10444", Country = "USA" },
            new Customer { Id = 8, Name = "Chuang", Address = "qwer1111", City = "Selangor", PinCode = "43300", Country = "Malaysia" },
            new Customer { Id = 9, Name = "Jia", Address = "ads sdffwe qfqwef", City = "Selangor", PinCode = "13123", Country = "Malaysia" },
            new Customer { Id = 10, Name = "Lok", Address = "ads sdffwe qfqwef", City = "KL", PinCode = "32121", Country = "Malaysia" },
            new Customer { Id = 11, Name = "Mei", Address = "ads sdffwe qfqwef", City = "KL", PinCode = "12345", Country = "Malaysia" },
            new Customer { Id = 12, Name = "Jun", Address = "ads sdffwe qfqwef", City = "KL", PinCode = "64334", Country = "Malaysia" }
        };

        public static IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public static Customer? GetById(int Id)
        {
            return _customers.FirstOrDefault(x => x.Id == Id);
        }
    }
}
