
using System;

namespace WinFormsApp1.Services
{
    internal static class NlpServices
    {
        public static string RecognizeIntent(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return "unknown";

            string text = message.ToLower().Trim();

            // Reminder commands
            if (ContainsAny(text, "remind me", "reminder", "remind", "notify me"))
                return "reminder";

            // Task commands
            if (ContainsAny(text, "add task", "create task", "new task",
                "show tasks", "view tasks", "delete task", "complete task",
                "mark as completed"))
                return "task";

            // Quiz commands
            if (ContainsAny(text, "quiz", "test my knowledge",
                "start test", "cybersecurity questions"))
                return "quiz";

            // Activity log commands
            if (ContainsAny(text, "activity log", "what have you done",
                "show activity", "your activities"))
                return "activity";

            // Password security
            if (ContainsAny(text, "password", "strong password",
                "weak password", "password safety"))
                return "password";

            // Phishing and scams
            if (ContainsAny(text, "phishing", "scam", "fraud",
                "suspicious email", "fake link"))
                return "phishing";

            // General cybersecurity topics
            if (ContainsAny(text, "cybersecurity", "online safety",
                "internet safety", "privacy", "hacking"))
                return "cybersecurity";

            return "unknown";
        }

        private static bool ContainsAny(string text, params string[] keywords)
        {
            foreach (string keyword in keywords)
            {
                if (text.Contains(keyword))
                    return true;
            }

            return false;
        }
    }
}
