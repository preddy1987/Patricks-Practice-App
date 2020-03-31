using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.Models
{
    class User : BaseDBModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
