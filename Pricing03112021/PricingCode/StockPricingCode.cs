using System;
using System.Collections.Generic;
using System.Text;

namespace Pricing03112021.PricingCode
{
    class StockPricingCode
    {
        public static double StockPricing(int columnM, double itemWeightM, double basePriceM, double quantityM)
        {
            int columnCustomer = columnM;
            double itemWeight = itemWeightM;
            double basePrice = basePriceM;
            double quantity = quantityM;

            int weightColumn = 0;
            int totalColumn;

            double quantityWeight = quantity * itemWeight;
            double price = 0;


            if (quantityWeight <= 50) { weightColumn = 0; }
            if (quantityWeight > 50) { weightColumn = 1; }
            if (quantityWeight > 150) { weightColumn = 2; }
            if (quantityWeight > 200) { weightColumn = 3; }
            if (quantityWeight > 250) { weightColumn = 4; }
            if (quantityWeight > 350) { weightColumn = 5; }
            if (quantityWeight > 500) { weightColumn = 6; }
            if (quantityWeight > 750) { weightColumn = 7; }
            if (quantityWeight > 1000) { weightColumn = 8; }
            if (quantityWeight > 1500) { weightColumn = 9; }
            if (quantityWeight > 2000) { weightColumn = 10; }
            if (quantityWeight > 2500) { weightColumn = 11; }
            if (quantityWeight > 3000) { weightColumn = 12; }
            if (quantityWeight > 3500) { weightColumn = 13; }
            if (quantityWeight > 4000) { weightColumn = 14; }
            if (quantityWeight > 4500) { weightColumn = 15; }
            if (quantityWeight > 5000) { weightColumn = 16; }
            if (quantityWeight > 7500) { weightColumn = 17; }
            if (quantityWeight > 10000) { weightColumn = 18; }
            if (quantityWeight > 15000) { weightColumn = 19; }
            if (quantityWeight > 20000) { weightColumn = 20; }
            if (quantityWeight > 25000) { weightColumn = 21; }
            if (quantityWeight > 30000) { weightColumn = 22; }
            if (quantityWeight > 35000) { weightColumn = 23; }
            if (quantityWeight > 40000) { weightColumn = 24; }
            if (quantityWeight > 50000) { weightColumn = 25; }
            if (quantityWeight > 60000) { weightColumn = 26; }
            if (quantityWeight > 70000) { weightColumn = 27; }
            if (quantityWeight > 80000) { weightColumn = 28; }
            if (quantityWeight > 100000) { weightColumn = 29; }
            if (quantityWeight > 120000) { weightColumn = 30; }
            if (quantityWeight > 160000) { weightColumn = 31; }
            if (quantityWeight > 200000) { weightColumn = 32; }

            totalColumn = columnCustomer + weightColumn;
            if (totalColumn <= 0) { price = basePrice * 4.35; }
            if (totalColumn == 1) { price = basePrice * 4.20; }
            if (totalColumn == 2) { price = basePrice * 4.5; }
            if (totalColumn == 3) { price = basePrice * 3.9; }
            if (totalColumn == 4) { price = basePrice * 3.75; }
            if (totalColumn == 5) { price = basePrice * 3.6; }
            if (totalColumn == 6) { price = basePrice * 3.45; }
            if (totalColumn == 7) { price = basePrice * 3.3; }
            if (totalColumn == 8) { price = basePrice * 3.15; }
            if (totalColumn == 9) { price = basePrice * 3; }
            if (totalColumn == 10) { price = basePrice * 2.85; }
            if (totalColumn == 11) { price = basePrice * 2.77; }
            if (totalColumn == 12) { price = basePrice * 2.65; }
            if (totalColumn == 13) { price = basePrice * 2.55; }
            if (totalColumn == 14) { price = basePrice * 2.45; }
            if (totalColumn == 15) { price = basePrice * 2.35; }
            if (totalColumn == 16) { price = basePrice * 2.25; }
            if (totalColumn == 17) { price = basePrice * 2.15; }
            if (totalColumn == 18) { price = basePrice * 2.05; }
            if (totalColumn == 19) { price = basePrice * 1.95; }
            if (totalColumn == 20) { price = basePrice * 1.85; }
            if (totalColumn == 21) { price = basePrice * 1.75; }
            if (totalColumn == 22) { price = basePrice * 1.7; }
            if (totalColumn == 23) { price = basePrice * 1.67; }
            if (totalColumn == 24) { price = basePrice * 1.64; }
            if (totalColumn == 25) { price = basePrice * 1.61; }
            if (totalColumn == 26) { price = basePrice * 1.58; }
            if (totalColumn == 27) { price = basePrice * 1.55; }
            if (totalColumn == 28) { price = basePrice * 1.52; }
            if (totalColumn == 29) { price = basePrice * 1.47; }
            if (totalColumn == 30) { price = basePrice * 1.42; }
            if (totalColumn == 31) { price = basePrice * 1.37; }
            if (totalColumn == 32) { price = basePrice * 1.32; }
            if (totalColumn == 33) { price = basePrice * 1.28; }
            if (totalColumn == 34) { price = basePrice * 1.24; }
            if (totalColumn == 35) { price = basePrice * 1.21; }
            if (totalColumn == 36) { price = basePrice * 1.18; }
            if (totalColumn == 37) { price = basePrice * 1.16; }
            if (totalColumn == 38) { price = basePrice * 1.14; }
            if (totalColumn == 39) { price = basePrice * 1.12; }
            if (totalColumn >= 40) { price = basePrice * 1.1; }
        //Minumum
            if ((price * quantity) < 100){ price = 100 / quantity; }
            //determine column from weight
            return price;
        }
    }
}
