using System;
using System.Collections.Generic;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppCLI
{
    public class PracticeAppCLI
    {
        private ToDoApp ToDoApp { get; set; }

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

        #region ToDo List Menus
        private void DisplayToDoLists()
        {
            bool inDisplayToDoLists = true;

            while (inDisplayToDoLists)
            {
                Console.Clear();
                Console.WriteLine("[0] Return to Main Menu");
                Console.WriteLine();
                foreach (KeyValuePair<int, TaskList> taskList in ToDoApp.CurrentDictOfTaskLists)
                {
                    Console.WriteLine($"[{taskList.Key}] {taskList.Value.Name}");
                }

                int selection = NavigationTools.SelectSingleIntOption("Select a list to view or make changes", 0, ToDoApp.CurrentDictOfTaskLists.Count);

                if (selection == 0)
                {
                    inDisplayToDoLists = false;
                    MainMenu();
                }
                else if (selection > 0 && selection <= ToDoApp.CurrentDictOfTaskLists.Count)
                {
                    ToDoApp.SetCurrentTaskList(selection);
                    DisplayTaskListDetails();
                    inDisplayToDoLists = false;
                }
            }
        }
        private void DisplayTaskListDetails()
        {
            bool inTaskListDetails = true;
            while (inTaskListDetails)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"Name: {ToDoApp.CurrentDictOfTaskLists[(int)ToDoApp.CurrentTaskList.Id].Name}");
                Console.WriteLine($"Description: {ToDoApp.CurrentDictOfTaskLists[(int)ToDoApp.CurrentTaskList.Id].Description}");
                Console.WriteLine();
                Console.WriteLine("[0] To return to the ToDo Lists");
                Console.WriteLine("[1] View Tasks");
                Console.WriteLine("[2] Edit List");
                Console.WriteLine("[3] Remove List and all of its Tasks");

                int selection = NavigationTools.SelectSingleIntOption(0, 3);
                if (selection == 0)
                {
                    inTaskListDetails = false;
                    DisplayToDoLists();
                }
                else if (selection == 1)
                {
                    inTaskListDetails = false;
                    DisplayToDoTasks();
                }
                else if (selection == 2)
                {
                    inTaskListDetails = false;
                    EditToDoList();
                }
                else if(selection == 3)
                {
                    Console.WriteLine();
                    bool removeTaskList = NavigationTools.GetBoolYorN($"Are you sure you want permanently remove {ToDoApp.CurrentTaskList.Name}? [Y/N]: ");
                    if(removeTaskList)
                    {
                        inTaskListDetails = false;
                        ToDoApp.RemoveListandTasks(ToDoApp.CurrentTaskList.Id);
                        DisplayToDoLists();
                    }
                }
            }
        }
        private void EditToDoList()
        {
            bool inEditList = true;
            string name = String.Empty;
            string desc = String.Empty;
            TaskList taskList = new TaskList()
            {
                Id = ToDoApp.CurrentTaskList.Id,
            };

            while (inEditList)
            {
                Console.Clear();
                Console.WriteLine($"Name: {ToDoApp.CurrentTaskList.Name}");
                Console.WriteLine($"Description: {ToDoApp.CurrentTaskList.Description}");
                Console.WriteLine();
                if (!String.IsNullOrEmpty(name))
                {
                    Console.WriteLine($"New Name: {name}");
                }
                if (!String.IsNullOrEmpty(desc))
                {
                    Console.WriteLine($"New Description: {desc}");
                }
                if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(desc))
                {
                    Console.WriteLine();
                }
                Console.WriteLine("[0] Return to To Do Lists");
                Console.WriteLine("[1] Change Name");
                Console.WriteLine("[2] Change Description");
                Console.WriteLine("[3] Save your changes");

                int selection = NavigationTools.SelectSingleIntOption(0, 3);

                if (selection == 0)
                {
                    inEditList = false;
                    DisplayToDoLists();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    name = NavigationTools.GetString("Please enter a new name: ");
                    taskList.Name = name;
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    desc = NavigationTools.GetString("Please enter a new description: ");
                    taskList.Description = desc;
                }
                else if (selection == 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Name: {ToDoApp.CurrentTaskList.Name}");
                    Console.WriteLine($"Description: {ToDoApp.CurrentTaskList.Description}");
                    Console.WriteLine();
                    Console.WriteLine("To...");
                    Console.WriteLine();
                    Console.WriteLine($"Name: {taskList.Name}");
                    Console.WriteLine($"Description: {taskList.Description}");
                    Console.WriteLine();
                    bool saveChanges = NavigationTools.GetBoolYorN("Are you sure you want save these changes? [Y/N]: ");

                    if (saveChanges)
                    {
                        ToDoApp.ChangeList(taskList);
                    }
                }
            }
        }
        #endregion

        #region ToDo Tasks Menus
        private void DisplayToDoTasks()
        {
            bool inDisplayToDoTasks = true;

            while (inDisplayToDoTasks)
            {
                Console.Clear();
                Console.WriteLine("[0] Return to To Do Lists");
                Console.WriteLine();
                foreach (ToDoTask task in ToDoApp.CurrentDictOfTasks[(int)ToDoApp.CurrentTaskList.Id])
                {
                    Console.WriteLine($"[{task.Id}] {task.Name}");
                }
                Console.WriteLine();
                int selection = NavigationTools.SelectSingleIntOption("Select a ToDo Task to see more details...", 0, ToDoApp.CurrentDictOfTasks[(int)ToDoApp.CurrentTaskList.Id].Count);
                if (selection == 0)
                {
                    inDisplayToDoTasks = false;
                    DisplayToDoLists();
                }
                if (selection > 0 && selection <= ToDoApp.CurrentDictOfTasks[(int)ToDoApp.CurrentTaskList.Id].Count)
                {
                    inDisplayToDoTasks = false;
                    ToDoApp.SetCurrentTask(selection, (int)ToDoApp.CurrentTaskList.Id);
                    DisplayToDoTaskDetails();
                }
            }
        }
        private void DisplayToDoTaskDetails()
        {
            bool inTaskDetails = true;
            while (inTaskDetails)
            {
                Console.Clear();
                Console.WriteLine($"Name: {ToDoApp.CurrentTask.Name}");
                Console.WriteLine($"Description: {ToDoApp.CurrentTask.Description}");
                Console.WriteLine();
                Console.WriteLine($"[0] Return to {ToDoApp.CurrentTaskList.Name} Task List");
                Console.WriteLine("[1] Edit Task");
                Console.WriteLine("[2] Remove Task");
                Console.WriteLine();
                int selection = NavigationTools.SelectSingleIntOption(0, 2);

                if (selection == 0)
                {
                    inTaskDetails = false;
                    DisplayToDoTasks();
                }
                else if (selection == 1)
                {
                    inTaskDetails = false;
                    EditToDoTask();
                }
                else if(selection == 2)
                {
                    Console.WriteLine();
                    bool removeTask = NavigationTools.GetBoolYorN($"Are you sure you want permanently remove {ToDoApp.CurrentTask.Name}? [Y/N]: ");
                    if(removeTask)
                    {
                        inTaskDetails = false;
                        ToDoApp.RemoveTask(ToDoApp.CurrentTask.ListId, ToDoApp.CurrentTask.Id);
                        DisplayToDoTasks();
                    }
                }
            }
        }
        private void EditToDoTask()
        {
            bool inEditTask = true;
            string name = String.Empty;
            string desc = String.Empty;
            ToDoTask task = new ToDoTask()
            {
                Id = ToDoApp.CurrentTask.Id,
                ListId = ToDoApp.CurrentTask.ListId
            };

            while (inEditTask)
            {
                Console.Clear();
                Console.WriteLine($"Name: {ToDoApp.CurrentTask.Name}");
                Console.WriteLine($"Description: {ToDoApp.CurrentTask.Description}");
                Console.WriteLine();
                if (!String.IsNullOrEmpty(name))
                {
                    Console.WriteLine($"New Name: {name}");
                }
                if (!String.IsNullOrEmpty(desc))
                {
                    Console.WriteLine($"New Description: {desc}");
                }
                if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(desc))
                {
                    Console.WriteLine();
                }
                Console.WriteLine($"[0] Return to {ToDoApp.CurrentTaskList.Name} Tasks");
                Console.WriteLine("[1] Change Name");
                Console.WriteLine("[2] Change Description");
                Console.WriteLine("[3] Save your changes");

                int selection = NavigationTools.SelectSingleIntOption(0, 3);

                if (selection == 0)
                {
                    inEditTask = false;
                    DisplayToDoTasks();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    name = NavigationTools.GetString("Please enter a new name: ");
                    task.Name = name;
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    desc = NavigationTools.GetString("Please enter a new description: ");
                    task.Description = desc;
                }
                else if (selection == 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Name: {ToDoApp.CurrentTask.Name}");
                    Console.WriteLine($"Description: {ToDoApp.CurrentTask.Description}");
                    Console.WriteLine();
                    Console.WriteLine("To...");
                    Console.WriteLine();
                    Console.WriteLine($"Name: {task.Name}");
                    Console.WriteLine($"Description: {task.Description}");
                    Console.WriteLine();
                    bool saveChanges = NavigationTools.GetBoolYorN("Are you sure you want save these changes? [Y/N]: ");

                    if (saveChanges)
                    {
                        ToDoApp.ChangeTask(task);
                    }
                }
            }
        }
        #endregion
    }
}
