using System;
using System.Collections.Generic;
using System.Text;

namespace Pricing03112021.Models
{
    public class ItemEntry
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double ItemGauge { get; set; }
        public string ItemColor { get; set; }
        public string ItemSurface { get; set; }
        public string ItemMaterial { get; set; }
        public double ItemWidth { get; set; }
        public double ItemLength { get; set; }
        public string UnitOfMeasure { get; set; }
        public double ItemWeightFactor { get; set; }
        public double ItemWeight { get; set; }
        public double ItemUpCharge { get; set; }
        public double ItemBasePrice { get; set; }
    }
}
