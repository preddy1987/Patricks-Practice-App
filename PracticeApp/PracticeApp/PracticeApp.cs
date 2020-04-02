using PracticeApp.Models;
using System;
using System.Collections.Generic;

namespace PracticeApp
{
    public class ToDoApp
    {
        #region Properties and Member Variables
        public Task CurrentTask { get; set; }
        public TaskList CurrentTaskList { get; set; }
        public Dictionary<int,TaskList> CurrentListOfTaskLists { get; set; }
        #endregion

        #region Constructors
        public ToDoApp()
        {
            CurrentListOfTaskLists = new Dictionary<int, TaskList>();
            TaskList testTaskListOne = new TaskList()
            {
                Name = "Code!",
                Description = "Eat Sleep Code"
            };
            TaskList testTaskListTwo = new TaskList()
            {
                Name = "Social Distancing",
                Description = "Maintain a healthy isolation from others"
            };
            TaskList testTaskListThree = new TaskList()
            {
                Name = "Grocery List",
                Description = "Things to get from the store"
            };
            AddNewList(testTaskListOne);
            AddNewList(testTaskListTwo);
            AddNewList(testTaskListThree);

        }
        #endregion

        #region TaskList Methods
        public void SetCurrentTaskList(int taskListId)
        {
            foreach (KeyValuePair<int, TaskList> taskList in CurrentListOfTaskLists)
            {
                if (taskList.Key == taskListId)
                {
                    CurrentTaskList = taskList.Value;
                }
            }
        }
        public void AddNewList(TaskList newList)
        {
            int key = CurrentListOfTaskLists.Count + 1;
            newList.Id = key;
            CurrentListOfTaskLists.Add(key, newList);
        }
        public void ChangeList(TaskList updatedList)
        {
           foreach(KeyValuePair<int,TaskList> taskList in CurrentListOfTaskLists)
            {
                if(taskList.Key == CurrentTaskList.Id)
                {
                    taskList.Value.Description = updatedList.Description;
                    taskList.Value.Name = updatedList.Name;
                }
            }
        }
        public void RemoveList()
        {
            foreach (KeyValuePair<int, TaskList> taskList in CurrentListOfTaskLists)
            {
                if (taskList.Key == CurrentTaskList.Id)
                {
                    CurrentListOfTaskLists.Remove(taskList.Key);
                }
            }
        }
        #endregion

        #region Task Methods
        public void AddNewTask(Task newTask, int? listId)
        {
           
        }

        public void ChangeTask(Task updatedTask, int? listId)
        {
            
        }

        public void RemoveTask(int? taskId)
        {
           
        }
        #endregion

    }
}
