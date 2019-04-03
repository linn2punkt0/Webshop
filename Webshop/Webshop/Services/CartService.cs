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

        public List<CartProduct> Get(int cart_id)
        {
            return cartRepository.Get(cart_id);
        }

        public int Add(Carts carts)
        {

            if (carts.Product_id == 0)
            {
                return 0;
            }
            if (carts.Cart_id == 0)
            {
                carts.Cart_id = this.GetRandomCartId();
                cartRepository.Add(carts);
                return (carts.Cart_id);
            }
            else
            {
                this.cartRepository.Add(carts);
                return (carts.Cart_id);
            }
          
        }

        public int GetRandomCartId()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            return randomNumber;
        }
        
        public bool Delete(int cart_id)
        {
            var cartExists = cartRepository.Get(cart_id);
            if (cartExists != null)
            {
                cartRepository.Delete(cart_id);
                return true;
            }

            return false;
        }
    }
}