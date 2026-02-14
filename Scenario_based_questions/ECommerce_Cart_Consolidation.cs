using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class ECommerce_Cart_Consolidation
    {
        static void Main()
        {
            var scans = new List<(string sku, int qty)>
            {
                ("A101",2),
                ("B205",1),
                ("A101",3),
                ("C111",-1)
            };

            var result = ConsolidateCart(scans);

            foreach (var kv in result)
                Console.WriteLine($"{kv.Key}: {kv.Value}");
        }

        static Dictionary<string,int> ConsolidateCart(List<(string sku, int qty)> scans)
        {
            var skuQty = new Dictionary<string, int>();

            foreach (var scan in scans)
            {
                if (scan.qty <= 0) continue;

                if (skuQty.ContainsKey(scan.sku))
                    skuQty[scan.sku] += scan.qty;
                else
