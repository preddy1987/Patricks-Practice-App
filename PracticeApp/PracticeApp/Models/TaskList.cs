using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.Models
{
    public class TaskList : BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ToDoTask> ToDoTasks { get; set; }
    }
}
