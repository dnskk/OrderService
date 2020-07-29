using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderService.Application.Repositories;
using OrderService.Models;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository orderRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{orderId}")]
        public ActionResult<Order> Get(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public ActionResult<Order> Add(Order newOrder)
        {
            try
            {
                var order = _orderRepository.Add(newOrder);
                return order;
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (e.ParamName == nameof(newOrder.PostamatId))
                {
                    return NotFound();
                }
                return BadRequest(e.Message);
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException)
            {
                return new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }
        }

        [HttpPost]
        public ActionResult<Order> Update(Order updatedOrder)
        {
            try
            {
                var order = _orderRepository.Update(updatedOrder);
                return order;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException)
            {
                return new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }
        }

        [HttpPost]
        [Route("{orderId}")]
        public ActionResult<Order> Cancel(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            if (order == null)
            {
                return NotFound();
            }

            order.Status = OrderStatus.Cancelled;
            order = _orderRepository.Update(order);
            return order;
        }
    }
}
