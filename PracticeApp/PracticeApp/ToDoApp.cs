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
            CurrentTaskList = CurrentDictOfTaskLists[taskListId];
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
                    if(!String.IsNullOrEmpty(updatedList.Description))
                    {
                        taskList.Value.Description = updatedList.Description;
                    }
                    if (!String.IsNullOrEmpty(updatedList.Name))
                    {
                        taskList.Value.Name = updatedList.Name;
                    }                      
                }
            }
        }
        /// <summary>
        /// Removes the TaskList and its associated ToDoTasks
        /// </summary>
        /// <param name="taskListId"></param>
        public void RemoveListandTasks(int? taskListId)
        {
            if(CurrentDictOfTaskLists.ContainsKey((int)taskListId))
            {
                CurrentDictOfTaskLists.Remove((int)taskListId);
            }
            if(CurrentDictOfTasks.ContainsKey((int)taskListId))
            {
                CurrentDictOfTasks.Remove((int)taskListId);
            }
            ReOrderToDoTaskandTaskListDictionaries();
        }
        private void ReOrderToDoTaskandTaskListDictionaries()
        {
            int listCounter = 0;
            Dictionary<int, TaskList> updatedDictOfTaskLists = new Dictionary<int, TaskList>();
            Dictionary<int, List<ToDoTask>> updatedDictOfTasks = new Dictionary<int, List<ToDoTask>>();
            foreach (KeyValuePair<int,TaskList> taskList in CurrentDictOfTaskLists)
            {
                listCounter++;
                if(taskList.Key > listCounter)
                {
                    taskList.Value.Id = listCounter;
                }
                updatedDictOfTaskLists.Add((int)taskList.Value.Id, taskList.Value);
            }

            listCounter = 0;
            foreach (KeyValuePair<int, List<ToDoTask>> toDoTaskList in CurrentDictOfTasks)
            {
                listCounter++;
                if (toDoTaskList.Key > listCounter)
                {
                    foreach (ToDoTask task in CurrentDictOfTasks[toDoTaskList.Key])
                    {
                        task.ListId = listCounter;
                    }
                }
                updatedDictOfTasks.Add(listCounter, toDoTaskList.Value);
            }

            CurrentDictOfTaskLists.Clear();
            foreach(KeyValuePair<int, TaskList> taskList in updatedDictOfTaskLists)
            {
                CurrentDictOfTaskLists.Add(taskList.Key, taskList.Value);
            }
            CurrentDictOfTasks.Clear();
            foreach(KeyValuePair<int, List<ToDoTask>> toDoTaskList in updatedDictOfTasks)
            {
                CurrentDictOfTasks.Add(toDoTaskList.Key,toDoTaskList.Value);
            }
        }
        #endregion

        #region Task Methods
        /// <summary>
        /// Set the Currently Selected ToDo Task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskListId"></param>
        public void SetCurrentTask(int taskId, int taskListId)
        {
            if (CurrentDictOfTasks.ContainsKey(taskListId))
            {
                foreach (ToDoTask task in CurrentDictOfTasks[taskListId])
                {
                    if(task.Id == taskId)
                    {
                        CurrentTask = task;
                    }
                }
            }
        }
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
                        if(!String.IsNullOrEmpty(updatedTask.Name))
                        {
                            task.Name = updatedTask.Name;
                        }
                        if (!String.IsNullOrEmpty(updatedTask.Description))
                        {
                            task.Description = updatedTask.Description;
                        }                           
                    }
                }
            }
        }
        /// <summary>
        /// Removes Task from the Current Dictionary of Tasks
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="taskId"></param>
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
                ReOrderTasks(listId);
            }
        }

        private void ReOrderTasks(int listId)
        {
            int taskCounter = 0;
            foreach(ToDoTask task in CurrentDictOfTasks[listId])
            {
                taskCounter++;
                if(task.Id > taskCounter)
                {
                    task.Id = taskCounter;
                }
            }
        }
        #endregion

    }
}
