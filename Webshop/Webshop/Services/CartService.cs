using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;
namespace Webshop.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public  CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Carts> Get()
        {
            return cartRepository.Get();
        }

        public Carts Get(int id)
        {
            return cartRepository.Get(id);
        }

        public bool Add(Carts carts)
        {
            if (carts != null)
            {
                if (carts.Product_id != null)
                {
                    if (carts.Quantity != null)
                    {
                        cartRepository.Add(carts);
                        return true;
                    }
                }
            }

            return false;
        }
        
        public bool Delete(int id)
        {
            var postExists = cartRepository.Get(id);
            if (postExists != null)
            {
                cartRepository.Delete(id);
                return true;
            }

            return false;
        }
    }
}