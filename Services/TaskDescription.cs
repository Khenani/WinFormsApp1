
using System;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    internal static class TaskDescription
    {
        public static string FormatTask(TaskItem task)
        {
            if (task == null)
                return "No task information available.";

            string status = task.IsCompleted ? "Completed" : "Pending";

            string reminder = task.ReminderDate.HasValue
                ? task.ReminderDate.Value.ToString("dd/MM/yyyy HH:mm")
                : "No reminder set";

            return
                "Task: " + task.Title + Environment.NewLine +
                "Description: " + task.Description + Environment.NewLine +
                "Status: " + status + Environment.NewLine +
                "Reminder: " + reminder;
        }

        public static string GetTaskStatus(TaskItem task)
        {
            if (task == null)
                return "Unknown";

            return task.IsCompleted ? "Completed" : "Pending";
        }
    }
}
