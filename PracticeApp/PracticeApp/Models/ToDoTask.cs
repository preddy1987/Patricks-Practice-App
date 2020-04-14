﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.Models
{
    public class ToDoTask : BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ListId { get; set; }
    }
}
