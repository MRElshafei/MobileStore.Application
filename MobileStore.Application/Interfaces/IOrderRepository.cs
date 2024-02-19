using Domain;
using MobileStore.Application.DTO;
using MobileStore.Application.Feature.Orders.Command;
using MobileStore.Application.Feature.Orders.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        string CreateOrder(NewOrderDTO newOrderDTO);
        string CancelOrder(int id);
        List<Order> GetOrdesrBasedOnStatues(int statues);
        string PayOrder(int id);


    }
}
