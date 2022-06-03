using Microsoft.EntityFrameworkCore;
using NordwindDal.Model;

namespace NordwindTests
{
    public class Tests
    {
        NorthwindContext context = new NorthwindContext();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            int anzahl = context.Customers.Count();
            Assert.AreEqual(92, anzahl);
        }

        [Test]
        public void Test2()
        {
            List<string> countries = context.Customers.Select(cu => cu.Country).Distinct().ToList();

            foreach (string item in countries)
            {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void Test3()
        {
            var qProducts = context.Customers
                                            .Include(cu => cu.Orders)
                                            .ThenInclude(od => od.OrderDetails)
                                            .ThenInclude(od => od.Product)
                                            .Select(cu => cu);

            foreach (var item in qProducts)
            {
                Console.WriteLine($"{item.CompanyName}: {item.Orders?.FirstOrDefault()?.OrderDetails?.FirstOrDefault()?.Product?.ProductName}");
            }

        }

        [Test]
        public void Test4()
        {
            Customer customer = context.Customers.Find("ALFKI");
            customer.ContactName = "Maria Schmitt";

            context.SaveChanges();
        }
    }
}