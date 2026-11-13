
using System;
using System.Collections.Generic;
using MySqlConnector;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data
{
    public class TaskRepository
    {
        // Add a new task to the database
        public void AddTask(string title, string description, DateTime? reminder)
        {
            using (var conn = new MySqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();

                string query = @"INSERT INTO tasks
                    (title, description, reminder_date)
                    VALUES (@title, @description, @reminder)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);

                    cmd.Parameters.AddWithValue(
                        "@reminder",
                        reminder.HasValue
                            ? (object)reminder.Value
                            : DBNull.Value
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Retrieve all tasks from the database
        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (var conn = new MySqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();

                string query = "SELECT * FROM tasks ORDER BY created_at DESC";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Title = reader["title"].ToString() ?? "",
                            Description = reader["description"].ToString() ?? "",

                            ReminderDate = reader["reminder_date"] != DBNull.Value
                                ? Convert.ToDateTime(reader["reminder_date"])
                                : (DateTime?)null,

                            IsCompleted = Convert.ToBoolean(reader["is_completed"]),
                            CreatedAt = Convert.ToDateTime(reader["created_at"])
                        });
                    }
                }
            }

            return tasks;
        }

        // Delete a selected task
        public void DeleteTask(int taskId)
        {
            using (var conn = new MySqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();

                string query = "DELETE FROM tasks WHERE id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Mark a task as completed or incomplete
        public void UpdateTaskStatus(int taskId, bool isCompleted)
        {
            using (var conn = new MySqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();

                string query = @"UPDATE tasks
                                 SET is_completed = @completed
                                 WHERE id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@completed", isCompleted);
                    cmd.Parameters.AddWithValue("@id", taskId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
