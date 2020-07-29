using System.Collections.Generic;
using OrderService.Models;

namespace OrderService.Database
{
    /// <summary>
    /// Order database.
    /// </summary>
    public class OrderDatabase
    {
        private static OrderDatabase _instance;

        public List<Order> Orders { get; }

        public static OrderDatabase Instance
        {
            get
            {
                return _instance ??= new OrderDatabase();
            }
        }

        private OrderDatabase()
        {
            Orders = new List<Order>();
        }
    }
}
