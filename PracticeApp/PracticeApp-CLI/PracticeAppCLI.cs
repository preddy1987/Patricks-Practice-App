using System;
using System.Collections.Generic;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppCLI
{
    class PracticeAppCLI
    {
        public ToDoApp ToDoApp { get; set; }

        #region Constructors
        public PracticeAppCLI(ToDoApp toDoApp)
        {
            ToDoApp = toDoApp;
        }
        #endregion
        public void MainMenu()
        {
            bool inMainMenu = true;

            while (inMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App");
                Console.WriteLine();
                Console.WriteLine("[1] View your ToDo Lists");
                Console.WriteLine("[0] Exit");
                Console.WriteLine();

                int selection = NavigationTools.SelectSingleIntOption(0, 1);
                if(selection == 1)
                {
                    inMainMenu = false;
                    DisplayToDoLists();
                }
                else if(selection == 0)
                {
                    inMainMenu = false;
                }
            }
        }

        public void DisplayToDoLists()
        {
            bool inDisplayToDoLists = true;

            while(inDisplayToDoLists)
            {
                Console.Clear();
                Console.WriteLine("[0] Return to Main Menu");
                Console.WriteLine();
                foreach(KeyValuePair<int,TaskList> taskList in ToDoApp.CurrentDictOfTaskLists)
                {
                    Console.WriteLine($"[{taskList.Key}] {taskList.Value.Name}");
                }

                int selection = NavigationTools.SelectSingleIntOption("Select a list to view or make changes",0, ToDoApp.CurrentDictOfTaskLists.Count);

                if (selection == 0)
                {
                    inDisplayToDoLists = false;
                    MainMenu();
                }
                else if (selection > 0 && selection <= ToDoApp.CurrentDictOfTaskLists.Count)
                {
                    ToDoApp.SetCurrentTaskList(selection);
                    ViewOrEditList();
                    inDisplayToDoLists = false;
                }
            }
        }

        public void ViewOrEditList()
        {
            bool inViewOrEditList = true;
            while(inViewOrEditList)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"Name: {ToDoApp.CurrentDictOfTaskLists[(int)ToDoApp.CurrentTaskList.Id].Name}");
                Console.WriteLine($"Description: {ToDoApp.CurrentDictOfTaskLists[(int)ToDoApp.CurrentTaskList.Id].Description}");
                Console.WriteLine();
                Console.WriteLine("[0] To return to the ToDo Lists");
                Console.WriteLine("[1] View Tasks");
                Console.WriteLine("[2] Edit List");

                int selection = NavigationTools.SelectSingleIntOption(0, 2);
                if (selection == 0)
                {

                }
                else if (selection == 1)
                {
                    inViewOrEditList = false;
                    DisplayToDoTasks();
                }
            }
        }
        public void DisplayToDoTasks()
        {
            bool inDisplayToDoTasks = true;

            while(inDisplayToDoTasks)
            {
                Console.Clear();
                Console.WriteLine("[0] Return to To Do Lists");
                Console.WriteLine();
                foreach(ToDoTask task in ToDoApp.CurrentDictOfTasks[(int)ToDoApp.CurrentTaskList.Id])
                {
                    Console.WriteLine($"[{task.Id}] {task.Name}");
                }
                Console.ReadKey();
            }
        }
    }
}
