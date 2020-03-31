using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.Models
{
    class Task : BaseDBModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }
    }
}
