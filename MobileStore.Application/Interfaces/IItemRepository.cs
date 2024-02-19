using Domain;
using MobileStore.Application.DTO;
using MobileStore.Application.Feature.Items.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.Interfaces
{
    public interface IItemRepository: IAsyncRepository<Item>
    {
        List<Item> GetAllItems();
        Item GetItem(long id);
        List<Item> GetItemsByCategoryId(long id);
        string CreateItem(NewItemDTO item);
        string DeleteItem(long id);
        string UpdateItem(UpdateItemDTO updateItem);
        List<Item> SearchByItemName(string name);



    }
}
