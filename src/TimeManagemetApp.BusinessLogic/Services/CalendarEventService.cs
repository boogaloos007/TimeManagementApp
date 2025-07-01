using TimeManagemetApp.Models.Models;
using TimeManagemetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TimeManagemetApp.BusinessLogic.Services
{
    public class CalendarEventService
    {
        private readonly AppDbContext _context;
        public CalendarEventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CalendarEvent>> GetAllAsync() => await _context.CalendarEvents.Include(e => e.Category).ToListAsync();
        public async Task<CalendarEvent?> GetByIdAsync(int id) => await _context.CalendarEvents.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
        public async Task<CalendarEvent> CreateAsync(CalendarEvent ev)
        {
            _context.CalendarEvents.Add(ev);
            await _context.SaveChangesAsync();
            return ev;
        }
        public async Task<bool> UpdateAsync(CalendarEvent ev)
        {
            _context.CalendarEvents.Update(ev);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var ev = await _context.CalendarEvents.FindAsync(id);
            if (ev == null) return false;
            _context.CalendarEvents.Remove(ev);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
