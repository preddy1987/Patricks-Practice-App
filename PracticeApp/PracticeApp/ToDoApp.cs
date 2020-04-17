using PracticeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeApp
{
    public class ToDoApp
    {
        #region Properties and Member Variables
        public ToDoTask SelectedToDoTask { get; set; }
        public TaskList SelectedTaskList { get; set; }
        public List<TaskList> CurrentTaskLists { get; set; }
        public List<ToDoTask> CurrentToDoTasks { get; set; }
        #endregion

        #region Constructors
        public ToDoApp()
        {
            CurrentTaskLists = new List<TaskList>();
            CurrentToDoTasks = new List<ToDoTask>();
        }
        public ToDoApp(List<TaskList> taskLists, List<ToDoTask> toDoTasks)
        {
            CurrentTaskLists = taskLists;
            CurrentToDoTasks = toDoTasks;
        }
        //public void CreateDummyData()
        //{
        //    #region TaskLists
        //    TaskList testTaskListOne = new TaskList()
        //    {
        //        Name = "Code!",
        //        Description = "Eat Sleep Code"
        //    };
        //    TaskList testTaskListTwo = new TaskList()
        //    {
        //        Name = "Social Distancing",
        //        Description = "Maintain a healthy isolation from others"
        //    };
        //    TaskList testTaskListThree = new TaskList()
        //    {
        //        Name = "Grocery List",
        //        Description = "Things to get from the store"
        //    };
        //    AddNewList(testTaskListOne);
        //    AddNewList(testTaskListTwo);
        //    AddNewList(testTaskListThree);
        //    #endregion

        //    #region Tasks
        //    //task for list 1: Code!
        //    ToDoTask taskOne = new ToDoTask()
        //    {
        //        Name = "Add CRUD Methods",
        //        Description = "Continue adding CRUD methods to your practice ToDo App",
        //        ListId = 1
        //    };
        //    AddNewTask(taskOne);
        //    ToDoTask taskTwo = new ToDoTask()
        //    {
        //        Name = "Add Unit Tests",
        //        Description = "you should of been adding unit tests from the start",
        //        ListId = 1
        //    };
        //    AddNewTask(taskTwo);
        //    ToDoTask taskThree = new ToDoTask()
        //    {
        //        Name = "Seriously Add Unit Tests",
        //        Description = "Before creating a the CRUD method, you should write the Unit Test...Seriously",
        //        ListId = 1
        //    };
        //    AddNewTask(taskThree);

        //    //tasks for list 2: Social Distancing
        //    ToDoTask taskFour = new ToDoTask()
        //    {
        //        Name = "Avoid People",
        //        Description = "Stay a minimum of 6ft away from others and avoid human contact as much as possible.",
        //        ListId = 2
        //    };
        //    AddNewTask(taskFour);
        //    ToDoTask taskFive = new ToDoTask()
        //    {
        //        Name = "Get a pet",
        //        Description = "Get a cat or a dog or something you can cuddle. Studies show this reduces stress!",
        //        ListId = 2
        //    };
        //    AddNewTask(taskFive);
        //    ToDoTask taskSix = new ToDoTask()
        //    {
        //        Name = "Pet your pet",
        //        Description = "Give your pet all the love and attention you can no longer get from people",
        //        ListId = 2
        //    };
        //    AddNewTask(taskSix);

        //    //tasks for lists 3: Grocery List
        //    ToDoTask taskSeven = new ToDoTask()
        //    {
        //        Name = "Skyline Chili",
        //        Description = "Cans of Skyline Chili, as many as you can get.",
        //        ListId = 3
        //    };
        //    AddNewTask(taskSeven);
        //    ToDoTask taskEight = new ToDoTask()
        //    {
        //        Name = "Shredded Cheese",
        //        Description = "All of the shredded cheese. Yes all of it.",
        //        ListId = 3
        //    };
        //    AddNewTask(taskEight);
        //    ToDoTask taskNine = new ToDoTask()
        //    {
        //        Name = "Pasta of your choice",
        //        Description = "I like spaghetti noodles, but equally as good over penne or fetticini or even rice!",
        //        ListId = 3
        //    };
        //    AddNewTask(taskNine);
        //    #endregion
        //}
        //public void CreateEvenMoreDummyData(int numberOfExtraTasksAndLists)
        //{
        //    //adding more TaskLists
        //    for (int i = 4; i <= numberOfExtraTasksAndLists; i++)
        //    {
        //        TaskList extraTaskList = new TaskList()
        //        {
        //            Name = $"Extra List #{i}",
        //            Description = $"Extra List of tasks"
        //        };
        //        AddNewList(extraTaskList);
        //    }
        //    //adding more Tasks
        //    foreach (KeyValuePair<int, TaskList> taskList in CurrentDictOfTaskLists)
        //    {
        //        if (CurrentDictOfTasks.ContainsKey(taskList.Key))
        //        {
        //            for (int i = CurrentDictOfTasks[taskList.Key].Count; i <= numberOfExtraTasksAndLists; i++)
        //            {
        //                ToDoTask extraTasks = new ToDoTask()
        //                {
        //                    Name = $"Extra Task #{i}",
        //                    Description = "Extra Task for Testing",
        //                    ListId = taskList.Key
        //                };
        //                AddNewTask(extraTasks);
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 1; i <= numberOfExtraTasksAndLists; i++)
        //            {
        //                ToDoTask extraTasks = new ToDoTask()
        //                {
        //                    Name = $"Extra Task #{i}",
        //                    Description = "Extra Task for Testing",
        //                    ListId = taskList.Key
        //                };
        //                AddNewTask(extraTasks);
        //            }
        //        }
        //    }
        //}
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
        public List<ToDoTask> GetToDoTasks(Guid? listid)
        {
            List<ToDoTask> toDoTasks = CurrentToDoTasks.Where(t => t.ListId == listid).ToList();
            return toDoTasks;
        }
        public void UpdateToDoTask(ToDoTask updatedTask)
        {
            CurrentToDoTasks.Where(t => t.Id == updatedTask.Id).Select(t => { t.Name = updatedTask.Name; t.Description = updatedTask.Description; return t; }).ToList();
        }
        /// <summary>
        /// Removes Task from the Current Dictionary of Tasks
        /// </summary>
        /// <param name="taskId"></param>
        public void RemoveTask(Guid? taskId)
        {
            CurrentToDoTasks.Remove(CurrentToDoTasks.Find(t=> t.Id == taskId));
        }
        #endregion

    }
}
