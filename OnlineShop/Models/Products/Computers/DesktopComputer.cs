using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        private const int OVER_PERF = 15;
        public DesktopComputer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, OVER_PERF)
        {
           
        }
    }
}
