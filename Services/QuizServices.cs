
using System;
using System.Collections.Generic;

namespace WinFormsApp1.Services
{
    internal class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string question, List<string> options,
            int correctAnswerIndex, string explanation)
        {
            Question = question;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
            Explanation = explanation;
        }
    }

    internal class QuizServices
    {
        private readonly List<QuizQuestion> questions =
            new List<QuizQuestion>
        {
            new QuizQuestion(
                "What does HTTPS help protect?",
                new List<string> { "Your internet speed", "Data sent between your browser and a website", "Your screen brightness", "Your computer battery" },
                1,
                "HTTPS encrypts data exchanged between your browser and the website."
            ),
            new QuizQuestion(
                "Which password is the strongest?",
                new List<string> { "123456", "password", "M@ngo!River92#Tree", "yourname123" },
                2,
                "A strong password is long, unique and difficult to guess."
            ),
            new QuizQuestion(
                "What is phishing?",
                new List<string> { "A computer game", "A fraudulent attempt to steal information", "A software update", "A type of keyboard" },
                1,
                "Phishing tricks people into revealing sensitive information."
            ),
            new QuizQuestion(
                "True or False: You should share your OTP with someone who calls claiming to be your bank.",
                new List<string> { "True", "False" },
                1,
                "Never share your OTP. Banks should not ask you to disclose it."
            ),
            new QuizQuestion(
                "What does 2FA stand for?",
                new List<string> { "Two-Factor Authentication", "Two File Access", "Fast Account Activation", "Two-Folder Application" },
                0,
                "2FA adds another verification step when signing in."
            ),
            new QuizQuestion(
                "What should you do with a suspicious email attachment?",
                new List<string> { "Open it immediately", "Forward it to everyone", "Avoid opening it and report it", "Download it twice" },
                2,
                "Suspicious attachments may contain malware."
            ),
            new QuizQuestion(
                "What is malware?",
                new List<string> { "Malicious software", "A computer monitor", "A secure password", "An internet provider" },
                0,
                "Malware is software designed to harm or exploit devices and systems."
            ),
            new QuizQuestion(
                "True or False: Public Wi-Fi is always safe for banking.",
                new List<string> { "True", "False" },
                1,
                "Public Wi-Fi may be insecure. Avoid sensitive transactions on untrusted networks."
            ),
            new QuizQuestion(
                "Why should you update your software?",
                new List<string> { "To remove your files", "To improve security and fix vulnerabilities", "To slow down your device", "To share your password" },
                1,
                "Updates often fix security weaknesses."
            ),
            new QuizQuestion(
                "What is social engineering?",
                new List<string> { "Building social media apps", "Manipulating people into revealing information", "Designing websites", "Installing a printer" },
                1,
                "Social engineering uses manipulation to exploit human trust."
            ),
            new QuizQuestion(
                "What should you do if you suspect your account has been hacked?",
                new List<string> { "Ignore it", "Change your password and secure the account", "Share your login details", "Delete all your contacts" },
                1,
                "Change compromised passwords, enable 2FA and contact the service provider."
            ),
            new QuizQuestion(
                "True or False: You should use the same password for every account.",
                new List<string> { "True", "False" },
                1,
                "Unique passwords prevent one compromised account from exposing others."
            )
        };

        private int currentQuestionIndex = 0;
        private int score = 0;

        public int TotalQuestions => questions.Count;
        public int CurrentQuestionIndex => currentQuestionIndex;
        public int Score => score;
        public bool IsQuizFinished => currentQuestionIndex >= questions.Count;

        public QuizQuestion GetCurrentQuestion()
        {
            if (IsQuizFinished)
                return null;

            return questions[currentQuestionIndex];
        }

        public bool SubmitAnswer(int selectedAnswerIndex)
        {
            if (IsQuizFinished)
                return false;

            bool isCorrect =
                selectedAnswerIndex == questions[currentQuestionIndex].CorrectAnswerIndex;

            if (isCorrect)
                score++;

            currentQuestionIndex++;

            return isCorrect;
        }

        public void RestartQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;
        }
    }
}
