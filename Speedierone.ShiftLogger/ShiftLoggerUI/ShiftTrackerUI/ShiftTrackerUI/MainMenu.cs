﻿namespace ShiftTrackerUI
{
    internal class MainMenu
    {
        internal static async Task ShowMenu()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {              
                Console.WriteLine("Welcome to the Shift Tracker app. Please choose from the following options");
                Console.WriteLine("Type 0 to exit programme");
                Console.WriteLine("Press 1 to view current recorded shifts");
                Console.WriteLine("Press 2 to add new shift");
                Console.WriteLine("Press 3 to delete shift");
                Console.WriteLine("Press 4 to modify recorded shift");

                var command = Console.ReadLine();

                switch(command)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        await ShiftService.GetShifts();
                        Console.Clear();
                        break;
                    case "2":
                        await UserInput.AddShift();
                        break;
                    case "3":
                        await UserInput.DeleteShift();
                        break;
                    case "4":
                        await UserInput.PutShift();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
