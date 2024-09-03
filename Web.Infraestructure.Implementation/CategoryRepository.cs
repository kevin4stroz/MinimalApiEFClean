using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;
using Web.Infraestructure.Interfaces;

namespace Web.Infraestructure.Implementation
{
    /// <summary>
    /// CategoryRepository
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// Constructor CategoryRepository
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// GetAllCategories - Repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<Categories>> GetAllCategories()
        {
            return await _applicationDbContext.Categories.Where(
                x => x.FlgActive).ToListAsync();
        }
    }
}
