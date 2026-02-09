using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class StoreItems
    {
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

    }
    public class Invoice_Generator
    {
        public static void Main(String[] args)
        {
            //List<StoreItems> items_ = new List<StoreItems>();
            //StoreItems storeItems;
            //items_.Add(new StoreItems { ItemName = "Wheat", Price = 200, Qty = 20 });
            //items_.Add(new StoreItems { ItemName = "Rice", Price = 450, Qty = 15 });
            //items_.Add(new StoreItems { ItemName = "Paper", Price = 20, Qty = 10 });
            //foreach(var items in items_)
            //{
            //    Console.WriteLine(items.ItemName);
            //    Console.WriteLine(items.Price);
            //    Console.WriteLine(items.Qty);
            //}

            // With stringBuilder
            StringBuilder invoice = new StringBuilder();

            invoice.AppendLine("----- INVOICE -----");
            invoice.AppendLine("Item\tQty\tPrice\tTotal");
            invoice.AppendLine("-------------------");

            double grandTotal = 0;

            string item;
            int qty;
            double price;
            double total;

            item = "Wheat";
            qty = 20;
            price = 200;
            total = qty * price;
            grandTotal += total;
            invoice.Append(item).Append('\t').Append(qty).Append('\t').Append(price).Append('\t').AppendLine(total.ToString());

            item = "Rice";
            qty = 15;
            price = 450;
            total = qty * price;
            grandTotal += total;
            invoice.Append(item).Append('\t').Append(qty).Append('\t').Append(price).Append('\t').AppendLine(total.ToString());

            item = "Paper";
            qty = 10;
            price = 20;
            total = qty * price;
            grandTotal += total;
            invoice.Append(item).Append('\t').Append(qty).Append('\t').Append(price).Append('\t').AppendLine(total.ToString());

            invoice.AppendLine("-------------------");
            invoice.Append("Grand Total: ").Append(grandTotal);

            Console.WriteLine(invoice.ToString());
        }
    }
}
