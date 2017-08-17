using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VideoMenu
{
    class Program
    {
        private static bool isUserDone = false;
        private static List<Video> _videoList;
        private static Dictionary<int, string> _menuItems;

        static void Main(string[] args)
        {
            _menuItems = new Dictionary<int, string>();
            _videoList = new List<Video>();
            InitializeMenuItems();
            while (!isUserDone)
            {
                ShowMenu();
                int selection = GetSelection();
                ShowMenuItem(selection);
            }
        }

        private static void InitializeMenuItems()
        {
            _menuItems.Add(1, "Add new video");
            _menuItems.Add(2, "Show all videos");
            _menuItems.Add(3, "Edit a video");
            _menuItems.Add(4, "Delete a video");
        }


        private static void ShowMenuItem(int selection)
        {
            Console.WriteLine($"\n{selection}. {_menuItems[selection]}\n");
        }

        private static int GetSelection()
        {
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || !_menuItems.ContainsKey(selection))
            {
                Console.WriteLine("Please enter a valid number:");
            }
            return selection;
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Welcome to the video menu!\n" +
                              "Please select what you want to do:");
            foreach (var menuItem in _menuItems)
            {
                Console.WriteLine($"{menuItem.Key}. {menuItem.Value}");
            }
        }
    }
}