using System;
using System.Collections.Generic;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppCLI
{
    public class PracticeAppCLI
    {
        private ToDoApp ToDoApp { get; set; }
        private int NumberOfTaskListstoDisplayPerPage { get; set; } = 10;
        private int NumberOfToDoTasksToDisplayPerPage { get; set; } = 10;
        private bool CategoryView { get; set; } = true;

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
                Console.WriteLine("[3] Application Settings");
                Console.WriteLine("[Q] Exit");
                Console.WriteLine();

                int selection = NavigationTools.SelectSingleIntegerOrQ(1, 3);
                if (selection == -1)
                {
                    inMainMenu = false;
                }
                else if (selection == 1)
                {
                    inMainMenu = false;
                    if(!CategoryView)
                    {
                        DisplayToDoLists(ToDoApp.CurrentTaskLists);
                    }
                    else
                    {
                        DisplayTaskListsCategoryView();
                    }
                }
                else if (selection == 2)
                {
                    inMainMenu = false;
                    DisplayAddTaskListView();
                }
                else if (selection == 3)
                {
                    inMainMenu = false;
                    DisplaySettings();
                }
            }
        }
        public void DisplaySettings()
        {
            bool inDisplaySettings = true;
            int? taskListsPerPage = null;
            int? toDoTasksPerPage = null;
            bool? changeCategoryView = null;

            while (inDisplaySettings)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App: Settings");
                Console.WriteLine();               
                Console.WriteLine($"Number of Task Lists per page: {NumberOfTaskListstoDisplayPerPage} (Default: 10)");
                Console.WriteLine($"Number of ToDo Tasks per page: {NumberOfToDoTasksToDisplayPerPage} (Default: 10)");
                Console.WriteLine($"Task List Category View Enabled: {CategoryView}");
                Console.WriteLine();
                if (taskListsPerPage != null)
                {
                    Console.WriteLine($"New number of Task Lists per page: {taskListsPerPage}");
                }
                if(toDoTasksPerPage != null)
                {
                    Console.WriteLine($"New number of ToDo Tasks per page: {toDoTasksPerPage}");
                }
                if(changeCategoryView != null)
                {
                    Console.WriteLine($"Updated Task List Category View Enabled: {changeCategoryView}");
                }
                Console.WriteLine();
                Console.WriteLine("[1] Change Number of Task Lists");
                Console.WriteLine("[2] Change Number of ToDo Tasks");
                Console.WriteLine("[3] Toggle Task List Category View");
                Console.WriteLine("[4] Save Changes");
                Console.WriteLine("[Q] Return to Main Menu");

                int selection = NavigationTools.SelectSingleIntegerOrQ(1,4);
                if (selection == -1)
                {
                    inDisplaySettings = false;
                    MainMenu();
                }
                else if (selection == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Current number of Task Lists per page: {NumberOfTaskListstoDisplayPerPage}");
                    Console.WriteLine();
                    taskListsPerPage = NavigationTools.SelectInteger("Input a value between 1 and 50: ", 1, 50);

                }
                else if (selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"Current number of ToDo Tasks per page: {NumberOfToDoTasksToDisplayPerPage}");
                    Console.WriteLine();
                    toDoTasksPerPage = NavigationTools.SelectInteger("Input a value between 1 and 50: ", 1, 50);
                }
                else if (selection == 3)
                {
                    Console.Clear();
                    Console.WriteLine();
                    changeCategoryView = NavigationTools.GetBoolYorN("[Y] To enable Category View \n[N] To disable Category View\n[Y]/[N]: ");                    
                }
                else if (selection == 4)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"Current number of Task Lists per page: {NumberOfTaskListstoDisplayPerPage}");
                    Console.WriteLine($"Current number of ToDo Tasks per page: {NumberOfToDoTasksToDisplayPerPage}");
                    Console.WriteLine();
                    Console.WriteLine("To...");
                    Console.WriteLine();
                    if (taskListsPerPage != null)
                    {
                        Console.WriteLine($"New number of Task Lists per page: {taskListsPerPage}");
                    }
                    if (toDoTasksPerPage != null)
                    {
                        Console.WriteLine($"New number of ToDo Tasks per page: {toDoTasksPerPage}");
                    }
                    if(changeCategoryView != null)
                    {
                        Console.WriteLine($"Updated Task List Category View Enabled: {changeCategoryView}");
                    }
                    Console.WriteLine();

                    bool shouldSave = NavigationTools.GetBoolYorN("Are you sure you want save these settings? [Y]/[N]: ");
                    if (shouldSave)
                    {
                        if (taskListsPerPage != null)
                        {
                            NumberOfTaskListstoDisplayPerPage = (int)taskListsPerPage;
                            taskListsPerPage = null;
                        }
                        if (taskListsPerPage != null)
                        {
                            NumberOfToDoTasksToDisplayPerPage = (int)toDoTasksPerPage;
                            toDoTasksPerPage = null;
                        }
                        if(changeCategoryView != null)
                        {
                            CategoryView = (bool)changeCategoryView;
                            changeCategoryView = null;
                        }
                    }
                }
            }
        }
        #region ToDo List Menus
        private void DisplayTaskListsCategoryView()
        {
            bool inCategoryView = true;

            while(inCategoryView)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo App: Category View");
                Console.WriteLine();
                int counter = 1;
                foreach(Category category in ToDoApp.CurrentCategories)
                {
                    Console.WriteLine($"[{counter}] {category.Name}");
                    counter++;
                }
                Console.WriteLine();
                Console.WriteLine("[Q] To Return to the Main Menu");

                int selection = NavigationTools.SelectSingleIntegerOrQ(1, ToDoApp.CurrentCategories.Count);
                if(selection == -1)
                {
                    inCategoryView = false;
                    MainMenu();
                }
                else if(selection <= ToDoApp.CurrentCategories.Count && selection > 0)
                {
                    inCategoryView = false;
                    List<TaskList> taskLists = ToDoApp.GetTaskListsByCategoryId(ToDoApp.CurrentCategories[selection - 1].Id);
                    ToDoApp.SetSelectedCategory(ToDoApp.CurrentCategories[selection - 1].Name);
                    DisplayToDoLists(taskLists);
                }
            }
            

        }
        private void DisplayToDoLists(List<TaskList> taskLists)
        {
            bool inDisplayToDoLists = true;
            bool multiPage = false;
            int pageCount = 1;

            if(NumberOfTaskListstoDisplayPerPage < taskLists.Count)
            {
                multiPage = true;
            }

            while (inDisplayToDoLists)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App: Currently Viewing Task Lists");
                Console.WriteLine();
                if (!multiPage)
                {
                    int counter = 1;
                    foreach (TaskList taskList in taskLists)
                    {
                        Console.WriteLine($"[{counter}] {taskList.Name}");
                        counter++;
                    }
                }
                else
                {
                    if (pageCount == 1)
                    {
                        int counter = 1;
                        foreach (TaskList taskList in taskLists)
                        {
                            if (counter <= NumberOfTaskListstoDisplayPerPage)
                            {
                                Console.WriteLine($"[{counter}] {taskList.Name}");
                            }
                            counter++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("[F] Next Page");
                    }
                    if (pageCount > 1)
                    {
                        Console.WriteLine($"Page #{pageCount}");
                        int counter = 1;
                        foreach (TaskList taskList in taskLists)
                        {
                            if ((counter <= (NumberOfTaskListstoDisplayPerPage * pageCount)) && counter > (NumberOfTaskListstoDisplayPerPage * (pageCount - 1)))
                            {
                                Console.WriteLine($"[{counter}] {taskList.Name}");
                            }
                            counter++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("[B] Previous Page");
                        if (taskLists.Count > NumberOfTaskListstoDisplayPerPage * pageCount)
                        {
                            Console.WriteLine("[F] Next Page");
                        }
                    }
                }
                Console.WriteLine("[Q] Return to Main Menu");

                int selection = NavigationTools.SelectIntegerOrQorForB("Select a list to view or make changes", 1, ToDoApp.CurrentTaskLists.Count);

                if (selection == -1)
                {
                    inDisplayToDoLists = false;
                    MainMenu();
                }
                else if(selection == -2)
                {
                    pageCount++;
                }
                else if(selection == -3)
                {
                    pageCount--;
                }
                else if (selection > 0 && selection <= ToDoApp.CurrentTaskLists.Count)
                {
                    ToDoApp.SetSelectedTaskList(ToDoApp.CurrentTaskLists[selection - 1].Id);
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
                Console.WriteLine($"Name: {ToDoApp.SelectedTaskList.Name}");
                Console.WriteLine($"Description: {ToDoApp.SelectedTaskList.Description}");
                Console.WriteLine();
                
                Console.WriteLine("[1] View Tasks");
                Console.WriteLine("[2] Edit List");
                Console.WriteLine("[3] Add a New Task");
                Console.WriteLine("[4] Remove List and all of its Tasks");
                Console.WriteLine("[Q] To return to the ToDo Lists");

                int selection = NavigationTools.SelectSingleIntegerOrQ(1, 4);
                if (selection == -1)
                {
                    inTaskListDetails = false;
                    if(CategoryView)
                    {
                        List<TaskList> taskLists = ToDoApp.GetTaskListsByCategoryId(ToDoApp.SelectedCategory.Id);
                        DisplayToDoLists(taskLists);
                    }
                    else
                    {
                        DisplayToDoLists(ToDoApp.CurrentTaskLists);
                    }                 
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
                        ToDoApp.RemoveAllTasksByListId(ToDoApp.SelectedTaskList.Id);
                        ToDoApp.RemoveTaskList(ToDoApp.SelectedTaskList.Id);
                        if (CategoryView)
                        {
                            List<TaskList> taskLists = ToDoApp.GetTaskListsByCategoryId(ToDoApp.SelectedCategory.Id);
                            DisplayToDoLists(taskLists);
                        }
                        else
                        {
                            DisplayToDoLists(ToDoApp.CurrentTaskLists);
                        }
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
                
                Console.WriteLine("[1] Change Name");
                Console.WriteLine("[2] Change Description");
                Console.WriteLine("[3] Save your changes");
                Console.WriteLine("[Q] Return to To Do Lists");

                int selection = NavigationTools.SelectSingleIntegerOrQ(1, 3);

                if (selection == -1)
                {
                    inEditList = false;
                    if (CategoryView)
                    {
                        List<TaskList> taskLists = ToDoApp.GetTaskListsByCategoryId(ToDoApp.SelectedCategory.Id);
                        DisplayToDoLists(taskLists);
                    }
                    else
                    {
                        DisplayToDoLists(ToDoApp.CurrentTaskLists);
                    }
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    name = NavigationTools.SelectString("Please enter a new name: ");
                    taskList.Name = name;
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    desc = NavigationTools.SelectString("Please enter a new description: ");
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
                Console.WriteLine("[Q] Cancel and Return to the Main Menu");

                int selection = NavigationTools.SelectSingleIntegerOrQ(0, 3);

                if (selection == -1)
                {
                    inAddTaskListView = false;
                    MainMenu();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    taskList.Name = NavigationTools.SelectString("Enter a Name: ");
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    taskList.Description = NavigationTools.SelectString("Enter a Description: ");
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
            int pageCount = 1;
            bool multiPage = false;
            List<ToDoTask> toDoTasks = ToDoApp.GetToDoTasksByListId(ToDoApp.SelectedTaskList.Id);

            while (inDisplayToDoTasks)
            {
                Console.Clear();

                Console.WriteLine();
                if (toDoTasks.Count > NumberOfToDoTasksToDisplayPerPage)
                {
                    multiPage = true;
                }

                if(!multiPage)
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
                    if (pageCount == 1)
                    {
                        int counter = 1;
                        foreach (ToDoTask task in toDoTasks)
                        {
                            if (counter <= NumberOfToDoTasksToDisplayPerPage)
                            {
                                Console.WriteLine($"[{counter}] {task.Name}");
                            }
                            counter++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("[F] Next Page");
                    }
                    if (pageCount > 1)
                    {
                        int counter = 1;
                        foreach (ToDoTask task in toDoTasks)
                        {
                            if ((counter <= (NumberOfToDoTasksToDisplayPerPage * pageCount)) && counter > (NumberOfToDoTasksToDisplayPerPage * (pageCount - 1)))
                            {
                                Console.WriteLine($"[{counter}] {task.Name}");
                            }
                            counter++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("[B] Previous Page");
                        if (toDoTasks.Count > NumberOfTaskListstoDisplayPerPage * pageCount)
                        {
                            Console.WriteLine("[F] Next Page");
                        }
                    }
                }
                Console.WriteLine("[Q] Return to To Do Lists");

                Console.WriteLine();
                int selection = NavigationTools.SelectIntegerOrQorForB("Select a ToDo Task to see more details...", 1, toDoTasks.Count);
                if (selection == -1)
                {
                    inDisplayToDoTasks = false;
                    if (CategoryView)
                    {
                        List<TaskList> taskLists = ToDoApp.GetTaskListsByCategoryId(ToDoApp.SelectedCategory.Id);
                        DisplayToDoLists(taskLists);
                    }
                    else
                    {
                        DisplayToDoLists(ToDoApp.CurrentTaskLists);
                    }
                }
                else if (selection == -2)
                {
                    pageCount++;
                }
                else if (selection == -3)
                {
                    pageCount++;
                }
                else if (selection > 0 && selection <= toDoTasks.Count)
                {
                    inDisplayToDoTasks = false;
                    ToDoApp.SetSelectedToDoTask(toDoTasks[(selection - 1)].Id);
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
                Console.WriteLine($"Name: {ToDoApp.SelectedToDoTask.Name}");
                Console.WriteLine($"Description: {ToDoApp.SelectedToDoTask.Description}");
                Console.WriteLine();
                Console.WriteLine("[1] Edit Task");
                Console.WriteLine("[2] Remove Task");
                Console.WriteLine($"[Q] Return to {ToDoApp.SelectedTaskList.Name} Task List");
                Console.WriteLine();
                int selection = NavigationTools.SelectSingleIntegerOrQ(1, 2);

                if (selection == -1)
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
                
                Console.WriteLine("[1] Change Name");
                Console.WriteLine("[2] Change Description");
                Console.WriteLine("[3] Save your changes");
                Console.WriteLine($"[Q] Return to {ToDoApp.SelectedTaskList.Name} Tasks");

                int selection = NavigationTools.SelectSingleIntegerOrQ(1, 3);

                if (selection == -1)
                {
                    inEditTask = false;
                    DisplayToDoTasks();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    name = NavigationTools.SelectString("Please enter a new name: ");
                    task.Name = name;
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    desc = NavigationTools.SelectString("Please enter a new description: ");
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
                Console.WriteLine($"[Q] Cancel and Return to {ToDoApp.SelectedTaskList.Name}'s Details page");

                int selection = NavigationTools.SelectSingleIntegerOrQ(1, 3);

                if (selection == -1)
                {
                    inAddToDoTaskView = false;
                    DisplayTaskListDetails();
                }
                else if (selection == 1)
                {
                    Console.WriteLine();
                    task.Name = NavigationTools.SelectString("Enter a Name: ");
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    task.Description = NavigationTools.SelectString("Enter a Description: ");
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
