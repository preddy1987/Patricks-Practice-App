using PracticeApp.Models;
using System;
using System.Collections.Generic;

namespace PracticeApp
{
    public class ToDoApp
    {
        #region Properties and Member Variables
        public ToDoTask CurrentTask { get; set; }
        public TaskList CurrentTaskList { get; set; }
        public Dictionary<int,TaskList> CurrentDictOfTaskLists { get; set; }
        public Dictionary<int,List<ToDoTask>> CurrentDictOfTasks { get; set; }
        #endregion

        #region Constructors
        public ToDoApp()
        {
            CurrentDictOfTaskLists = new Dictionary<int, TaskList>();
            CurrentDictOfTasks = new Dictionary<int, List<ToDoTask>>();
        }

        public void CreateDummyData()
        {
            #region TaskLists
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
            #endregion

            #region Tasks
            ToDoTask taskOne = new ToDoTask()
            {
                Name = "Add CRUD Methods",
                Description = "Continue adding CRUD methods to your practice ToDo App",
                ListId = 1
            };
            AddNewTask(taskOne);
            ToDoTask taskTwo = new ToDoTask()
            {
                Name = "Add Unit Tests",
                Description = "you should of been adding unit tests from the start",
                ListId = 1
            };
            AddNewTask(taskTwo);
            ToDoTask taskThree = new ToDoTask()
            {
                Name = "Seriously Add Unit Tests",
                Description = "Before creating a the CRUD method, you should write the Unit Test...Seriously",
                ListId = 1
            };
            AddNewTask(taskThree);



            #endregion
        }
        #endregion

        #region TaskList Methods
        public void SetCurrentTaskList(int taskListId)
        {
            foreach (KeyValuePair<int, TaskList> taskList in CurrentDictOfTaskLists)
            {
                if (taskList.Key == taskListId)
                {
                    CurrentTaskList = taskList.Value;
                }
            }
        }
        public void AddNewList(TaskList newList)
        {
            int key = CurrentDictOfTaskLists.Count + 1;
            newList.Id = key;
            CurrentDictOfTaskLists.Add(key, newList);
        }
        public void ChangeList(TaskList updatedList)
        {
           foreach(KeyValuePair<int,TaskList> taskList in CurrentDictOfTaskLists)
            {
                if(taskList.Key == CurrentTaskList.Id)
                {
                    taskList.Value.Description = updatedList.Description;
                    taskList.Value.Name = updatedList.Name;
                }
            }
        }
        public void RemoveList(int? taskListId)
        {
            if(CurrentDictOfTaskLists.ContainsKey((int)taskListId))
            {
                CurrentDictOfTaskLists.Remove((int)taskListId);
            }
        }
        #endregion

        #region Task Methods
        public void AddNewTask(ToDoTask newTask)
        {
            if(CurrentDictOfTasks.ContainsKey(newTask.ListId))
            {
                CurrentDictOfTasks[newTask.ListId].Add(newTask);
            }
            else
            {
                CurrentDictOfTasks.Add(newTask.ListId, new List<ToDoTask>() { newTask });
            }
        }
        public void ChangeTask(ToDoTask updatedTask)
        {
            if(CurrentDictOfTasks.ContainsKey((int)updatedTask.ListId))
            {
                foreach(ToDoTask task in CurrentDictOfTasks[updatedTask.ListId])
                {
                    if(task.Id == updatedTask.Id)
                    {
                        task.Name = updatedTask.Name;
                        task.Description = updatedTask.Description;
                    }
                }
            }
        }

        public void RemoveTask(int? taskId)
        {
           
        }
        #endregion

    }
}
