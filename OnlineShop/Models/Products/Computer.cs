using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Computer : Product, IComputer
    {

        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.OverallPerformance = overallPerformance;
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance
        {
            get 
            {
                return base.OverallPerformance;
            }
            set 
            {
                if (components.Count <= 0)
                {
                    base.OverallPerformance = value;
                }
                else
                {
                    base.OverallPerformance = value + this.components.Average(c => c.OverallPerformance);
                }
            }
        }
        public override decimal Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                base.Price = value + this.components.Sum(p => p.Price) + this.peripherals.Sum(p => p.Price);
            }
        }
        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                string msg = String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,this.GetType().Name, component.Id);
                throw new ArgumentException(msg);
            }
            else
            {
                components.Add(component);
            }
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                string msg = String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, peripheral.Id);
                throw new ArgumentException(msg);
            }
            else
            {
                peripherals.Add(peripheral);
            }
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                string msg = String.Format(ExceptionMessages.NotExistingComponent, component.GetType().Name, component.GetType().Name, component.Id);
                throw new ArgumentException(msg);
            }
            
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                string msg = String.Format(ExceptionMessages.NotExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, peripheral.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Remove(peripheral);
            return peripheral;
        }
        public override string ToString()
        {
            //return base.ToString();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance)}):");

            foreach (var peripherial in peripherals)
            {
                sb.AppendLine($"  {peripherial.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
