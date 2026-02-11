using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Scenario_based_questions
{
    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal CurrentPrice { get; }
        InstrumentType Type { get; }
    }

    public enum InstrumentType { Stock, Bond, Option, Future }
    public enum Trend { Upward, Downward, Sideways }

    public class Portfolio<T> where T : IFinancialInstrument
    {
        private Dictionary<T, int> _holdings = new();

        public void Buy(T instrument, int quantity, decimal price)
        {
            if (quantity <= 0 || price <= 0)
                throw new ArgumentException();

            if (_holdings.ContainsKey(instrument))
                _holdings[instrument] += quantity;
            else
                _holdings[instrument] = quantity;
        }

        public decimal? Sell(T instrument, int quantity, decimal currentPrice)
        {
            if (!_holdings.ContainsKey(instrument) ||
                _holdings[instrument] < quantity)
                return null;

            _holdings[instrument] -= quantity;

            if (_holdings[instrument] == 0)
                _holdings.Remove(instrument);

            return quantity * currentPrice;
        }

        public decimal CalculateTotalValue()
        {
            return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
        }

        public Dictionary<T, int> GetHoldings() => _holdings;
    }

    public class Stock : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Stock;
        public string CompanyName { get; set; }
        public decimal DividendYield { get; set; }
    }

    public class Bond : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Bond;
        public DateTime MaturityDate { get; set; }
        public decimal CouponRate { get; set; }
    }

    public class PriceHistory<T> where T : IFinancialInstrument
    {
        private Dictionary<T, List<decimal>> _history = new();

        public void AddPrice(T instrument, decimal price)
        {
            if (!_history.ContainsKey(instrument))
                _history[instrument] = new List<decimal>();

            _history[instrument].Add(price);
        }

        public decimal? GetMovingAverage(T instrument, int days)
        {
            if (!_history.ContainsKey(instrument))
                return null;

            var prices = _history[instrument].TakeLast(days);

            if (!prices.Any())
                return null;

            return prices.Average();
        }

        public Trend DetectTrend(T instrument)
        {
            if (!_history.ContainsKey(instrument) ||
                _history[instrument].Count < 2)
                return Trend.Sideways;

            var list = _history[instrument];

            if (list.Last() > list.First())
                return Trend.Upward;

            if (list.Last() < list.First())
                return Trend.Downward;

            return Trend.Sideways;
        }
    }

    class Financial_Trading
    {
        static void Main()
        {
            var stock = new Stock
            {
                Symbol = "AAPL",
                CurrentPrice = 200,
                CompanyName = "Apple"
            };

            var bond = new Bond
            {
                Symbol = "GOVT",
                CurrentPrice = 100,
                MaturityDate = DateTime.Now.AddYears(5),
                CouponRate = 5
            };

            var portfolio = new Portfolio<IFinancialInstrument>();
            portfolio.Buy(stock, 10, 190);
            portfolio.Buy(bond, 5, 95);

            Console.WriteLine("Total Value: " +
                portfolio.CalculateTotalValue());

            var history = new PriceHistory<IFinancialInstrument>();
            history.AddPrice(stock, 180);
            history.AddPrice(stock, 190);
            history.AddPrice(stock, 200);

            Console.WriteLine("Moving Avg: " +
                history.GetMovingAverage(stock, 3));

            Console.WriteLine("Trend: " +
                history.DetectTrend(stock));
        }
    }
}
