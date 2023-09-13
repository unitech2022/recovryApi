using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DiscoveryZoneApi.Data;
using DiscoveryZoneApi.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using DiscoveryZoneApi.Models.BaseEntity;

using X.PagedList;

namespace DiscoveryZoneApi.Serveries.CategoriesServices
{
    public class CategoriesService : ICategoriesService

    {


        private readonly IMapper _mapper;

        private readonly IConfiguration _config;
        private readonly AppDBcontext _context;

        public CategoriesService(IMapper mapper, IConfiguration config, AppDBcontext context)
        {
            _mapper = mapper;
            _config = config;
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {

            await _context.Categories!.AddAsync(category);

            await _context.SaveChangesAsync();

            return category;

        }

      
        public async Task<List<Category>> GetCategoriesByFieldId( int fieldId)
        {
            List<Category> categories = await _context.Categories!.OrderBy(t=>t.Order).Where(t=>t.FieldId==fieldId).ToListAsync();
           


           
            return categories;

        }

        public async Task<Category> GitCategoryById(int CategoryId)
        {

            Category? category = await _context.Categories!.FirstOrDefaultAsync(x => x.Id == CategoryId);
            return category!;
        }

        public void UpdateCategory(Category category)
        {


            // nothing

        }

  public async Task<Category> DeleteCategory(int CategoryId)
        {
            Category? category = await _context.Categories!.FirstOrDefaultAsync(x => x.Id == CategoryId);

            if (category != null)
            {
                _context.Categories!.Remove(category);

                await _context.SaveChangesAsync();
            }

            return category!;
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<dynamic> GetAllCategories()
        {
             List<Category> categories = await _context.Categories!.ToListAsync();
             return categories;
        }
    }
}