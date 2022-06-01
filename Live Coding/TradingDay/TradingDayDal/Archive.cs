using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TradingDayDal
{
    public class Archive
    {
        /// <summary>
        /// Konstruktor für ein Archive.
        /// </summary>
        /// <param name="url">URL einer GESMES-XML-Datei</param>
        public Archive(string url, bool useRecords)
        {
            this.TradingDays = GetData(url, useRecords);
        }

        private List<TradingDay>? GetData(string url, bool useRecords)
        {
            XDocument document = XDocument.Load(url);

            IEnumerable<TradingDay> q = null;

            if (!useRecords)
            {
                q = document.Root?.Descendants()
                          .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
                          .Select(xe => new TradingDay(xe));

            }
            else
            {
                q = document.Root?.Descendants()
          .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
          .Select(xe => new TradingDay(xe, true));

            }

            return q?.ToList();

            //List<TradingDay> results = new List<TradingDay>();

            //foreach (var item in q)
            //{
            //    TradingDay day = new TradingDay() { Date = DateOnly.Parse(item.Attribute("time").Value) };
            //    results.Add(day);
            //}

            //return results;

        }

        /// <summary>
        /// Die TradingDays, die das Archive verwaltet
        /// </summary>
        public List<TradingDay>? TradingDays { get; set; }
    }
}
