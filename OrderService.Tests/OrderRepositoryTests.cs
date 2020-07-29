using OrderService.Application.Repositories;
using System;
using OrderService.Database;
using OrderService.Models;
using Xunit;

namespace OrderService.Tests
{
    public class OrderRepositoryTests
    {
        [Fact]
        public void AddOrdersTest()
        {
            var repository = GetOrderRepository();

            for (var i = 1; i <= 3; i++)
            {
                var order = new Order
                {
                    Status = OrderStatus.Registered,
                    Products = new[] { "1", "2" },
                    Price = 100,
                    PostamatId = 1,
                    CustomerFullName = "Ivanov Ivan Ivanovich",
                    CustomerPhoneNumber = "+7123-456-78-90"
                };

                repository.Add(order);
                Assert.Equal(i, order.Id);
            }
        }

        [Fact]
        public void GetOrderTest()
        {
            var repository = GetOrderRepository();

            var order = new Order
            {
                Status = OrderStatus.Registered,
                Products = new[] { "1", "2" },
                Price = 100,
                PostamatId = 1,
                CustomerFullName = "Ivanov Ivan Ivanovich",
                CustomerPhoneNumber = "+7123-456-78-90"
            };

            repository.Add(order);
            order = repository.Get(1);
            Assert.NotNull(order);
        }

        [Fact]
        public void UpdateOrderTest()
        {
            var repository = GetOrderRepository();

            var order = new Order
            {
                Status = OrderStatus.Registered,
                Products = new[] { "1", "2" },
                Price = 100,
                PostamatId = 1,
                CustomerFullName = "Ivanov Ivan Ivanovich",
                CustomerPhoneNumber = "+7123-456-78-90"
            };

            repository.Add(order);
            order = repository.Get(1);
            order.Price = 1000000;
            repository.Update(order);
            order = repository.Get(1);

            Assert.Equal(1000000, order.Price);
        }

        [Fact]
        public void CancelOrderTest()
        {
            var repository = GetOrderRepository();

            var order = new Order
            {
                Status = OrderStatus.Registered,
                Products = new[] { "1", "2" },
                Price = 100,
                PostamatId = 1,
                CustomerFullName = "Ivanov Ivan Ivanovich",
                CustomerPhoneNumber = "+7123-456-78-90"
            };

            repository.Add(order);
            repository.Cancel(1);
            order = repository.Get(1);
            Assert.Equal(OrderStatus.Cancelled, order.Status);
        }

        [Fact]
        public void ToManyProductsTest()
        {
            var repository = GetOrderRepository();

            var order = new Order
            {
                Status = OrderStatus.Registered,
                Products = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" },
                Price = 100,
                PostamatId = 1,
                CustomerFullName = "Ivanov Ivan Ivanovich",
                CustomerPhoneNumber = "+7123-456-78-90"
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => repository.Add(order));
        }

        [Fact]
        public void WrongPostamatTest()
        {
            var repository = GetOrderRepository();

            var order = new Order
            {
                Status = OrderStatus.Registered,
                Products = new[] { "1", "2" },
                Price = 100,
                PostamatId = 100,
                CustomerFullName = "Ivanov Ivan Ivanovich",
                CustomerPhoneNumber = "+7123-456-78-90"
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => repository.Add(order));
        }

        [Fact]
        public void WrongTelephoneNumberTest()
        {
            var repository = GetOrderRepository();

            var order = new Order
            {
                Status = OrderStatus.Registered,
                Products = new[] { "1", "2" },
                Price = 100,
                PostamatId = 1,
                CustomerFullName = "Ivanov Ivan Ivanovich",
                CustomerPhoneNumber = "+7123-456-78-90asd"
            };

            Assert.Throws<FormatException>(() => repository.Add(order));
        }

        private OrderRepository GetOrderRepository()
        {
            var postamatRepository = new PostamatRepository(PostamatDatabase.Instance);

            return new OrderRepository(postamatRepository, OrderDatabase.Instance);
        }
    }
}
