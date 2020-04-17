using PracticeApp;
using PracticeApp.Models;
using System;
using System.Collections.Generic;

namespace PracticeAppCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TaskLists
            TaskList TaskListOne = new TaskList()
            {
                Name = "Code!",
                Description = "Eat Sleep Code"
            };
            TaskList TaskListTwo = new TaskList()
            {
                Name = "Social Distancing",
                Description = "Maintain a healthy isolation from others"
            };
            TaskList TaskListThree = new TaskList()
            {
                Name = "Grocery List",
                Description = "Things to get from the store"
            };
            List<TaskList> taskLists = new List<TaskList>()
            {
                TaskListOne,
                TaskListTwo,
                TaskListThree
            };
            #endregion
            #region Tasks
            //task for list 1: Code!
            ToDoTask taskOne = new ToDoTask()
            {
                Name = "Add CRUD Methods",
                Description = "Continue adding CRUD methods to your practice ToDo App",
                ListId = TaskListOne.Id
            };
            ToDoTask taskTwo = new ToDoTask()
            {
                Name = "Add Unit Tests",
                Description = "you should of been adding unit tests from the start",
                ListId = TaskListOne.Id
            };
            ToDoTask taskThree = new ToDoTask()
            {
                Name = "Seriously Add Unit Tests",
                Description = "Before creating a the CRUD method, you should write the Unit Test...Seriously",
                ListId = TaskListOne.Id
            };

            //tasks for list 2: Social Distancing
            ToDoTask taskFour = new ToDoTask()
            {
                Name = "Avoid People",
                Description = "Stay a minimum of 6ft away from others and avoid human contact as much as possible.",
                ListId = TaskListTwo.Id
            };
            ToDoTask taskFive = new ToDoTask()
            {
                Name = "Get a pet",
                Description = "Get a cat or a dog or something you can cuddle. Studies show this reduces stress!",
                ListId = TaskListTwo.Id
            };
            ToDoTask taskSix = new ToDoTask()
            {
                Name = "Pet your pet",
                Description = "Give your pet all the love and attention you can no longer get from people",
                ListId = TaskListTwo.Id
            };

            //tasks for lists 3: Grocery List
            ToDoTask taskSeven = new ToDoTask()
            {
                Name = "Skyline Chili",
                Description = "Cans of Skyline Chili, as many as you can get.",
                ListId = TaskListThree.Id
            };
            ToDoTask taskEight = new ToDoTask()
            {
                Name = "Shredded Cheese",
                Description = "All of the shredded cheese. Yes all of it.",
                ListId = TaskListThree.Id
            };
            ToDoTask taskNine = new ToDoTask()
            {
                Name = "Pasta of your choice",
                Description = "I like spaghetti noodles, but equally as good over penne or fetticini or even rice!",
                ListId = TaskListThree.Id
            };
            List<ToDoTask> toDoTasks = new List<ToDoTask>()
            {
                taskOne,
                taskTwo,
                taskThree,
                taskFour,
                taskFive,
                taskSix,
                taskSeven,
                taskEight,
                taskNine
            };
            #endregion
            ToDoApp toDoApp = new ToDoApp(taskLists, toDoTasks);
            PracticeAppCLI appCLI = new PracticeAppCLI(toDoApp);
            appCLI.MainMenu();
        }
    }
}
