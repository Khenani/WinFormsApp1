
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1.Services
{
    internal static class ActivityLogger
    {
        private static List<string> activities = new List<string>();

        // Record an activity with its date and time
        public static void LogAction(string action)
        {
            string activity = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                              + " - " + action;

            activities.Add(activity);
        }

        // Retrieve the 10 most recent activities
        public static List<string> GetRecentActivities()
        {
            return activities
                .TakeLast(10)
                .Reverse()
                .ToList();
        }

        // Clear the activity history
        public static void ClearActivities()
        {
            activities.Clear();
        }
    }
}
