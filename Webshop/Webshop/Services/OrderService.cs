using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;

        public  OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public List<Orders> Get()
        {
            return orderRepository.Get();
        }

        public Orders Get(int id)
        {
            return orderRepository.Get(id);
        }

        public bool Add(Orders orders)
        {
            if (orders != null)
            {
                if (orders.Customer_name != null && orders.Customer_name != String.Empty)
                {
                    if (orders.Street_adress != null && orders.Street_adress != String.Empty)
                    {
                        orderRepository.Add(orders);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}