using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;

namespace DiscoveryZoneApi.Serveries.CategoriesServices
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategoriesByFieldId(int fieldId);


 Task<dynamic> GetAllCategories();

        Task<Category> AddCategory(Category category);

         Task<Category> GitCategoryById(int CategoryId);


        Task<Category> DeleteCategory(int CategoryId);

        void UpdateCategory(Category category);


         bool SaveChanges();
    }
}