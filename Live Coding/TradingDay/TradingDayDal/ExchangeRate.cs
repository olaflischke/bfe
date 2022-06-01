namespace TradingDayDal
{
    public class ExchangeRate
    {
        public string Symbol { get; set; }
        public double EuroValue { get; set; }
    }

    // Record Classes, C# 9:
    // Postional Record: Init-Only
    public record class ExchangeRatePositionalRecordClass(string Symbol, double EuroValue);

    public record class ExchangeRateRecordClass
    {
        public string Symbol { get; set; }
        public double EuroValue { get; set; }
    }

    // Record Structs, C# 10:
    // recStruct1 == recStruct2: true, wenn alle Werte gleich
    public record struct ExchangeRateRecordStruct()
    {
        public string Symbol { get; set; } = string.Empty;
        public double EuroValue { get; set; } = 0;

        public override string ToString()
        {
            return $"ExchangeRate: {this.Symbol}, {this.EuroValue}";
        }
    }

    public record struct ExchangeRatePositionalRecordStruct(string Symbol, double EuroValue);

    public record struct ExchangeRateStructHybrid(string Symbol)
    {
        public double EuroValue { get; set; } = 0;
    }
}