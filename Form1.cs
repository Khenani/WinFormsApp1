using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Memory variables
        private string userName = "";
        private string favoriteTopic = "";
        private string lastTopic = "";

        // Dictionary and List collections
        public Dictionary<string, List<string>> topicTips;
        public List<string> worriedWords;
        private Random rand = new Random();

        public Form1()
        {
            InitializeData();
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);
            ChatInput2.KeyDown += new KeyEventHandler(ChatInput2_KeyDown);
        }

        public void InitializeData()
        {
            topicTips = new Dictionary<string, List<string>>
            {
                {
                    "password", new List<string>{
                        "Make sure to use strong, unique passwords for each account. Avoid using personal details. \n\nWould you like a tip on how to create a memorable password?",
                        "Use a strong combination of uppercase, lowercase, numbers, and symbols. \n\nDo you currently use a password manager to keep track of them?"
                    }
                },
                {
                    "scam", new List<string>{
                        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations. \n\nHave you ever received a suspicious email like this?",
                        "Never share your OTP (One-Time PIN) or banking credentials with anyone over the phone. \n\nWould you like to hear about another common scam tactic?"
                    }
                },
                {
                    "phishing", new List<string>{
                        "Never click on suspicious links or attachments from unknown senders. \n\nWould you like me to show you how to spot a fake link?",
                        "Always verify the sender's email address carefully before responding to urgent requests. \n\nHave you ever clicked a link by accident?"
                    }
                },
                {
                    "privacy", new List<string>{
                        "Protecting your privacy is a crucial part of staying safe online. \n\nDo you regularly review your social media privacy settings?",
                        "Regularly clear your browser cookies and check which apps have location access. \n\nWould you like another privacy tip?"
                    }
                }
            };

            worriedWords = new List<string>
            {
                "worried",
                "concerned",
                "anxious",
                "nervous",
                "scared",
                "afraid",
                "overwhelmed"
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayGreeting();
            DisplayLogo();

            // 1. FORMATTED INITIAL BOT GREETING
            ChatInput.AppendText("🤖 Chatbot:" + Environment.NewLine + "   Hello there! Welcome to your Cybersecurity Assistant. What is your name?" + Environment.NewLine + "--------------------------------------------------" + Environment.NewLine + Environment.NewLine);
        }

        private void ProcessUserMessage()
        {
            string userText = ChatInput2.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            // 2. FORMATTED USER MESSAGE DISPLAY
            ChatInput.AppendText("👤 User:" + Environment.NewLine + "   " + userText + Environment.NewLine + Environment.NewLine);

            string lowerText = userText.ToLower();
            string botReply = "";

            // 1. Memory: Check if user is sharing their name
            if (string.IsNullOrEmpty(userName) && (lowerText.Contains("my name is") || lowerText.Contains("i am ") || lowerText.Split(' ').Length == 1))
            {
                // If name hasn't been set yet, treat the input (or last word) as their name
                string[] parts = userText.Split(' ');
                userName = parts[parts.Length - 1];
                botReply = $"Chatbot: Nice to meet you, {userName}! I'll remember that. Would you like to talk about passwords, scams, or privacy?";
            }
            // 2. Conversation Flow: Handle follow-up requests
            else if (lowerText.Contains("give me another tip") || lowerText.Contains("tell me more") || lowerText.Contains("explain more") || lowerText.Contains("yes"))
            {
                if (!string.IsNullOrEmpty(lastTopic) && topicTips.ContainsKey(lastTopic))
                {
                    List<string> tips = topicTips[lastTopic];
                    string selectedTip = tips[rand.Next(tips.Count)];
                    botReply = $"Chatbot: {(!string.IsNullOrEmpty(userName) ? userName + ", " : "")}{selectedTip}";
                }
                else
                {
                    botReply = $"Chatbot: {userName}, we haven't discussed a specific topic yet! Would you like to talk about passwords, scams, or privacy?";
                }
            }
            // 3. Sentiment Detection: Worried / Anxious
            else
            {
                bool sentimentMatched = false;
                foreach (var word in worriedWords)
                {
                    if (lowerText.Contains(word))
                    {
                        lastTopic = "scam";
                        botReply = $"Chatbot: It's completely understandable to feel that way{(!string.IsNullOrEmpty(userName) ? ", " + userName : "")}. Scammers can be very convincing. Always verify unexpected messages through official channels!\n\nWould you like to talk about how to spot these scams?";
                        sentimentMatched = true;
                        break;
                    }
                }

                if (!sentimentMatched)
                {
                    // 4. Dictionary Keyword Lookup
                    bool topicMatched = false;
                    foreach (var topic in topicTips.Keys)
                    {
                        if (lowerText.Contains(topic))
                        {
                            lastTopic = topic;
                            favoriteTopic = topic;

                            List<string> tips = topicTips[topic];
                            string selectedTip = tips[rand.Next(tips.Count)];

                            botReply = $"Chatbot: {(!string.IsNullOrEmpty(userName) ? userName + ", " : "")}{selectedTip}";
                            topicMatched = true;
                            break;
                        }
                    }

                    // 5. Default Error Handling with an engaging question
                    if (!topicMatched)
                    {
                        botReply = $"Chatbot: I'm not entirely sure I understand, {userName}. Can you try rephrasing, or would you like to ask about passwords, scams, or privacy?";
                    }
                }
            }

            // Append bot response to chat log and clear input
            ChatInput.AppendText(botReply + Environment.NewLine + Environment.NewLine);
            ChatInput2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessUserMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessUserMessage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("voice/greetings.wav");
                player.Play();
            }
            catch
            {
                // Fallback if audio is missing
            }
        }

        private void DisplayLogo()
        {
            try
            {
                pictureBox1.Image = Image.FromFile("images/logo.png");
            }
            catch
            {
                // Fallback if image is missing
            }
        }

        private void ChatInput2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessUserMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void ChatInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
