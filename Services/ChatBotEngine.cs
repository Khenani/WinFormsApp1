
using System;

namespace WinFormsApp1.Services
{
    internal class ChatBotEngine
    {
        public string ProcessMessage(string message)
        {
            string intent = NlpServices.RecognizeIntent(message);

            switch (intent)
            {
                case "reminder":
                    DateTime? reminderDate =
                        ReminderParser.ParseReminderDate(message);

                    if (reminderDate.HasValue)
                    {
                        ActivityLogger.LogAction(
                            "Reminder request recognised: " + message);

                        return "I recognised your reminder for " +
                               reminderDate.Value.ToString("dd/MM/yyyy") +
                               ". Let's add it to your task list.";
                    }

                    return "I recognised that you want a reminder. " +
                           "Please include a date, such as tomorrow or in 3 days.";

                case "task":
                    ActivityLogger.LogAction("Task request recognised: " + message);
                    return "I understand that you want to manage a task. " +
                           "Please use the Task Assistant tab.";

                case "quiz":
                    ActivityLogger.LogAction("Quiz request recognised.");
                    return "Let's test your cybersecurity knowledge! " +
                           "Open the Quiz tab to begin.";

                case "activity":
                    return "You can view your recent activities in the Activity Log tab.";

                case "password":
                    return "Use a long, unique password with a combination of characters. " +
                           "Consider using a password manager and enable two-factor authentication.";

                case "phishing":
                    return "Be careful with suspicious links and attachments. " +
                           "Check the sender, avoid sharing personal information, and report suspicious messages.";

                case "cybersecurity":
                    return "Cybersecurity means protecting devices, networks and personal information " +
                           "from digital threats.";

                default:
                    return "I'm not sure I understand. You can ask me about passwords, " +
                           "phishing, reminders, tasks or the cybersecurity quiz.";
            }
        }
    }
}
