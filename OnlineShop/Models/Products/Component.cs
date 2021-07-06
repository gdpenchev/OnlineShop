using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Component : Product, IComponent
    {
        
        public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; private set; }

        public override string ToString()
        {
            //return base.ToString();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString() + $"Generation: {this.Generation}");

            return sb.ToString().Trim();

        }
    }
}
