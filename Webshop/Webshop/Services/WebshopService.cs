using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Service
{
    public class WebshopService
    {
            private readonly WebshopRepository webshopRepository;

            public  WebshopService(WebshopRepository webshopRepository)
            {
                this.webshopRepository = webshopRepository;
            }

            public List<Items> Get()
            {
                return webshopRepository.Get();
            }

            public Items Get(int id)
            {
                return webshopRepository.Get(id);
            }

            public bool Add(Items items)
            {
                if (items != null)
                {
                    if (items.Header != null || items.Header != String.Empty)
                    {
                        if (items.Body != null || items.Body != String.Empty)
                        {
                            webshopRepository.Add(items);
                            return true;
                        }
                    }
                }

                return false;
            }
        
            public bool Delete(int id)
            {
                var postExists = webshopRepository.Get(id);
                if (postExists != null)
                {
                    webshopRepository.Delete(id);
                    return true;
                }

                return false;
            }
        }
}