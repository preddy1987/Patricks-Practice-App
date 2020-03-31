using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.Models
{
    public class User : BaseDBModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
