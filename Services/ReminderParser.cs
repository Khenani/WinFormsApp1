
using System;
using System.Text.RegularExpressions;

namespace WinFormsApp1.Services
{
    internal class ReminderParser
    {
        public static DateTime? ParseReminderDate(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return null;
            }

            string text = message.ToLower();

            // Recognise tomorrow
            if (text.Contains("tomorrow"))
            {
                return DateTime.Today.AddDays(1);
            }

            // Recognise today
            if (text.Contains("today"))
            {
                return DateTime.Today;
            }

            // Recognise phrases such as "in 3 days"
            Match match = Regex.Match(text, @"in\s+(\d+)\s+days?");

            if (match.Success)
            {
                int days = int.Parse(match.Groups[1].Value);
                return DateTime.Today.AddDays(days);
            }

            // Recognise dates such as 15/11/2026
            Match dateMatch = Regex.Match(
                text,
                @"\b\d{1,2}[/-]\d{1,2}[/-]\d{4}\b"
            );

            if (dateMatch.Success &&
                DateTime.TryParse(dateMatch.Value, out DateTime date))
            {
                return date;
            }

            // No reminder date found
            return null;
        }
    }
}

