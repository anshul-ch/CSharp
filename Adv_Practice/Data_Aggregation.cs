using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Sale
    {
        public string Region { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class SalesAggregator
    {
        public Dictionary<string, decimal> TotalSalesByRegion(List<Sale> sales)
        {
            return sales
                .GroupBy(s => s.Region)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount));
        }

        public Dictionary<string, string> TopCategoryPerRegion(List<Sale> sales)
        {
            return sales
                .GroupBy(s => new { s.Region, s.Category })
                .Select(g => new { g.Key.Region, g.Key.Category, Total = g.Sum(x => x.Amount) })
                .GroupBy(x => x.Region)
                .Select(g => g.OrderByDescending(x => x.Total).First())
                .OrderBy(x => x.Region)
                .ToDictionary(x => x.Region, x => x.Category);
        }

        public DateTime BestSalesDay(List<Sale> sales)
        {
            return sales
                .GroupBy(s => s.Date.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(x => x.Amount) })
                .OrderByDescending(x => x.Total)
                .First()
                .Date;
        }
    }

    [TestFixture]
    public class SalesAggregatorTests
    {
        [Test]
        public void AggregationWorks()
        {
            var sales = new List<Sale>
            {
                new Sale { Region="North", Category="Electronics", Amount=100, Date=new DateTime(2024,1,1)},
                new Sale { Region="North", Category="Clothing", Amount=300, Date=new DateTime(2024,1,2)},
                new Sale { Region="South", Category="Clothing", Amount=200, Date=new DateTime(2024,1,1)}
            };

            var agg = new SalesAggregator();

            Assert.That(agg.TotalSalesByRegion(sales)["North"], Is.EqualTo(400));
            Assert.That(agg.TopCategoryPerRegion(sales)["North"], Is.EqualTo("Clothing"));
            Assert.That(agg.BestSalesDay(sales), Is.EqualTo(new DateTime(2024, 1, 1)));
        }
    }

    class Data_Aggregation
    {
        static void Main() { }
    }
}
