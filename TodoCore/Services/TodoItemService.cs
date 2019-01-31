using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Data;
using TodoCore.Models;

namespace TodoCore.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();
            return (saveResult == 1);
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return _context.Items.Where(i => i.IsDone == false).ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items.Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null)
                return false;
            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return (saveResult == 1);
        }
    }
}
