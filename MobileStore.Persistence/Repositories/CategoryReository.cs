using Application.Features.Categories.Command;
using Azure.Core;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MobileStore.Application.DTO;
using MobileStore.Application.Feature.Categories.Command;
using MobileStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Persistence.Repositories
{
    public class CategoryReository : AsyncRepository<Category>, ICategoryReository
    {
        private readonly StoreDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;



        public CategoryReository(StoreDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

        }
        public List<Category> GetAllCategories()
        {
            var Categories = _context.Categories.ToList();
            //Check if ther is no Categories 
            if (Categories.Count==0 )
            {
                throw new WebException("There is no Categories exist");

            }
            return Categories;
        }

        public Category GetCategory(long categoryId)
        {
            var category = _context.Categories.FirstOrDefault(i => i.ID == categoryId);
            if (category is null)
            {
                throw new WebException("There is no Category exist");

            }
            return category;
        }

        public string CreateCategory(NewCategoryDTO categoryDTO)
        {
            Category newCategory = new Category();
            if (categoryDTO is null) 
            {
                throw new WebException("Please Add your new Category");

            }

            if (categoryDTO.Name is null)
            {
                throw new WebException("Please Add Name new Category");

            }
            newCategory.Name = categoryDTO.Name;
            newCategory.Description = categoryDTO.Description;

            _context.Categories.Add(newCategory);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Adding an Category");
            }
            return "Category is Created Successfully";
        }

        public string UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            var updateCategory = _context.Categories.FirstOrDefaultAsync(i => i.ID == categoryDTO.CategoryId).Result;
            if (updateCategory is null)
            {
                throw new WebException("Can not find this Category");

            }
            if (!String.IsNullOrEmpty(categoryDTO.Description))
            {
                updateCategory.Description = categoryDTO.Description;

            }
            if (!String.IsNullOrEmpty(categoryDTO.Name))
            {
                updateCategory.Name = categoryDTO.Name;
            }



            _context.Categories.Update(updateCategory);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Updateing an Category");
            }
            return  "Category is Updated Successfully";
        }

        public string DeleteCategory(long id)
        {
            var deleteCategory = _context.Categories.FirstOrDefault(i => i.ID == id);
            if (deleteCategory == null)
            {
                throw new WebException("This item is not exist ");

            }
            _context.Categories.Remove(deleteCategory);
            if (_context.SaveChanges() == 0)
            {
                throw new WebException("Error while Deleting an Category");
            }
            return  "Category is Deleted Successfully";

        }
    }
}
