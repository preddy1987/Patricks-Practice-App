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
                Console.WriteLine("[2] Add a new ToDo List");
                Console.WriteLine("[0] Exit");
                Console.WriteLine();

                int selection = NavigationTools.SelectSingleIntOption(0, 2);
                if (selection == 0)
                {
                    inMainMenu = false;
                }
                else if (selection == 1)
                {
                    inMainMenu = false;
                    DisplayToDoLists();
                }
                else if (selection == 2)
                {
                    inMainMenu = false;
                    DisplayAddTaskListView();
                }
            }
        }
        #region ToDo List Menus
        private void DisplayToDoLists()
        {
            bool inDisplayToDoLists = true;
            bool hasMoreThanNineLists = false;
            int pageCount = 1;

            while (inDisplayToDoLists)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App: Currently Viewing Task Lists");
                Console.WriteLine();
                if (ToDoApp.CurrentTaskLists.Count <= 9)
                {
                    int counter = 1;
                    foreach (TaskList taskList in ToDoApp.CurrentTaskLists)
                    {
                        Console.WriteLine($"[{counter}] {taskList.Name}");
                        counter++;
                    }
                }
                else
                {
                    hasMoreThanNineLists = true;
                    if (pageCount == 1)
                    {
                        int counter = 1;
                        foreach (TaskList taskList in ToDoApp.CurrentTaskLists)
                        {
                            if (counter <= 8)
                            {
                                Console.WriteLine($"[{counter}] {taskList.Name}");
                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("[9] Next Page");
                    }
                    if (pageCount > 1)
                    {
                        Console.WriteLine($"Page #{pageCount}");
                        int counter = 1;
                        foreach (TaskList taskList in ToDoApp.CurrentTaskLists)
                        {
                            if (counter <= ((pageCount * 7) + 1) && counter > ((pageCount - 1) * 7) + 1)
                            {
                                Console.WriteLine($"[{counter - (((pageCount - 1) * 7) + 1)}] {taskList.Name}");
                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("[8] Previous Page");
                        if (ToDoApp.CurrentTaskLists.Count > ((pageCount - 1) * 7) + 8)
                        {
                            Console.WriteLine("[9] Next Page");
                        }
                    }
                }
                Console.WriteLine("[0] Return to Main Menu");

                int selection = NavigationTools.SelectSingleIntOption("Select a list to view or make changes", 0, 9);

                if (selection == 0)
                {
                    inDisplayToDoLists = false;
                    MainMenu();
                }
                else if (selection > 0 && selection <= 9 && !hasMoreThanNineLists)
                {
                    ToDoApp.SetSelectedTaskList(ToDoApp.CurrentTaskLists[selection - 1].Id);
                    DisplayTaskListDetails();
                    inDisplayToDoLists = false;
                }
                else if (selection > 0 && selection <= 8 && hasMoreThanNineLists && pageCount == 1)
                {
                    ToDoApp.SetSelectedTaskList(ToDoApp.CurrentTaskLists[selection - 1].Id);
                    DisplayTaskListDetails();
                    inDisplayToDoLists = false;
                }
                else if (selection > 0 && selection <= 7 && hasMoreThanNineLists && pageCount > 1)
                {

                    ToDoApp.SetSelectedTaskList(ToDoApp.CurrentTaskLists[(selection - 1) + ((pageCount - 1) * 7) + 1].Id );
                    DisplayTaskListDetails();
                    inDisplayToDoLists = false;
                }
                else if (selection == 8 && hasMoreThanNineLists && pageCount > 1)
                {
                    pageCount--;
                }
                else if (selection == 9 && hasMoreThanNineLists && ToDoApp.CurrentTaskLists.Count > ((pageCount - 1) * 7) + 8)
                {
                    pageCount++;
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
                Console.WriteLine($"Name: {ToDoApp.SelectedTaskList.Name}");
                Console.WriteLine($"Description: {ToDoApp.SelectedTaskList.Description}");
                Console.WriteLine();
                Console.WriteLine("[0] To return to the ToDo Lists");
                Console.WriteLine("[1] View Tasks");
                Console.WriteLine("[2] Edit List");
                Console.WriteLine("[3] Add a New Task");
                Console.WriteLine("[4] Remove List and all of its Tasks");

                int selection = NavigationTools.SelectSingleIntOption(0, 4);
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
                else if (selection == 3)
                {
                    inTaskListDetails = false;
                    DisplayAddToDoTaskView();
                }
                else if (selection == 4)
                {
                    Console.WriteLine();
                    bool removeTaskList = NavigationTools.GetBoolYorN($"Are you sure you want permanently remove {ToDoApp.SelectedTaskList.Name}? [Y/N]: ");
                    if (removeTaskList)
                    {
                        inTaskListDetails = false;
                        ToDoApp.RemoveTaskList(ToDoApp.SelectedTaskList.Id);
                        //remove associated tasks
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
                Id = ToDoApp.SelectedTaskList.Id,
            };

            while (inEditList)
            {
                Console.Clear();
                Console.WriteLine($"Name: {ToDoApp.SelectedTaskList.Name}");
                Console.WriteLine($"Description: {ToDoApp.SelectedTaskList.Description}");
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
                    Console.WriteLine($"Name: {ToDoApp.SelectedTaskList.Name}");
                    Console.WriteLine($"Description: {ToDoApp.SelectedTaskList.Description}");
                    Console.WriteLine();
                    Console.WriteLine("To...");
                    Console.WriteLine();
                    Console.WriteLine($"Name: {taskList.Name}");
                    Console.WriteLine($"Description: {taskList.Description}");
                    Console.WriteLine();
                    bool saveChanges = NavigationTools.GetBoolYorN("Are you sure you want save these changes? [Y/N]: ");

                    if (saveChanges)
                    {
                        ToDoApp.UpdateTaskList(taskList);
                    }
                }
            }
        }
        private void DisplayAddTaskListView()
        {
            bool inAddTaskListView = true;

            TaskList taskList = new TaskList()
            {
                Name = String.Empty,
                Description = String.Empty
            };

            while (inAddTaskListView)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App: Creating a New ToDo List");
                Console.WriteLine();
                Console.WriteLine($"Name: {taskList.Name}");
                Console.WriteLine($"Description: {taskList.Description}");
                Console.WriteLine();
                Console.WriteLine("[1] Add a Name");
                Console.WriteLine("[2] Add a Description");
                Console.WriteLine("[3] Save ToDo List");
                Console.WriteLine("[0] Cancel and Return to the Main Menu");

                int selection = NavigationTools.SelectSingleIntOption(0, 3);

                if (selection == 0)
                {
                    inAddTaskListView = false;
                    MainMenu();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    taskList.Name = NavigationTools.GetString("Enter a Name: ");
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    taskList.Description = NavigationTools.GetString("Enter a Description: ");
                }
                else if (selection == 3)
                {
                    bool saveTaskList = false;
                    Console.WriteLine();
                    Console.WriteLine();
                    if (!String.IsNullOrEmpty(taskList.Name))
                    {
                        if (!String.IsNullOrEmpty(taskList.Description))
                        {
                            saveTaskList = NavigationTools.GetBoolYorN("Are you sure you want save these changes? [Y/N]: ");
                        }
                        else
                        {
                            Console.WriteLine("Please add a Description to your ToDo List before saving");
                        }
                    }
                    else if (String.IsNullOrEmpty(taskList.Description) && String.IsNullOrEmpty(taskList.Name))
                    {
                        Console.WriteLine("Please add a Name and a Description to your ToDo List before saving");
                    }
                    else
                    {
                        Console.WriteLine("Please add a Name to your ToDo List before saving");
                    }

                    if (saveTaskList)
                    {
                        ToDoApp.AddNewTaskList(taskList);
                        inAddTaskListView = false;
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }
        #endregion

        #region ToDo Tasks Menus
        private void DisplayToDoTasks()
        {
            bool inDisplayToDoTasks = true;
            bool hasMoreThanNineTasks = false;
            int pageCount = 1;
            List<ToDoTask> toDoTasks = ToDoApp.GetToDoTasks(ToDoApp.SelectedTaskList.Id);

            while (inDisplayToDoTasks)
            {
                Console.Clear();

                Console.WriteLine();
                if (ToDoApp.CurrentToDoTasks.Count <= 9)
                {
                    int counter = 1;
                    foreach (ToDoTask task in toDoTasks)
                    {
                        Console.WriteLine($"[{counter}] {task.Name}");
                        counter++;
                    }
                }
                else
                {
                    hasMoreThanNineTasks = true;
                    if (pageCount == 1)
                    {
                        int counter = 1;
                        foreach (ToDoTask task in toDoTasks)
                        {
                            if (counter <= 8)
                            {
                                Console.WriteLine($"[{task.Id}] {task.Name}");
                            }
                            counter++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("[9] Next Page");
                    }
                    if (pageCount > 1)
                    {
                        int counter = 1;
                        foreach (ToDoTask task in toDoTasks)
                        {
                            if (counter <= ((pageCount * 7) + 1) && counter > ((pageCount - 1) * 7) + 1)
                            {
                                Console.WriteLine($"[{counter - (((pageCount - 1) * 7) + 1)}] {task.Name}");
                            }
                            counter++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("[8] Previous Page");
                        if (toDoTasks.Count > ((pageCount - 1) * 7) + 8)
                        {
                            Console.WriteLine("[9] Next Page");
                        }
                    }
                }
                Console.WriteLine("[0] Return to To Do Lists");

                Console.WriteLine();
                int selection = NavigationTools.SelectSingleIntOption("Select a ToDo Task to see more details...", 0, 9);
                if (selection == 0)
                {
                    inDisplayToDoTasks = false;
                    DisplayToDoLists();
                }
                else if (selection > 0 && selection <= 9 && !hasMoreThanNineTasks)
                {
                    inDisplayToDoTasks = false;
                    ToDoApp.SetSelectedToDoTask(toDoTasks[selection - 1].Id);
                    DisplayToDoTaskDetails();
                }
                else if (selection > 0 && selection <= 8 && hasMoreThanNineTasks && pageCount == 1)
                {
                    inDisplayToDoTasks = false;
                    ToDoApp.SetSelectedToDoTask(toDoTasks[selection - 1].Id);
                    DisplayToDoTaskDetails();
                }
                else if (selection > 0 && selection <= 7 && hasMoreThanNineTasks && pageCount > 1)
                {
                    inDisplayToDoTasks = false;
                    ToDoApp.SetSelectedToDoTask(toDoTasks[(selection - 1) + ((pageCount - 1) * 7) + 1].Id);
                    DisplayToDoTaskDetails();
                }
                else if (selection == 8 && hasMoreThanNineTasks && pageCount > 1)
                {
                    pageCount--;
                }
                else if (selection == 9 && hasMoreThanNineTasks && toDoTasks.Count > ((pageCount - 1) * 7) + 8)
                {
                    pageCount++;
                }
            }
        }
        private void DisplayToDoTaskDetails()
        {
            bool inTaskDetails = true;
            while (inTaskDetails)
            {
                Console.Clear();
                Console.WriteLine($"Name: {ToDoApp.SelectedToDoTask.Name}");
                Console.WriteLine($"Description: {ToDoApp.SelectedToDoTask.Description}");
                Console.WriteLine();
                Console.WriteLine($"[0] Return to {ToDoApp.SelectedTaskList.Name} Task List");
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
                else if (selection == 2)
                {
                    Console.WriteLine();
                    bool removeTask = NavigationTools.GetBoolYorN($"Are you sure you want permanently remove {ToDoApp.SelectedToDoTask.Name}? [Y/N]: ");
                    if (removeTask)
                    {
                        inTaskDetails = false;
                        ToDoApp.RemoveTask(ToDoApp.SelectedToDoTask.Id);
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
                Id = ToDoApp.SelectedToDoTask.Id,
                ListId = ToDoApp.SelectedToDoTask.ListId
            };

            while (inEditTask)
            {
                Console.Clear();
                Console.WriteLine($"Name: {ToDoApp.SelectedToDoTask.Name}");
                Console.WriteLine($"Description: {ToDoApp.SelectedToDoTask.Description}");
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
                Console.WriteLine($"[0] Return to {ToDoApp.SelectedTaskList.Name} Tasks");
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
                    Console.WriteLine($"Name: {ToDoApp.SelectedTaskList.Name}");
                    Console.WriteLine($"Description: {ToDoApp.SelectedTaskList.Description}");
                    Console.WriteLine();
                    Console.WriteLine("To...");
                    Console.WriteLine();
                    Console.WriteLine($"Name: {task.Name}");
                    Console.WriteLine($"Description: {task.Description}");
                    Console.WriteLine();
                    bool saveChanges = NavigationTools.GetBoolYorN("Are you sure you want save these changes? [Y/N]: ");

                    if (saveChanges)
                    {
                        ToDoApp.UpdateToDoTask(task);
                    }
                }
            }
        }
        private void DisplayAddToDoTaskView()
        {
            bool inAddToDoTaskView = true;

            ToDoTask task = new ToDoTask()
            {
                ListId = ToDoApp.SelectedTaskList.Id,
                Name = String.Empty,
                Description = String.Empty
            };

            while (inAddToDoTaskView)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App: Creating a New ToDo Task");
                Console.WriteLine();
                Console.WriteLine($"Name: {task.Name}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine();
                Console.WriteLine("[1] Add a Name");
                Console.WriteLine("[2] Add a Description");
                Console.WriteLine("[3] Save ToDo Task");
                Console.WriteLine($"[0] Cancel and Return to {ToDoApp.SelectedTaskList.Name}'s Details page");

                int selection = NavigationTools.SelectSingleIntOption(0, 3);

                if (selection == 0)
                {
                    inAddToDoTaskView = false;
                    DisplayTaskListDetails();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    task.Name = NavigationTools.GetString("Enter a Name: ");
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    task.Description = NavigationTools.GetString("Enter a Description: ");
                }
                else if (selection == 3)
                {
                    bool saveTaskList = false;
                    Console.WriteLine();
                    Console.WriteLine();
                    if (!String.IsNullOrEmpty(task.Name))
                    {
                        if (!String.IsNullOrEmpty(task.Description))
                        {
                            saveTaskList = NavigationTools.GetBoolYorN("Are you sure you want save these changes? [Y/N]: ");
                        }
                        else
                        {
                            Console.WriteLine("Please add a Description to your ToDo Task before saving");
                        }
                    }
                    else if (String.IsNullOrEmpty(task.Description) && String.IsNullOrEmpty(task.Name))
                    {
                        Console.WriteLine("Please add a Name and a Description to your ToDo Task before saving");
                    }
                    else
                    {
                        Console.WriteLine("Please add a Name to your ToDo Task before saving");
                    }

                    if (saveTaskList)
                    {
                        ToDoApp.AddNewTask(task);
                        inAddToDoTaskView = false;
                        DisplayTaskListDetails();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }
        #endregion
    }
}
