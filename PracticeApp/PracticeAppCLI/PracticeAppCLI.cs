using System;

namespace PracticeAppCLI
{
    class PracticeAppCLI
    {
        public void MainMenu()
        {
            bool mainMenuIsRunning = true;

            while (mainMenuIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Practice ToDo Console App");
                Console.WriteLine();
                Console.WriteLine("[1] View your ToDo Lists");
                Console.WriteLine("[2] Add a new ToDo List");
                Console.WriteLine("[3] Make changes to your ToDo List");
                Console.WriteLine("[4] ");

                int selection = NavigationTools.SelectSingleIntOption(1, 4);
                if(selection == 1)
                {

                }
                else if(selection == 2)
                {

                }
                else if(selection == 3)
                {

                }
                else if(selection == 4)
                {

                }
            }
        }
    }
}
