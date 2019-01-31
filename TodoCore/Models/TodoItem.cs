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