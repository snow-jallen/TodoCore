using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Services;
using TodoCore.Models;

namespace TodoCore.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<bool> AddItemAsync(TodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new TodoItem
            {
                Title = "Learn ASP.Net Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };

            var item2 = new TodoItem
            {
                Title = "Build awesome apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            return Task.FromResult(new[] { item1, item2 });
        }

        public Task<bool> MarkDoneAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
