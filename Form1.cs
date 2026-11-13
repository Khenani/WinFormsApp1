
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WinFormsApp1.Data;
using WinFormsApp1.Models;
using WinFormsApp1.Services;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // CHATBOT MEMORY
        private string userName = "";
        private string favoriteTopic = "";
        private string lastTopic = "";

        private Dictionary<string, List<string>> topicTips;
        private List<string> worriedWords;
        private Random rand = new Random();

        // TASK ASSISTANT
        private TaskRepository taskRepository = new TaskRepository();
        private bool loadingTasks = false;

        // QUIZ
        private QuizServices quiz = new QuizServices();

        public Form1()
        {
            InitializeComponent();
            InitializeData();

            // Task Assistant events
            btnAddTask.Click -= btnAddTask_Click;
            btnAddTask.Click += btnAddTask_Click;

            btnDeleteTask.Click -= btnDeleteTask_Click;
            btnDeleteTask.Click += btnDeleteTask_Click;

            chkCompleted.CheckedChanged -= chkCompleted_CheckedChanged;
            chkCompleted.CheckedChanged += chkCompleted_CheckedChanged;

            // Quiz events
            btnSubmitQuiz.Click -= btnSubmitQuiz_Click;
            btnSubmitQuiz.Click += btnSubmitQuiz_Click;

            btnRestartQuiz.Click -= btnRestartQuiz_Click;
            btnRestartQuiz.Click += btnRestartQuiz_Click;

            // Activity Log event
            btnRefreshLog.Click -= btnRefreshLog_Click;
            btnRefreshLog.Click += btnRefreshLog_Click;

            this.Load += Form1_Load;
        }

  
        // CHATBOT DATA //
       

        private void InitializeData()
        {
            topicTips = new Dictionary<string, List<string>>()
            {
                {
                    "password",
                    new List<string>()
                    {
                        "Use a strong password with uppercase letters, lowercase letters, numbers and symbols.",
                        "Avoid using your name or birthday in your password."
                    }
                },
                {
                    "scam",
                    new List<string>()
                    {
                        "Be careful of messages promising prizes or asking for money.",
                        "Verify the sender before clicking links or sharing information."
                    }
                },
                {
                    "phishing",
                    new List<string>()
                    {
                        "Phishing messages try to trick you into sharing private information.",
                        "Check the sender's email address before opening links."
                    }
                },
                {
                    "privacy",
                    new List<string>()
                    {
                        "Avoid sharing personal information with unknown people online.",
                        "Review your social media privacy settings regularly."
                    }
                }
            };

            worriedWords = new List<string>()
            {
                "worried", "concerned", "anxious", "nervous",
                "scared", "afraid", "overwhelmed"
            };
        }

        
        // FORM LOAD //
       

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayGreeting();
            DisplayLogo();

            ChatInput.AppendText(
                "CyberSecureBot: Hello! Welcome to your Cybersecurity Awareness Assistant."
                + Environment.NewLine
                + "Ask me about passwords, scams, phishing and privacy."
                + Environment.NewLine
            );

            LoadTasks();
            StartQuiz();
            RefreshActivityLog();
        }

        // CHATBOT TAB //
        

        private void ProcessUserMessage()
        {
            string originalMessage = ChatInput2.Text.Trim();

            if (string.IsNullOrWhiteSpace(originalMessage))
                return;

            string message = originalMessage.ToLower();

            ChatInput.AppendText(
                "You: " + originalMessage + Environment.NewLine
            );

            
            if (HandleAdvancedCommands(originalMessage, message))
            {
                ChatInput2.Clear();
                ChatInput2.Focus();
                return;
            }

            string response = "";

            if (userName == "")
            {
                if (message.StartsWith("my name is "))
                {
                    userName = originalMessage.Substring(11).Trim();
                    response = "Nice to meet you, " + userName + "!";
                }
                else if (message.StartsWith("i am "))
                {
                    userName = originalMessage.Substring(5).Trim();
                    response = "Nice to meet you, " + userName + "!";
                }
                else if (!message.Contains("hello") &&
                         !message.Contains("hi") &&
                         !message.Contains("help"))
                {
                    userName = originalMessage;
                    response = "Nice to meet you, " + userName + "!";
                }
            }

            if (response == "" &&
                (message.Contains("my favourite topic is") ||
                 message.Contains("my favorite topic is")))
            {
                favoriteTopic = message
                    .Replace("my favourite topic is", "")
                    .Replace("my favorite topic is", "")
                    .Trim();

                response = "I will remember your favourite topic is "
                    + favoriteTopic + ".";
            }

            else if (response == "" &&
                     (message.Contains("another tip") ||
                      message.Contains("tell me more") ||
                      message.Contains("explain more")))
            {
                if (lastTopic != "" && topicTips.ContainsKey(lastTopic))
                {
                    List<string> tips = topicTips[lastTopic];
                    response = tips[rand.Next(tips.Count)];
                }
                else
                {
                    response = "Please ask about passwords, scams, phishing or privacy.";
                }
            }

            else if (response == "" && ContainsWorriedWord(message))
            {
                response = "It is understandable to feel concerned about online safety. "
                    + "Take your time, avoid suspicious links and ask for help when unsure.";
            }

            else if (response == "")
            {
                foreach (string topic in topicTips.Keys)
                {
                    if (message.Contains(topic))
                    {
                        lastTopic = topic;
                        List<string> tips = topicTips[topic];
                        response = tips[rand.Next(tips.Count)];
                        break;
                    }
                }
            }

            if (response == "")
            {
                if (message.Contains("hello") || message.Contains("hi"))
                {
                    response = "Hello! How can I help you stay safe online?";
                }
                else if (message.Contains("help"))
                {
                    response = "Ask me about passwords, scams, phishing or privacy.";
                }
                else
                {
                    response = "I am still learning. Try asking about passwords, scams, phishing or privacy.";
                }
            }

            ChatInput.AppendText(
                "CyberSecureBot: " + response
                + Environment.NewLine + Environment.NewLine
            );

            ChatInput2.Clear();
            ChatInput2.Focus();

            ActivityLogger.LogAction(
            "NLP processed a user message: " + message
);

            RefreshActivityLog();
        }

        private bool ContainsWorriedWord(string message)
        {
            foreach (string word in worriedWords)
            {
                if (message.Contains(word))
                    return true;
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessUserMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessUserMessage();
        }

        private void ChatInput2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessUserMessage();
            }
        }

       
        // TASK ASSISTANT TAB //
      

        private void LoadTasks()
        {
            try
            {
                loadingTasks = true;

                dgvTasks.DataSource = null;
                dgvTasks.DataSource = taskRepository.GetAllTasks();

                if (dgvTasks.Columns["Id"] != null)
                    dgvTasks.Columns["Id"].Visible = false;

                if (dgvTasks.Columns["CreatedAt"] != null)
                    dgvTasks.Columns["CreatedAt"].Visible = false;

                if (dgvTasks.Columns["Title"] != null)
                    dgvTasks.Columns["Title"].HeaderText = "Task";

                if (dgvTasks.Columns["Description"] != null)
                    dgvTasks.Columns["Description"].HeaderText = "Description";

                if (dgvTasks.Columns["ReminderDate"] != null)
                    dgvTasks.Columns["ReminderDate"].HeaderText = "Reminder";

                if (dgvTasks.Columns["IsCompleted"] != null)
                    dgvTasks.Columns["IsCompleted"].HeaderText = "Completed";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load tasks. Check your database connection."
                    + Environment.NewLine + ex.Message
                );
            }
            finally
            {
                loadingTasks = false;
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (title == "")
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            try
            {
                DateTime? reminder = dtpReminder.Checked
                    ? dtpReminder.Value
                    : (DateTime?)null;

                taskRepository.AddTask(title, description, reminder);

                ActivityLogger.LogAction("Added task: " + title);

                MessageBox.Show("Task added successfully!");

                txtTaskTitle.Clear();
                txtDescription.Clear();

                LoadTasks();
                RefreshActivityLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add task: " + ex.Message);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this task?",
                "Confirm deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                int taskId = Convert.ToInt32(
                    dgvTasks.CurrentRow.Cells["Id"].Value
                );

                taskRepository.DeleteTask(taskId);

                ActivityLogger.LogAction("Deleted task ID: " + taskId);

                LoadTasks();
                RefreshActivityLog();

                MessageBox.Show("Task deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete task: " + ex.Message);
            }
        }

        private void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingTasks || dgvTasks.CurrentRow == null)
                return;

            try
            {
                int taskId = Convert.ToInt32(
                    dgvTasks.CurrentRow.Cells["Id"].Value
                );

                taskRepository.UpdateTaskStatus(
                    taskId,
                    chkCompleted.Checked
                );

                ActivityLogger.LogAction(
                    "Updated completion status for task ID: " + taskId
                );

                LoadTasks();
                RefreshActivityLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update task: " + ex.Message);
            }
        }

       
        // QUIZ TAB //
        

        private void StartQuiz()
        {
            quiz.RestartQuiz();

            lblQuizFeedback.Text = "";
            QuizBox.Items.Clear();

            btnSubmitQuiz.Enabled = true;

            DisplayQuestion();

            ActivityLogger.LogAction("Started the cybersecurity quiz.");
        }

        private void DisplayQuestion()
        {
            QuizBox.Items.Clear();

            QuizQuestion question = quiz.GetCurrentQuestion();

            if (question == null)
            {
                lblQuizProgress.Text = "Quiz completed!";
                lblQuizQuestion.Text = "You have completed the quiz.";

                btnSubmitQuiz.Enabled = false;

                int score = quiz.Score;
                int total = quiz.TotalQuestions;

                string feedback;

                if (score >= 10)
                {
                    feedback = "Excellent work! You have a strong understanding of cybersecurity.";
                }
                else if (score >= 6)
                {
                    feedback = "Good effort! Review the explanations to strengthen your knowledge.";
                }
                else
                {
                    feedback = "Keep practising! Review the cybersecurity tips and try again.";
                }

                lblQuizFeedback.Text =
                    "Final score: " + score + " / " + total
                    + Environment.NewLine + feedback;

                MessageBox.Show(
                    "Quiz completed!" + Environment.NewLine
                    + "Your score: " + score + " / " + total
                    + Environment.NewLine + feedback,
                    "Quiz Results"
                );

                ActivityLogger.LogAction(
                    "Completed quiz. Final score: " + score + "/" + total
                );

                RefreshActivityLog();
                return;
            }

            lblQuizProgress.Text =
                "Question " + (quiz.CurrentQuestionIndex + 1)
                + " of " + quiz.TotalQuestions;

            lblQuizQuestion.Text = question.Question;

            foreach (string option in question.Options)
            {
                QuizBox.Items.Add(option);
            }
        }

        private void btnSubmitQuiz_Click(object sender, EventArgs e)
        {
            if (QuizBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an answer first.");
                return;
            }

            QuizQuestion question = quiz.GetCurrentQuestion();

            if (question == null)
                return;

            bool correct = quiz.SubmitAnswer(QuizBox.SelectedIndex);

            string result;

            if (correct)
            {
                result = "Correct!";
            }
            else
            {
                result = "Incorrect. The correct answer is: "
                    + question.Options[question.CorrectAnswerIndex];
            }

            MessageBox.Show(
                result + Environment.NewLine + Environment.NewLine
                + "Explanation: " + question.Explanation,
                "Quiz Feedback"
            );

            lblQuizFeedback.Text = result;

            ActivityLogger.LogAction(
                correct
                ? "Answered a quiz question correctly."
                : "Answered a quiz question incorrectly."
            );

            DisplayQuestion();
            RefreshActivityLog();
        }

        private void btnRestartQuiz_Click(object sender, EventArgs e)
        {
            StartQuiz();
            MessageBox.Show("The quiz has been restarted.");
        }

        
        // ACTIVITY LOG TAB //


        private void RefreshActivityLog()
        {
            lstActivityLog.Items.Clear();

            List<string> activities =
                ActivityLogger.GetRecentActivities();

            if (activities.Count == 0)
            {
                lstActivityLog.Items.Add("No activities recorded yet.");
                return;
            }

            foreach (string activity in activities)
            {
                lstActivityLog.Items.Add(activity);
            }
        }

        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            RefreshActivityLog();
        }



       
        //NLP COMMAND RECOGNITION //

        private bool HandleAdvancedCommands(string originalMessage, string message)
        {
            // 1. ACTIVITY LOG COMMAND
            if (message.Contains("show activity log") ||
                message.Contains("what have you done for me") ||
                message.Contains("show my activities") ||
                message.Contains("recent actions") ||
                message.Contains("activity history"))
            {
                ActivityLogger.LogAction(
                    "NLP recognised an activity log request."
                );

                RefreshActivityLog();

                tabMain.SelectedTab = tabLog;

                ChatInput.AppendText(
                    "CyberSecureBot: Here is a summary of your recent activities:"
                    + Environment.NewLine
                );

                foreach (string activity in ActivityLogger.GetRecentActivities())
                {
                    ChatInput.AppendText(
                        "- " + activity + Environment.NewLine
                    );
                }

                ChatInput.AppendText(Environment.NewLine);

                return true;
            }

            // 2. QUIZ COMMAND
            if (message.Contains("start quiz") ||
                message.Contains("take a quiz") ||
                message.Contains("cybersecurity quiz") ||
                message.Contains("play quiz"))
            {
                tabMain.SelectedTab = tabQuiz;

                StartQuiz();

                ActivityLogger.LogAction(
                    "NLP recognised a request to start the cybersecurity quiz."
                );

                ChatInput.AppendText(
                    "CyberSecureBot: Let's test your cybersecurity knowledge! "
                    + "The quiz is ready in the Quiz tab."
                    + Environment.NewLine + Environment.NewLine
                );

                RefreshActivityLog();

                return true;
            }

            // 3. TASK AND REMINDER COMMANDS

            string taskTitle = "";

            Match reminderMatch = Regex.Match(
                originalMessage,
                @"^\s*(?:please\s+)?remind\s+me\s+to\s+(.+)$",
                RegexOptions.IgnoreCase
            );

            Match taskMatch = Regex.Match(
                originalMessage,
                @"^\s*(?:please\s+)?(?:add|create)\s+(?:a\s+)?task(?:\s*[-:]\s*|\s+to\s+|\s+)(.+)$",
                RegexOptions.IgnoreCase
            );

            if (reminderMatch.Success)
            {
                taskTitle = reminderMatch.Groups[1].Value.Trim();
            }
            else if (taskMatch.Success)
            {
                taskTitle = taskMatch.Groups[1].Value.Trim();
            }

            if (taskTitle != "")
            {
                DateTime? reminderDate = ExtractReminderDate(ref taskTitle);

                taskTitle = taskTitle.Trim(' ', '.', ',', '-', ':');

                if (taskTitle == "")
                {
                    ChatInput.AppendText(
                        "CyberSecureBot: Please tell me what cybersecurity task you want to add."
                        + Environment.NewLine + Environment.NewLine
                    );

                    return true;
                }

                try
                {
                    string description =
                        "Cybersecurity task: " + taskTitle;

                    taskRepository.AddTask(
                        taskTitle,
                        description,
                        reminderDate
                    );

                    ActivityLogger.LogAction(
                        "NLP recognised and added task: " + taskTitle
                    );

                    if (reminderDate.HasValue)
                    {
                        ActivityLogger.LogAction(
                            "Reminder set for " + taskTitle
                            + " on " + reminderDate.Value.ToString("dd/MM/yyyy")
                        );

                        ChatInput.AppendText(
                            "CyberSecureBot: Your task '" + taskTitle
                            + "' has been added successfully. "
                            + "Your reminder is set for "
                            + reminderDate.Value.ToString("dd/MM/yyyy") + "."
                            + Environment.NewLine + Environment.NewLine
                        );
                    }
                    else
                    {
                        ChatInput.AppendText(
                            "CyberSecureBot: Your task '" + taskTitle
                            + "' has been added successfully. "
                            + "You can set a reminder using the Task Assistant tab."
                            + Environment.NewLine + Environment.NewLine
                        );
                    }

                    LoadTasks();
                    RefreshActivityLog();
                }
                catch (Exception ex)
                {
                    ChatInput.AppendText(
                        "CyberSecureBot: I could not save your task. "
                        + ex.Message + Environment.NewLine
                    );
                }

                return true;
            }

            return false;
        }

      
        // EXTRACT REMINDER DATE //

        private DateTime? ExtractReminderDate(ref string taskTitle)
        {
            DateTime? reminder = null;

            Match daysMatch = Regex.Match(
                taskTitle,
                @"\bin\s+(\d+)\s+days?\b",
                RegexOptions.IgnoreCase
            );

            if (daysMatch.Success)
            {
                int days = int.Parse(daysMatch.Groups[1].Value);

                reminder = DateTime.Today.AddDays(days);

                taskTitle = Regex.Replace(
                    taskTitle,
                    @"\bin\s+\d+\s+days?\b",
                    "",
                    RegexOptions.IgnoreCase
                );
            }
            else if (Regex.IsMatch(taskTitle, @"\btomorrow\b",
                RegexOptions.IgnoreCase))
            {
                reminder = DateTime.Today.AddDays(1);

                taskTitle = Regex.Replace(
                    taskTitle,
                    @"\btomorrow\b",
                    "",
                    RegexOptions.IgnoreCase
                );
            }
            else if (Regex.IsMatch(taskTitle, @"\btoday\b",
                RegexOptions.IgnoreCase))
            {
                reminder = DateTime.Today;

                taskTitle = Regex.Replace(
                    taskTitle,
                    @"\btoday\b",
                    "",
                    RegexOptions.IgnoreCase
                );
            }
            else if (Regex.IsMatch(taskTitle, @"\bnext week\b",
                RegexOptions.IgnoreCase))
            {
                reminder = DateTime.Today.AddDays(7);

                taskTitle = Regex.Replace(
                    taskTitle,
                    @"\bnext week\b",
                    "",
                    RegexOptions.IgnoreCase
                );
            }

            // Remove extra reminder wording
            taskTitle = Regex.Replace(
                taskTitle,
                @"\b(remind me|set a reminder|with a reminder)\b",
                "",
                RegexOptions.IgnoreCase
            );

            return reminder;
        }


       
        // SOUND AND LOGO //
       

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player =
                    new SoundPlayer("voice/greetings.wav");

                player.Play();
            }
            catch
            {
                
            }
        }

        private void DisplayLogo()
        {
            try
            {
                pictureBox1.Image = Image.FromFile("images/logo.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
        
            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void ChatInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void ChatInput2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ProcessUserMessage();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
