using Microsoft.EntityFrameworkCore;
using PracticeApp.DAL.Interfaces;
using PracticeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApp.DAL
{
    class EFCoreDatabase : IAppDatabase
    {
        #region Properties and Member Variables
        DbContextOptions<PracticeAppContext> _options;
        UserEFCore _user;
        ListEFCore _list;
        TaskEFCore _task;
        #endregion
        #region Constructors
        public EFCoreDatabase(DbContextOptions<PracticeAppContext> options)
        {
            _options = options;
            _user = new UserEFCore(_options);
            //ListEFCore _list = new ListEFCore(_options);
            //TaskEFCore _task = new TaskEFCore(_options);
        }
        #endregion
        #region User Database Methods
        public void CreateUser(User newUser)
        {
            _user.CreateUser(newUser);
        }
        public User GetUser(string userName)
        {
            return _user.GetUser(userName);
        }

        #endregion

        #region List Database Methods
        public void CreateList(List newList, int? id)
        {
            throw new NotImplementedException();
        }
        public List GetList(int? id1, int? id2)
        {
            throw new NotImplementedException();
        }
        public void UpdateList(List updatedList, int? id)
        {
            throw new NotImplementedException();
        }
        public void DeleteList(List deleteList, int? id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task Database Methods
        public void CreateTask(Task newTask,int? listId)
        {
            throw new NotImplementedException();
        }
        public Task GetTask(int? taskId)
        {
            throw new NotImplementedException();
        }
        public void UpdateTask(Task updatedTask, int? listId)
        {
            throw new NotImplementedException();
        }
        public void DeleteTask(int? taskId)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
