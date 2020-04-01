using PracticeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.DAL.Interfaces
{
    interface IAppDatabase
    {
        void RegisterUser(User newUser);
        User GetUser(string userName);
        void CreateList(List newList, int? id);
        void UpdateList(List updatedList, int? id);
        void UpdateTask(Task newTask, int? listId);
        List GetList(int? id1, int? id2);
        void DeleteList(List deleteList, int? id);
    }
}
