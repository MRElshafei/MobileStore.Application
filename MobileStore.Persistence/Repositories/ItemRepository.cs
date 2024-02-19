using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using MobileStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application.Enums;
using Application.Helper;
using Azure.Core;
using MediatR;
using MobileStore.Application.Feature.Items.Command;
using MobileStore.Application.DTO;

namespace MobileStore.Persistence.Repositories
{
    public class ItemRepository : AsyncRepository<Item>, IItemRepository
    {
        private readonly StoreDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;



        public ItemRepository(StoreDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

        }

        public string CreateItem(NewItemDTO item)
        {

            Item newItem = new Item();
        

            newItem.Name = item.Name;
            newItem.Description = item.Description;
            newItem.CategoryId = item.CategoryId;
            newItem.Quantity = item.Quantity;
            newItem.Price = item.Price;

            _context.Items.Add(newItem);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Adding an Item");
            }
            return "Item is Created Successfully";
        }

        public string DeleteItem(long id)
        {
            var deleteItem = _context.Items.FirstOrDefault(i => i.ID == id);
            if (deleteItem == null)
            {
                throw new WebException("This item is not exist ");

            }
            _context.Items.Remove(deleteItem);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Deleting an Item");
            }
            return "Item is Deleted Successfully";
        }

        public List<Item> GetAllItems()
        {
            //Depend on role get items
            if (DecodingToken.DecodingRoles(_contextAccessor) ==RoleEnum.Admin.ToString())
            {

                var AllItems = _context.Items.ToList();
                //Check if ther is no items 
                if (AllItems.Count == 0)

                {
                    throw new WebException("There is no item exist");

                }
                return AllItems;

            }


            var Items = _context.Items.Where(o => o.Quantity > 0).ToList();
                //Check if ther is no items 

                if (Items.Count==0)
                {
                    throw new WebException("There is no item exist");
                }

                return Items;
            
        }

        public Item GetItem(long id)
        {
            var item = _context.Items.FirstOrDefault(i => i.ID == id);
            if (item is null)
            {
                throw new WebException("There is no item exist");

            }
            return item;
        }

        public List<Item> GetItemsByCategoryId(long id)
        {
            //Depend on role get items
            if (DecodingToken.DecodingRoles(_contextAccessor) == RoleEnum.Admin.ToString())
            {

                var AllItems = _context.Items.Where(i => i.CategoryId == id).ToList();
                if (AllItems.Count == 0)
                {
                    throw new WebException("No items found in the specified category. Please ensure that the category ID is correct or there are items available in this category.");
                }
                return AllItems;

            }
            var Items = _context.Items.Where(i => i.CategoryId == id).ToList();
            Items= Items.Where(o=>o.Quantity>0).ToList();
            if (Items.Count == 0)
            {
                throw new WebException("No items found in the specified category. Please ensure that the category ID is correct or there are items available in this category.");
            }

         
            return Items;
        }

        public List<Item> SearchByItemName(string name)
        {
            if (name is null)
            {
                throw new WebException("No items found matching the provided name.");

            }
            List<Item> items = new List<Item>();

            if (DecodingToken.DecodingRoles(_contextAccessor) == RoleEnum.Admin.ToString())
            {
                items = _context.Items.ToList();

            }
            else
            {
                items = _context.Items.Where(i => i.Quantity > 0).ToList();

            }

            items = items.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (items.Count==0)
            {
                throw new WebException("No items found matching the provided name.");

            }
            return items;
            
        }

        public string UpdateItem(UpdateItemDTO updateItemDTO)
        {
            if (updateItemDTO.ItemId ==null)
            {
                throw new WebException("Please Enter Item Id");

            }

            var updateItem = _context.Items.FirstOrDefault(i => i.ID == updateItemDTO.ItemId);
            if (updateItem is null)
            {
                throw new WebException("Can not find this Item");

            }

            if (updateItemDTO.CategoryId is not null)
            {
                updateItem.CategoryId = updateItemDTO.CategoryId.Value;
            }
            if (updateItemDTO.Quantity is not null)
            {
                updateItem.Quantity = updateItemDTO.Quantity.Value;

            }
            if (!String.IsNullOrEmpty(updateItemDTO.Name))
            {
                updateItem.Name = updateItemDTO.Name;
            }
            if (!String.IsNullOrEmpty(updateItemDTO.Description))
            {
                updateItem.Description = updateItemDTO.Description;

            }
            if (updateItemDTO.Price is not null)
            {
                updateItem.Price = updateItemDTO.Price;

            }


            _context.Items.Update(updateItem);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Updateing an Item");
            }
             return "Item is Updated Successfully";
        }

     
    }
}
