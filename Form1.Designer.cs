
namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabMain = new TabControl();
            tabChat = new TabPage();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ChatInput2 = new TextBox();
            ChatInput = new TextBox();
            tabTasks = new TabPage();
            lblTaskTitle = new Label();
            txtTaskTitle = new TextBox();
            lblDescroption = new Label();
            txtDescription = new TextBox();
            dtpReminder = new DateTimePicker();
            chkCompleted = new CheckBox();
            btnAddTask = new Button();
            btnDeleteTask = new Button();
            dgvTasks = new DataGridView();
            taskHeading = new Label();
            taskSubtitle = new Label();
            reminderLabel = new Label();
            listHeading = new Label();
            tabQuiz = new TabPage();
            quizHeading = new Label();
            lblQuizProgress = new Label();
            lblQuizQuestion = new Label();
            QuizBox = new ListBox();
            lblQuizFeedback = new Label();
            btnSubmitQuiz = new Button();
            btnRestartQuiz = new Button();
            tabLog = new TabPage();
            lblLogHeader = new Label();
            lstActivityLog = new ListBox();
            btnRefreshLog = new Button();
            tabMain.SuspendLayout();
            tabChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            tabQuiz.SuspendLayout();
            tabLog.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabChat);
            tabMain.Controls.Add(tabTasks);
            tabMain.Controls.Add(tabQuiz);
            tabMain.Controls.Add(tabLog);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1097, 857);
            tabMain.TabIndex = 0;
            // 
            // tabChat
            // 
            tabChat.BackColor = Color.FromArgb(245, 248, 252);
            tabChat.BackgroundImage = (Image)resources.GetObject("tabChat.BackgroundImage");
            tabChat.Controls.Add(pictureBox1);
            tabChat.Controls.Add(button3);
            tabChat.Controls.Add(ChatInput2);
            tabChat.Controls.Add(ChatInput);
            tabChat.Location = new Point(4, 32);
            tabChat.Name = "tabChat";
            tabChat.Size = new Size(1089, 821);
            tabChat.TabIndex = 0;
            tabChat.Text = "Chat";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(25, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(420, 420);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(920, 708);
            button3.Name = "button3";
            button3.Size = new Size(125, 40);
            button3.TabIndex = 1;
            button3.Text = "Send";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // ChatInput2
            // 
            ChatInput2.BackColor = Color.White;
            ChatInput2.Font = new Font("Segoe UI", 10F);
            ChatInput2.Location = new Point(475, 710);
            ChatInput2.Name = "ChatInput2";
            ChatInput2.Size = new Size(430, 30);
            ChatInput2.TabIndex = 2;
            ChatInput2.TextChanged += ChatInput2_TextChanged;
            // 
            // ChatInput
            // 
            ChatInput.BackColor = Color.White;
            ChatInput.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ChatInput.Location = new Point(475, 55);
            ChatInput.Multiline = true;
            ChatInput.Name = "ChatInput";
            ChatInput.ReadOnly = true;
            ChatInput.ScrollBars = ScrollBars.Vertical;
            ChatInput.Size = new Size(570, 630);
            ChatInput.TabIndex = 3;
            // 
            // tabTasks
            // 
            tabTasks.BackColor = Color.FromArgb(245, 248, 250);
            tabTasks.Controls.Add(lblTaskTitle);
            tabTasks.Controls.Add(txtTaskTitle);
            tabTasks.Controls.Add(lblDescroption);
            tabTasks.Controls.Add(txtDescription);
            tabTasks.Controls.Add(dtpReminder);
            tabTasks.Controls.Add(chkCompleted);
            tabTasks.Controls.Add(btnAddTask);
            tabTasks.Controls.Add(btnDeleteTask);
            tabTasks.Controls.Add(dgvTasks);
            tabTasks.Controls.Add(taskHeading);
            tabTasks.Controls.Add(taskSubtitle);
            tabTasks.Controls.Add(reminderLabel);
            tabTasks.Controls.Add(listHeading);
            tabTasks.Location = new Point(4, 32);
            tabTasks.Name = "tabTasks";
            tabTasks.Size = new Size(1089, 821);
            tabTasks.TabIndex = 1;
            tabTasks.Text = "Task Assistant";
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTaskTitle.Location = new Point(45, 125);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(86, 23);
            lblTaskTitle.TabIndex = 0;
            lblTaskTitle.Text = "Task Title";
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Font = new Font("Segoe UI", 10F);
            txtTaskTitle.Location = new Point(45, 153);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(970, 30);
            txtTaskTitle.TabIndex = 1;
            // 
            // lblDescroption
            // 
            lblDescroption.AutoSize = true;
            lblDescroption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescroption.Location = new Point(45, 205);
            lblDescroption.Name = "lblDescroption";
            lblDescroption.Size = new Size(102, 23);
            lblDescroption.TabIndex = 2;
            lblDescroption.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(45, 233);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(970, 85);
            txtDescription.TabIndex = 3;
            // 
            // dtpReminder
            // 
            dtpReminder.Checked = false;
            dtpReminder.CustomFormat = "dd MMMM yyyy";
            dtpReminder.Format = DateTimePickerFormat.Custom;
            dtpReminder.Location = new Point(45, 375);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.ShowCheckBox = true;
            dtpReminder.Size = new Size(270, 30);
            dtpReminder.TabIndex = 4;
            // 
            // chkCompleted
            // 
            chkCompleted.AutoSize = true;
            chkCompleted.Font = new Font("Segoe UI", 10F);
            chkCompleted.Location = new Point(345, 380);
            chkCompleted.Name = "chkCompleted";
            chkCompleted.Size = new Size(177, 27);
            chkCompleted.TabIndex = 5;
            chkCompleted.Text = "Mark as completed";
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.FromArgb(35, 145, 130);
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(750, 372);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(125, 42);
            btnAddTask.TabIndex = 6;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.BackColor = Color.FromArgb(190, 75, 75);
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.ForeColor = Color.White;
            btnDeleteTask.Location = new Point(890, 372);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(125, 42);
            btnDeleteTask.TabIndex = 7;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = false;
            // 
            // dgvTasks
            // 
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AllowUserToDeleteRows = false;
            dgvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.BackgroundColor = Color.White;
            dgvTasks.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.SteelBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTasks.ColumnHeadersHeight = 29;
            dgvTasks.EnableHeadersVisualStyles = false;
            dgvTasks.Location = new Point(45, 485);
            dgvTasks.MultiSelect = false;
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.RowHeadersWidth = 51;
            dgvTasks.RowTemplate.Height = 35;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.Size = new Size(1867, 1037);
            dgvTasks.TabIndex = 8;
            // 
            // taskHeading
            // 
            taskHeading.AutoSize = true;
            taskHeading.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            taskHeading.ForeColor = Color.FromArgb(35, 65, 85);
            taskHeading.Location = new Point(45, 25);
            taskHeading.Name = "taskHeading";
            taskHeading.Size = new Size(263, 50);
            taskHeading.TabIndex = 9;
            taskHeading.Text = "Task Assistant";
            // 
            // taskSubtitle
            // 
            taskSubtitle.AutoSize = true;
            taskSubtitle.Font = new Font("Segoe UI", 10F);
            taskSubtitle.ForeColor = Color.Gray;
            taskSubtitle.Location = new Point(48, 70);
            taskSubtitle.Name = "taskSubtitle";
            taskSubtitle.Size = new Size(417, 23);
            taskSubtitle.TabIndex = 10;
            taskSubtitle.Text = "Create and manage your cybersecurity learning tasks.";
            // 
            // reminderLabel
            // 
            reminderLabel.AutoSize = true;
            reminderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            reminderLabel.Location = new Point(45, 345);
            reminderLabel.Name = "reminderLabel";
            reminderLabel.Size = new Size(131, 23);
            reminderLabel.TabIndex = 11;
            reminderLabel.Text = "Reminder Date";
            // 
            // listHeading
            // 
            listHeading.AutoSize = true;
            listHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            listHeading.ForeColor = Color.FromArgb(35, 65, 85);
            listHeading.Location = new Point(45, 445);
            listHeading.Name = "listHeading";
            listHeading.Size = new Size(134, 32);
            listHeading.TabIndex = 12;
            listHeading.Text = "Your Tasks";
            // 
            // tabQuiz
            // 
            tabQuiz.BackColor = Color.FromArgb(245, 248, 252);
            tabQuiz.Controls.Add(quizHeading);
            tabQuiz.Controls.Add(lblQuizProgress);
            tabQuiz.Controls.Add(lblQuizQuestion);
            tabQuiz.Controls.Add(QuizBox);
            tabQuiz.Controls.Add(lblQuizFeedback);
            tabQuiz.Controls.Add(btnSubmitQuiz);
            tabQuiz.Controls.Add(btnRestartQuiz);
            tabQuiz.Location = new Point(4, 32);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Size = new Size(1089, 821);
            tabQuiz.TabIndex = 2;
            tabQuiz.Text = "Quiz";
            // 
            // quizHeading
            // 
            quizHeading.AutoSize = true;
            quizHeading.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            quizHeading.ForeColor = Color.FromArgb(35, 65, 85);
            quizHeading.Location = new Point(55, 30);
            quizHeading.Name = "quizHeading";
            quizHeading.Size = new Size(542, 50);
            quizHeading.TabIndex = 0;
            quizHeading.Text = "Cybersecurity Awareness Quiz";
            // 
            // lblQuizProgress
            // 
            lblQuizProgress.AutoSize = true;
            lblQuizProgress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuizProgress.ForeColor = Color.SteelBlue;
            lblQuizProgress.Location = new Point(65, 100);
            lblQuizProgress.Name = "lblQuizProgress";
            lblQuizProgress.Size = new Size(143, 23);
            lblQuizProgress.TabIndex = 1;
            lblQuizProgress.Text = "Question 1 of 12";
            // 
            // lblQuizQuestion
            // 
            lblQuizQuestion.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblQuizQuestion.Location = new Point(65, 155);
            lblQuizQuestion.Name = "lblQuizQuestion";
            lblQuizQuestion.Size = new Size(900, 65);
            lblQuizQuestion.TabIndex = 2;
            lblQuizQuestion.Text = "Your question will appear here.";
            // 
            // QuizBox
            // 
            QuizBox.Font = new Font("Segoe UI", 11F);
            QuizBox.IntegralHeight = false;
            QuizBox.ItemHeight = 25;
            QuizBox.Location = new Point(65, 240);
            QuizBox.Name = "QuizBox";
            QuizBox.Size = new Size(900, 170);
            QuizBox.TabIndex = 3;
            // 
            // lblQuizFeedback
            // 
            lblQuizFeedback.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblQuizFeedback.Location = new Point(65, 430);
            lblQuizFeedback.Name = "lblQuizFeedback";
            lblQuizFeedback.Size = new Size(900, 65);
            lblQuizFeedback.TabIndex = 4;
            // 
            // btnSubmitQuiz
            // 
            btnSubmitQuiz.BackColor = Color.SteelBlue;
            btnSubmitQuiz.FlatStyle = FlatStyle.Flat;
            btnSubmitQuiz.ForeColor = Color.White;
            btnSubmitQuiz.Location = new Point(65, 520);
            btnSubmitQuiz.Name = "btnSubmitQuiz";
            btnSubmitQuiz.Size = new Size(160, 42);
            btnSubmitQuiz.TabIndex = 5;
            btnSubmitQuiz.Text = "Submit Answer";
            btnSubmitQuiz.UseVisualStyleBackColor = false;
            // 
            // btnRestartQuiz
            // 
            btnRestartQuiz.BackColor = Color.FromArgb(35, 145, 130);
            btnRestartQuiz.FlatStyle = FlatStyle.Flat;
            btnRestartQuiz.ForeColor = Color.White;
            btnRestartQuiz.Location = new Point(245, 520);
            btnRestartQuiz.Name = "btnRestartQuiz";
            btnRestartQuiz.Size = new Size(150, 42);
            btnRestartQuiz.TabIndex = 6;
            btnRestartQuiz.Text = "Restart Quiz";
            btnRestartQuiz.UseVisualStyleBackColor = false;
            // 
            // tabLog
            // 
            tabLog.BackColor = Color.FromArgb(245, 248, 252);
            tabLog.Controls.Add(lblLogHeader);
            tabLog.Controls.Add(lstActivityLog);
            tabLog.Controls.Add(btnRefreshLog);
            tabLog.Location = new Point(4, 32);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(1089, 821);
            tabLog.TabIndex = 3;
            tabLog.Text = "Activity Log";
            // 
            // lblLogHeader
            // 
            lblLogHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLogHeader.ForeColor = Color.FromArgb(35, 65, 85);
            lblLogHeader.Location = new Point(55, 45);
            lblLogHeader.Name = "lblLogHeader";
            lblLogHeader.Size = new Size(900, 45);
            lblLogHeader.TabIndex = 0;
            lblLogHeader.Text = "Recent Chatbot Activities";
            // 
            // lstActivityLog
            // 
            lstActivityLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstActivityLog.BackColor = Color.LavenderBlush;
            lstActivityLog.Font = new Font("Segoe UI", 10F);
            lstActivityLog.HorizontalScrollbar = true;
            lstActivityLog.ItemHeight = 23;
            lstActivityLog.Location = new Point(55, 120);
            lstActivityLog.Name = "lstActivityLog";
            lstActivityLog.Size = new Size(1847, 1292);
            lstActivityLog.TabIndex = 1;
            // 
            // btnRefreshLog
            // 
            btnRefreshLog.BackColor = Color.SteelBlue;
            btnRefreshLog.FlatStyle = FlatStyle.Flat;
            btnRefreshLog.ForeColor = Color.White;
            btnRefreshLog.Location = new Point(55, 720);
            btnRefreshLog.Name = "btnRefreshLog";
            btnRefreshLog.Size = new Size(150, 42);
            btnRefreshLog.TabIndex = 2;
            btnRefreshLog.Text = "Refresh Log";
            btnRefreshLog.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.HotPink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1097, 857);
            Controls.Add(tabMain);
            MinimumSize = new Size(900, 700);
            Name = "Form1";
            Text = "Cybersecurity Awareness Chatbot";
            tabMain.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            tabChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabTasks.ResumeLayout(false);
            tabTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            tabQuiz.ResumeLayout(false);
            tabQuiz.PerformLayout();
            tabLog.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabChat;
        private TabPage tabTasks;
        private TabPage tabQuiz;
        private TabPage tabLog;

        private PictureBox pictureBox1;
        private Button button3;
        private TextBox ChatInput2;
        private TextBox ChatInput;

        private TextBox txtTaskTitle;
        private Label lblTaskTitle;
        private DataGridView dgvTasks;
        private Button btnAddTask;
        private CheckBox chkCompleted;
        private DateTimePicker dtpReminder;
        private TextBox txtDescription;
        private Label lblDescroption;
        private Button btnDeleteTask;

        private Button btnRestartQuiz;
        private Button btnSubmitQuiz;
        private Label lblQuizFeedback;
        private ListBox QuizBox;
        private Label lblQuizQuestion;
        private Label lblQuizProgress;

        private Button btnRefreshLog;
        private ListBox lstActivityLog;
        private Label lblLogHeader;
        private Label taskHeading;
        private Label taskSubtitle;
        private Label reminderLabel;
        private Label listHeading;
        private Label quizHeading;
    }
}
