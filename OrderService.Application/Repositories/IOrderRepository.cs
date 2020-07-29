﻿using OrderService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Repositories
{
    /// <summary>
    /// Repository to work with orders.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Get order by ID. 
        /// </summary>
        Order Get(int orderId);

        /// <summary>
        /// Create new order.
        /// </summary>
        Order Create(Order newOrder);

        /// <summary>
        /// Update order.
        /// </summary>
        Order Update(Order updatedOrder);

        /// <summary>
        /// Cancell order.
        /// </summary>
        Order Cancell(int orderId);

        /// <summary>
        /// Get order by ID asynchronously. 
        /// </summary>
        Task<Order> GetAsync(int orderId, CancellationToken token);

        /// <summary>
        /// Create new order asynchronously.
        /// </summary>
        Task<Order> CreateAsync(Order newOrder, CancellationToken token);

        /// <summary>
        /// Update order asynchronously.
        /// </summary>
        Task<Order> UpdateAsync(Order updatedOrder, CancellationToken token);

        /// <summary>
        /// Cancell order asynchronously.
        /// </summary>
        Task<Order> CancellAsync(int orderId, CancellationToken token);

    }
}