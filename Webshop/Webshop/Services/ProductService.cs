using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class ProductService
    {
            private readonly ProductRepository productRepository;

            public  ProductService(ProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }

            public List<Products> Get()
            {
                return productRepository.Get();
            }

            public Products Get(int id)
            {
                return productRepository.Get(id);
            }

//            public bool Add(Products products)
//            {
//                if (products != null)
//                {
//                    if (products.Name != null && products.Name != String.Empty)
//                    {
//                        if (products.Description != null && products.Description != String.Empty)
//                        {
//                            productRepository.Add(products);
//                            return true;
//                        }
//                    }
//                }
//
//                return false;
//            }
        
//            public bool Delete(int id)
//            {
//                var postExists = productRepository.Get(id);
//                if (postExists != null)
//                {
//                    productRepository.Delete(id);
//                    return true;
//                }
//
//                return false;
//            }
        }
}