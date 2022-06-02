using System.Xml.Linq;
using System.Globalization;

namespace TradingDayDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            this.Date = DateOnly.Parse(tradingDayNode.Attribute("time").Value);

            //CultureInfo ciEzb = new("en-US");
            //NumberFormatInfo nfiEzb = ciEzb.NumberFormat;

            NumberFormatInfo nfiEzb = new() { NumberDecimalSeparator = "." };


            this.ExchangeRates = tradingDayNode.Elements()
                                            .Select(el => new ExchangeRate()
                                            {
                                                Symbol = el.Attribute("currency").Value,
                                                EuroValue = Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)
                                            })
                                            .ToList();

            //this.ExchangeRates = tradingDayNode.Elements()
            //    .Select(el => new ExchangeRatePositionalRecordClass(el.Attribute("currency").Value, Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)))
            //    .ToList();
        }

        public TradingDay(XElement tradingDayNode, bool useRecords)
        {
            this.Date = DateOnly.Parse(tradingDayNode.Attribute("time").Value);

            NumberFormatInfo nfiEzb = new() { NumberDecimalSeparator = "." };

            if (useRecords)
            {
                this.ExchangeRatesPositionalRecordStructs = tradingDayNode.Elements()
                    .Select(el => new ExchangeRatePositionalRecordStruct(el.Attribute("currency").Value, Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)))
                    .ToList();
            }
            else
            {
                this.ExchangeRatesTuple = tradingDayNode.Elements()
                    .Select(
                        el => new Tuple<string, double>(
                            el.Attribute("currency").Value, 
                            Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)
                        )).ToList();
            }
        }

        public DateOnly Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
        public List<ExchangeRatePositionalRecordStruct> ExchangeRatesPositionalRecordStructs { get; set; }

        public List<Tuple<string, double>> ExchangeRatesTuple { get; set; }
    }
}