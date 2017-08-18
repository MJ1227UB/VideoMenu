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
            _menuItems.Add(5, "Search video's");
            _menuItems.Add(0, "Exit");
        }


        private static void ShowMenuItem(int selection)
        {
            Console.Clear();
            Console.WriteLine($"You chose:\n{selection}. {_menuItems[selection]}\n");
            switch (selection)
            {
                case 1:
                    AddVideo();
                    break;
                case 2:
                    ShowVideos();
                    break;
                case 3:
                    EditVideo();
                    break;
                case 4:
                    DeleteVideo();
                    break;
                case 5:
                    SearchVideo();
                    break;
                case 0:
                    Exit();
                    break;
            }
            if (!isUserDone)
            {
                Console.WriteLine("Press Enter to go back!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void SearchVideo()
        {
            Console.WriteLine("Enter text to search:");
            string searchText = Console.ReadLine();
            ShowVideos(searchText);
        }

        private static void DeleteVideo()
        {
            ShowVideos();
            if (_videoList.Count != 0)
            {
                Console.WriteLine("Enter the number of the video you want to delete:");
                int selection = GetSelection() - 1;
                Console.WriteLine($"You chose: {_videoList[selection].Name}\nIt has been deleted");
                _videoList.RemoveAt(selection);
            }
        }

        private static void EditVideo()
        {
            ShowVideos();
            if (_videoList.Count != 0)
            {
                Console.WriteLine("Enter the number of the video you want to rename:");
                int selection = GetSelection() - 1;
                Console.WriteLine($"You chose: {_videoList[selection].Name}\nEnter the new name for the video:");
                var newName = Console.ReadLine();
                _videoList[selection].Name = newName;
                Console.WriteLine("\nThe name has been altered!\n");
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Bye bye! :)\nPress Enter to exit!");
            isUserDone = true;
            Console.ReadLine();
        }

        private static void AddVideo()
        {
            Console.WriteLine("Please enter the name for the new video:\n");
            var name = Console.ReadLine();
            var newVideo = new Video {Name = name};
            _videoList.Add(newVideo);
            Console.WriteLine("\nThe video has been added!");
        }

        private static void ShowVideos()
        {
            if (_videoList.Count == 0)
            {
                Console.WriteLine("There are no videos");
            }
            else
            {
                for (int i = 0; i < _videoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {_videoList[i].Name}");
                }
            }
            Console.WriteLine("");
        }

        private static void ShowVideos(string searchText)
        {
            if (_videoList.Count == 0)
            {
                Console.WriteLine("There are no videos");
            }
            else
            {
                for (int i = 0; i < _videoList.Count; i++)
                {
                    if (_videoList[i].Name.ToLower().Contains(searchText.ToLower()))
                    {
                        Console.WriteLine($"{i + 1} - {_videoList[i].Name}");
                    }
                }
            }
            Console.WriteLine("");
        }

        private static int GetSelection()
        {
            Console.WriteLine("");
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
                              "Please enter the number of the menu item:\n");
            foreach (var menuItem in _menuItems)
            {
                Console.WriteLine($"{menuItem.Key}. {menuItem.Value}");
            }
        }
    }
}