using TimeManagemetApp.Models.Models;
using TimeManagemetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TimeManagemetApp.BusinessLogic.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
        public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.FindAsync(id);
        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) return false;
            _context.Categories.Remove(cat);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
