using PracticeApp;
using System;

namespace PracticeAppCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoApp toDoApp = new ToDoApp();
            toDoApp.CreateDummyData();
            toDoApp.CreateEvenMoreDummyData(42);
            PracticeAppCLI appCLI = new PracticeAppCLI(toDoApp);
            appCLI.MainMenu();
        }
    }
}
