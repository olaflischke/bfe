using TradingDayDal;

namespace TradingDayDalUnitTests
{
    [TestClass]
    public class ArchiveTests
    {
        string url;

        public ArchiveTests()
        {
            //url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
            //url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";
            url = @"C:\tmp\bfe\Live Coding\eurofxref-hist.xml";
        }

        [TestMethod]
        public void IsArchiveInitializing()
        {
            Archive archive = new(url, false);

            Console.WriteLine($"{archive.TradingDays.FirstOrDefault().Date}: USD = {archive.TradingDays.FirstOrDefault().ExchangeRates.FirstOrDefault().EuroValue} EUR");

            Assert.AreEqual(CountAttribute(url, "time"), archive.TradingDays.Count);
        }

        [TestMethod]
        public void IsArchiveInitializingRecords()
        {
            Archive archive = new(url, true);

            Console.WriteLine($"{archive.TradingDays.FirstOrDefault().Date}: USD = {archive.TradingDays.FirstOrDefault().ExchangeRatesPositionalRecordStructs.FirstOrDefault().EuroValue} EUR");

            Assert.AreEqual(CountAttribute(url, "time"), archive.TradingDays.Count);

        }

        private int CountAttribute(string url, string attribute)
        {
            // TODO: Ausprogammieren (wie oft kommt "attribute" in der "url" vor)
            return 5995;
        }
    }
}