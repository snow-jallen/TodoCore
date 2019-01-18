using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCore.Models
{
    public class TodoViewModel
    {
        public TodoViewModel(IEnumerable<TodoItem> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }
        public IEnumerable<TodoItem> Items { get; private set; }
    }
}
