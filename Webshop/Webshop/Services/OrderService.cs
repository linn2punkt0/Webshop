using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;
        private readonly CartRepository cartRepository;

        public  OrderService(OrderRepository orderRepository, CartRepository cartRepository)
                 {
                     this.orderRepository = orderRepository;
                     this.cartRepository = cartRepository;
                 }

        public List<Orders> Get()
        {
            return orderRepository.Get();
        }

        public Orders Get(int id)
        {
            return orderRepository.Get(id);
        }

        public bool Add(Customer customer, int cartId)
        {
            if (customer != null)
            {
                if (cartId != 0)
                {

                    var products = cartRepository.Get(cartId);
                 
                    
                        orderRepository.Add(products, customer);
                        return true;
                }
            }

            return false;
        }
    }
}