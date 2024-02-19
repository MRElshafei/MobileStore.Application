using Application.Features.Categories.Command;
using Domain;
using MobileStore.Application.DTO;
using MobileStore.Application.Feature.Categories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.Interfaces
{
    public interface ICategoryReository: IAsyncRepository<Category>
    {
        List<Category> GetAllCategories();
        Category GetCategory(long id);
        string CreateCategory(NewCategoryDTO categoryDTO);
        string UpdateCategory(UpdateCategoryDTO categoryDTO);
        string DeleteCategory(long id);




    }
}
