using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Peripheral : Product, IPeripheral
    {
        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            //return base.ToString();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString() + $"Connection Type: { this.ConnectionType}");

            return sb.ToString().Trim();
        }
    }
}
