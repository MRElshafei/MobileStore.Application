using Application.Helper;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MobileStore.Application.DTO;
using MobileStore.Application.Enums;
using MobileStore.Application.Feature.Orders.Command;
using MobileStore.Application.Feature.Orders.Query;
using MobileStore.Application.Interfaces;
using System.Net;

namespace MobileStore.Persistence.Repositories
{
    public class OrderRepository : AsyncRepository<Order>, IOrderRepository
    {
        private readonly StoreDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;



        public OrderRepository(StoreDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

        }

        public string CancelOrder(int id)
        {
            var deleteOrder = _context.Orders.FirstOrDefault(i => i.ID == id);
            if (deleteOrder == null)
            {
                throw new WebException("This order is not exist ");

            }
            if (deleteOrder.OnCart==true) 
            {
                var ItemQuantity = _context.Items.FirstOrDefault(o => o.ID == deleteOrder.ItemId);
                var newQuantity = (ItemQuantity.Quantity) + (deleteOrder.Quantity);
                ItemQuantity.Quantity = newQuantity;
                _context.Items.Update(ItemQuantity);
            }
            else
            {
                throw new WebException("This order is paid or not exist");

            }
            _context.Orders.Remove(deleteOrder);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Deleting an order");
            }
            return "Order is Deleted Successfully";
        }

        public string CreateOrder(NewOrderDTO newOrderDTO)
        {
            if (newOrderDTO == null)
            {
                throw new WebException("Please select order");

            }
            var ItemQuantity = _context.Items.FirstOrDefault(o => o.ID == newOrderDTO.ItemId);

            
            Order order = new Order();
            order.OnCart = true;
            order.UserId = DecodingToken.DecodingID(_contextAccessor);
            order.ItemId = newOrderDTO.ItemId;
            if (newOrderDTO.Quantity <= ItemQuantity.Quantity)
            {
                var newQuantity = (ItemQuantity.Quantity) - (newOrderDTO.Quantity);
                ItemQuantity.Quantity = newQuantity;
                _context.Items.Update(ItemQuantity);

            }
            else
            {
                throw new WebException("The requested quantity exceeds the available stock!");

            }
            order.Quantity = newOrderDTO.Quantity;
            order.IsPaid = false;
            order.Code = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            order.TimeStamp = DateTime.Now;

            _context.Orders.Add(order);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Creating Order");
            }
            return "Order is Created Successfully";
             

        }

        public List<Order> GetOrdesrBasedOnStatues(int statues)
        {
            var user = DecodingToken.DecodingID(_contextAccessor);
            List<Order> orders = new List<Order>();
            if (statues== (int)OrderEnum.Oncart)
            {
                orders = _context.Orders.Where(o=>o.UserId == user && o.OnCart==true).ToList();

            }
            if (statues == (int)OrderEnum.IsPaid)
            {
                orders = _context.Orders.Where(o => o.UserId == user && o.IsPaid == true).ToList();

            }

            if (orders.Count == 0)
            {
                throw new WebException("There is no Order");

            }
            return orders;  
        }

        public string PayOrder(int id)
        {
            var OrderToPay = _context.Orders.FirstOrDefault(i => i.ID == id);
            if (OrderToPay == null)
            {
                throw new WebException("This order is not exist ");

            }
            if (OrderToPay.OnCart == true)
            {
                var ItemQuantity = _context.Items.FirstOrDefault(o => o.ID == OrderToPay.ItemId);
                var newQuantity = (ItemQuantity.Quantity) - (OrderToPay.Quantity);
                ItemQuantity.Quantity = newQuantity;
                OrderToPay.IsPaid = true;
                OrderToPay.OnCart = false;

                _context.Items.Update(ItemQuantity);
            }else {
                throw new WebException("This order is paid or not exist");

            }
            _context.Orders.Update(OrderToPay);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error during Pay process of order");
            }
            return "Order is paid Successfully";
        }
    }
}
