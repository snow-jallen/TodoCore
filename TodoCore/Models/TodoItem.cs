using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Models;

namespace TodoCore.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTimeOffset? DueAt { get; set; }
        public string Type { get; set; }
        public ICollection<TodoStep> Steps { get; set; }
    }

    public class TodoStep
    {
        public int Id { get; set; }
        public TodoItem Todo { get; set; }
        public string Title { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool IsDone { get; set; }

        public TodoStep()
        {

        }

        public TodoStep(TodoItem parent)
        {
            Todo = parent;
        }
    }
}


namespace MyBogusNS
{
    public static class Extensions
    {
        public static bool IsAwesome(this TodoItem item)
        {
            return true;
        }
    }
}