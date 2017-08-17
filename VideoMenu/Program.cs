using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VideoMenu
{
    class Program
    {
        private static bool isUserDone = false;
        private static List<Video> VideoList;
        private static Dictionary<int, string> MenuItems;
        static void Main(string[] args)
        {
            while (!isUserDone)
            {
                ShowMenu();
                int selection = GetSelection();
                ShowMenuItem(selection);
            }
        }


        private static void ShowMenuItem(int selection)
        {
            switch (MenuItems)
            {
                    
            }
        }

        private static int GetSelection()
        {
            int selection;
            while (int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Please enter a number:");
            }
            return selection;
        }

        private static void ShowMenu()
        {
            while (!isUserDone)
            {
                Console.WriteLine("Welcome to the video menu!\n" +
                                  "Please select what you want to do:");
            }
            
        }
    }
}