using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Product : IProduct
    {

        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id 
        {
            get 
            {
                return this.id;
            }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                this.id = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                this.model = value;
            }
        }
        virtual public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }
        virtual public double OverallPerformance
        {
            get
            {
                return this.overallPerformance;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.overallPerformance = value;
            }
        }
        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
