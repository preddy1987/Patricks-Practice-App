using System;
using System.Collections.Generic;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppCLI
{
    class PracticeAppCLI
    {
        public ToDoApp toDoApp = new ToDoApp();
        public void MainMenu()
        {
            bool inMainMenu = true;

            while (inMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App");
                Console.WriteLine();
                Console.WriteLine("[1] View your ToDo Lists");
                Console.WriteLine("[2] Add a new ToDo List");
                Console.WriteLine("[3] Make changes to your ToDo List");
                Console.WriteLine("[4] Exit");
                Console.WriteLine();

                int selection = NavigationTools.SelectSingleIntOption(1, 4);
                if(selection == 1)
                {
                    inMainMenu = false;
                    DisplayToDoLists();
                }
                else if(selection == 2)
                {
                    inMainMenu = false;
                }
                else if(selection == 3)
                {
                    inMainMenu = false;
                }
                else if(selection == 4)
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
                foreach(KeyValuePair<int,TaskList> taskList in toDoApp.CurrentListOfTaskLists)
                {
                    Console.WriteLine($"[{taskList.Key}] {taskList.Value.Name}");
                }
            }
            

        }
    }
}
