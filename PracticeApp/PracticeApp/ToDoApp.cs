using PracticeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApp
{
    public class ToDoApp
    {
        #region Properties and Member Variables
        public ToDoTask SelectedToDoTask { get; set; }
        public TaskList SelectedTaskList { get; set; }
        public Category SelectedCategory { get; set; }
        public List<TaskList> CurrentTaskLists { get; set; }
        public List<ToDoTask> CurrentToDoTasks { get; set; }
        public List<Category> CurrentCategories { get; set; }

        #endregion

        #region Constructors
        public ToDoApp()
        {
            CurrentTaskLists = new List<TaskList>();
            CurrentToDoTasks = new List<ToDoTask>();
        }
        public ToDoApp(List<TaskList> taskLists, List<ToDoTask> toDoTasks, List<Category> categories)
        {
            CurrentTaskLists = taskLists;
            CurrentToDoTasks = toDoTasks;
            CurrentCategories = categories;
        }
        #endregion

        #region TaskList Methods
        public void SetSelectedTaskList(Guid? taskListId)
        {
            SelectedTaskList = CurrentTaskLists.Find(t => t.Id == taskListId);
        }
        //add validation method to make sure the name and description are not null or empty
        public void AddNewTaskList(TaskList newList)
        {
            CurrentTaskLists.Add(newList);
        }
        public void UpdateTaskList(TaskList updatedList)
        {
            //revisit
            //maybe?remove task and then re-add
            CurrentTaskLists.Where(t => t.Id == updatedList.Id).Select(t => { t.Name = updatedList.Name; t.Description = updatedList.Description; return t; }).ToList();
        }
        /// <summary>
        /// Removes the TaskList and its associated ToDoTasks
        /// </summary>
        /// <param name="taskListId"></param>
        public void RemoveTaskList(Guid? taskListId)
        {
            CurrentTaskLists.Remove(CurrentTaskLists.Find(t => t.Id == taskListId));
        }
        #endregion

        #region Task Methods
        /// <summary>
        /// Set the Currently Selected ToDo Task
        /// </summary>
        /// <param name="taskId"></param>
        public void SetSelectedToDoTask(Guid? taskId)
        {
            SelectedToDoTask = CurrentToDoTasks.Find(t => t.Id == taskId);
        }
        public void AddNewTask(ToDoTask newTask)
        {
            CurrentToDoTasks.Add(newTask);
        }
        /// <summary>
        /// Returns a new List<ToDoTask> by ListId
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        public List<ToDoTask> GetToDoTasksByListId(Guid? listid)
        {
            List<ToDoTask> toDoTasks = CurrentToDoTasks.Where(t => t.ListId == listid).ToList();
            return toDoTasks;
        }
        public void UpdateToDoTask(ToDoTask updatedTask)
        {
            //removing the original task and adding the new updated task
            CurrentToDoTasks.Remove(CurrentToDoTasks.Find(t => t.Id == updatedTask.Id));
            CurrentToDoTasks.Add(updatedTask);
            //updating existin properties on the task
            //CurrentToDoTasks.Where(t => t.Id == updatedTask.Id).Select(t => { t.Name = updatedTask.Name; t.Description = updatedTask.Description; return t; }).ToList();
        }
        /// <summary>
        /// Removes Task from the Current Dictionary of Tasks
        /// </summary>
        /// <param name="taskId"></param>
        public void RemoveTask(Guid? taskId)
        {
            CurrentToDoTasks.Remove(CurrentToDoTasks.Find(t=> t.Id == taskId));
        }

        public void RemoveAllTasksByListId(Guid? listId)
        {

            CurrentToDoTasks.RemoveAll(t => t.ListId == listId);
        }
        #endregion

        #region Category Methods
        //public List<Category> GetAllCategories()
        //{
        //    List<Category> categories = CurrentTaskLists.Select(t => t.Category).ToList();
        //    //categories = (List<Category>)categories.GroupBy(c => c.Name);
        //    return categories;
        //}

        public List<TaskList> GetTaskListsByCategoryId(Guid? id)
        {
            List<TaskList> taskLists = CurrentTaskLists.FindAll(t => t.CategoryId == id);
            return taskLists;
        }

        public void SetSelectedCategory(string categoryName)
        {
            //Category category = CurrentTaskLists.Find(t => t.Category.Name.ToLower() == categoryName.ToLower()).Category;
            SelectedCategory = CurrentCategories.Find(c => c.Name == categoryName);
        }

        //public List<TaskList> GetTaskListsByCategoryName(string categoryName)
        //{
        //    List<TaskList> taskLists = CurrentTaskLists.FindAll(t => t.Category.Name.ToLower() == categoryName.ToLower());
        //    return taskLists;
        //}
        #endregion
    }
}
