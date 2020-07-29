using OrderService.Database;
using OrderService.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Repositories
{
    /// <inheritdoc cref="IOrderRepository"/>
    public class OrderRepository : IOrderRepository
    {
        private const string TelephoneNumberPattern = @"\+7\d{3}-\d{3}-\d\d-\d\d$";
        private const int MaxNumberOfProducts = 10;

        private readonly IPostamatRepository _postamatRepository;
        private readonly OrderDatabase _orderDatabase;

        public OrderRepository(IPostamatRepository postamatRepository, OrderDatabase orderDatabase)
        {
            _postamatRepository = postamatRepository;
            _orderDatabase = orderDatabase;
        }

        /// <inheritdoc />
        public Order Get(int orderId)
        {
            return _orderDatabase.Orders.FirstOrDefault(p => p.Id == orderId);
        }

        /// <inheritdoc />
        public Order Add(Order newOrder)
        {
            ValidateOrder(newOrder, shouldCheckPostamatStatus: true);

            var id = 1;
            if (_orderDatabase.Orders.Count != 0)
            {
                id = _orderDatabase.Orders.Max(p => p.Id) + 1;
            }
            newOrder.Id = id;
            newOrder.Status = OrderStatus.Registered;

            _orderDatabase.Orders.Add(newOrder);

            return newOrder;
        }

        /// <inheritdoc />
        public Order Update(Order updatedOrder)
        {
            ValidateOrder(updatedOrder);

            var index = _orderDatabase.Orders.FindIndex(p => p.Id == updatedOrder.Id);

            if (index == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(updatedOrder.Id));
            }

            updatedOrder.PostamatId = _orderDatabase.Orders[index].PostamatId;
            updatedOrder.Status = _orderDatabase.Orders[index].Status;
            _orderDatabase.Orders[index] = updatedOrder;

            return updatedOrder;
        }

        /// <inheritdoc />
        public Order Cancel(int orderId)
        {
            var index = _orderDatabase.Orders.FindIndex(p => p.Id == orderId);

            if (index == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId));
            }

            _orderDatabase.Orders[index].Status = OrderStatus.Cancelled;

            return _orderDatabase.Orders[index];
        }

        /// <inheritdoc />
        public Task<Order> GetAsync(int orderId, CancellationToken token)
        {
            return Task.FromResult(Get(orderId));
        }

        /// <inheritdoc />
        public Task<Order> AddAsync(Order newOrder, CancellationToken token)
        {
            return Task.FromResult(Add(newOrder));
        }

        /// <inheritdoc />
        public Task<Order> UpdateAsync(Order updatedOrder, CancellationToken token)
        {
            return Task.FromResult(Update(updatedOrder));
        }

        /// <inheritdoc />
        public Task<Order> CancelAsync(int orderId, CancellationToken token)
        {
            return Task.FromResult(Cancel(orderId));
        }

        private void ValidateOrder(Order order, bool shouldCheckPostamatStatus = false)
        {
            if (order.Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(order.Price));
            }

            if (order.Products.Length > MaxNumberOfProducts)
            {
                throw new ArgumentOutOfRangeException(nameof(order.Products));
            }

            var postamat = _postamatRepository.Get(order.PostamatId);
            if (postamat == null)
            {
                throw new ArgumentOutOfRangeException(nameof(order.PostamatId));
            }

            if (shouldCheckPostamatStatus && !postamat.IsWorking)
            {
                throw new ArgumentException("Postamat is not working currently");
            }

            if (!Regex.IsMatch(order.CustomerPhoneNumber, TelephoneNumberPattern))
            {
                throw new FormatException("Wrong telephone number format");
            }
        }
    }
}
