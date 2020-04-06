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
            //task for list 1: Code!
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

            //tasks for list 2: Social Distancing
            ToDoTask taskFour = new ToDoTask()
            {
                Name = "Avoid People",
                Description = "Stay a minimum of 6ft away from others and avoid human contact as much as possible.",
                ListId = 2
            };
            AddNewTask(taskFour);
            ToDoTask taskFive = new ToDoTask()
            {
                Name = "Get a pet",
                Description = "Get a cat or a dog or something you can cuddle. Studies show this reduces stress!",
                ListId = 2
            };
            AddNewTask(taskFive);
            ToDoTask taskSix = new ToDoTask()
            {
                Name = "Pet your pet",
                Description = "Give your pet all the love and attention you can no longer get from people",
                ListId = 2
            };
            AddNewTask(taskSix);

            //tasks for lists 3: Grocery List
            ToDoTask taskSeven = new ToDoTask()
            {
                Name = "Skyline Chili",
                Description = "Cans of Skyline Chili, as many as you can get.",
                ListId = 3
            };
            AddNewTask(taskSeven);
            ToDoTask taskEight = new ToDoTask()
            {
                Name = "Shredded Cheese",
                Description = "All of the shredded cheese. Yes all of it.",
                ListId = 3
            };
            AddNewTask(taskEight);
            ToDoTask taskNine = new ToDoTask()
            {
                Name = "Pasta of your choice",
                Description = "I like spaghetti noodles, but equally as good over penne or fetticini or even rice!",
                ListId = 3
            };
            AddNewTask(taskNine);
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
                if(taskList.Key == updatedList.Id)
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
                newTask.Id = CurrentDictOfTasks[newTask.ListId].Count + 1;
                CurrentDictOfTasks[newTask.ListId].Add(newTask);
            }
            else
            {
                newTask.Id = 1;
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

        public void RemoveTask(int listId, int? taskId)
        {
            if (CurrentDictOfTasks.ContainsKey(listId))
            {
                foreach(ToDoTask task in CurrentDictOfTasks[listId])
                {
                    if(task.Id == taskId)
                    {
                        CurrentDictOfTasks[listId].Remove(task);
                        break;
                    }
                }
            }
        }
        #endregion

    }
}
