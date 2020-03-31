using PracticeApp.DAL.Interfaces;
using PracticeApp.Models;
using System;

namespace PracticeApp
{
    public class PracticeApp
    {
        IAppDatabase _database;

        public string CurrentUser { get; set; }
        public Task CurrentTask { get; set; }
        public List CurrentList { get; set; }
        PracticeApp(IAppDatabase database)
        {
            _database = database;
        }


    }
}
