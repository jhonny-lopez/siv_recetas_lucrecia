using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infrastructure.Stock
{
    public class AdidasStockService : IStockService
    {
        public void RequestEventShirt()
        {
            WebClient webClient = new WebClient();
            webClient.BaseAddress = "https://shirts.com/request";
            
        }
    }
}
