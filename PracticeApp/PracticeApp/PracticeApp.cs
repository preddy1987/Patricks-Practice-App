using PracticeApp.DAL.Interfaces;
using PracticeApp.Models;
using System;

namespace PracticeApp
{
    public class PracticeApp
    {
        #region Properties and Member Variables
        IAppDatabase _database;
        public User CurrentUser { get; set; }
        public Task CurrentTask { get; set; }
        public List CurrentList { get; set; }
        #endregion

        #region Constructors
        PracticeApp(IAppDatabase database)
        {
            _database = database;
        }
        #endregion

        #region User Methods
        public void RegisterUser(User newUser)
        {
            User user = null;
            try
            {
                user = _database.GetUser(newUser.UserName);
            }
            catch (Exception)
            {
            }

            if (user != null)
            {
                throw new Exception("User Name is already taken. Please select a different user name");
            }
            else
            {
                _database.CreateUser(newUser);
                LoginUser(newUser);
            }
        }

        public void LoginUser(User newUser)
        {
            User user = null;
            try
            {
                user = _database.GetUser(newUser.UserName);
            }
            catch (Exception)
            {
                throw new Exception("Your login credentials did not match any of our records. Please try again.");
            }

            if (user != null)
            {
                CurrentUser = user;
            }
        }

        public void LogoutUser()
        {
            CurrentUser = null;
        }
        #endregion

        #region List Methods
        public void AddNewList(List newList)
        {
            if(CurrentUser != null)
            {
                _database.CreateList(newList,CurrentUser.Id);
            }
            else
            {
                throw new Exception("You're not currently logged in. Please login again.");
            }
        }

        public void ChangeList(List updatedList)
        {
            if(CurrentUser != null)
            {
                _database.UpdateList(updatedList, CurrentUser.Id);
            }
            else
            {
                throw new Exception("You're not currently logged in. Please login again.");
            }
        }

        public void RemoveList(List deleteList)
        {
            List list = new List();
            try
            {
                list = _database.GetList(deleteList.Id,CurrentUser.Id);
            }
            catch
            {
            }

            if (CurrentUser != null)
            {
                _database.DeleteList(deleteList, CurrentUser.Id);
            }
            else
            {
                throw new Exception("You're not currently logged in. Please login again.");
            }
        }
        #endregion

        #region Task Methods
        public void AddNewTask(Task newTask, int? listId)
        {
            if (CurrentUser != null)
            {
                _database.UpdateTask(newTask, listId);
            }
            else
            {
                throw new Exception("You're not currently logged in. Please login again.");
            }
        }

        public void ChangeTask(Task updatedTask, int? listId)
        {
            if (CurrentUser != null)
            {
                _database.UpdateTask(updatedTask, listId);
            }
            else
            {
                throw new Exception("You're not currently logged in. Please login again.");
            }
        }

        public void RemoveTask(int? taskId)
        {
            Task task = new Task();
            try
            {
                task = _database.GetTask(taskId);
            }
            catch
            {
            }

            if (CurrentUser != null)
            {
                _database.DeleteTask(taskId);
            }
            else
            {
                throw new Exception("You're not currently logged in. Please login again.");
            }
        }
        #endregion

    }
}
