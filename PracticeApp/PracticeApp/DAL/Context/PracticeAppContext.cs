using System;
using System.Collections.Generic;
using System.Text;
using PracticeApp.Models;
using Microsoft.EntityFrameworkCore;


namespace PracticeApp.DAL
{
    class PracticeAppContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<List> List { get; set; }
    }
}
