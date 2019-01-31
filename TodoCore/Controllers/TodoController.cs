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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var successful = await todoItemService.AddItemAsync(newItem);
            if (!successful)
                return BadRequest("Count not add item");
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if(id==Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successfu = await todoItemService.MarkDoneAsync(id);
            if (!successfu)
                return BadRequest("Could not mark item as done.");
            return RedirectToAction("Index");
        }
    }
}