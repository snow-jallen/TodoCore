using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoCore.Services;
using TodoCore.Models;

namespace TodoCore.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await todoItemService.GetIncompleteItemsAsync();
            var model = new TodoViewModel(items);
            return View(model);
        }
    }
}