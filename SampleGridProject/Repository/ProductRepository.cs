using SampleGridProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleGridProject.Repository
{
    public class ProductRepository: IProductRepository
    {
        public ProductRepository()
        {

        }
        public IList<MonitorModel> GetMonitors()
        {
            int i = 1;
            Random random = new Random();
            IList<MonitorModel> result = new List<MonitorModel>();
            for (int k = 0; k < 5; k++)
            {
                int price = random.Next(0, 1000);
                string quantity = random.Next(0, 100).ToString();
                if (quantity.Equals("0"))
                {
                    quantity = "Out Of Stock";
                }
                MonitorModel monitor = new MonitorModel
                {
                    MonitorId = $"MonitorId{i}",
                    Name = $"Asus Rog{i}",
                    Description = $"Best For Gaming{i}",
                    Price = price,
                    Quantity = quantity
                };
                i++;
                result.Add(monitor);
            }
            return result;
        }
    }
}