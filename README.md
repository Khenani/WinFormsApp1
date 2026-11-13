Cybersecurity Awareness Chatbot (Part 3)

 Project Overview

The Cybersecurity Awareness Chatbot is a desktop Graphical User Interface (GUI) application built in C# using Visual Studio 2022. Designed to educate and assist users in staying safe online, the application combines conversational Natural Language Processing (NLP), persistent MySQL task management, an interactive cybersecurity quiz mini-game, and a live activity logger across a clean multi-tab layout.

Key Features

Conversational Cybersecurity Assistant (Chat Tab):

Audio & Visual Greeting: Plays an automated voice greeting (greetings.wav) and displays the application logo (logo.png) on launch.

Memory & Personalization: Remembers the user's name and preferred cybersecurity topics throughout the session.

Sentiment & Fuzzy Matching: Recognizes emotional cues (e.g., worried, anxious) to offer reassuring advice, and handles minor spelling variations using fuzzy string matching.

NLP Intent & Date Parsing: Automatically detects reminders and tasks typed in natural language and schedules them in the database.

 MySQL Task Assistant (Task Assistant Tab):

Full CRUD (Create, Read, Update, Delete) integration with a local MySQL database.

Allows users to create cybersecurity tasks with titles, descriptions, and reminder dates using a date picker, mark tasks as completed, and delete old entries.

Cybersecurity Awareness Quiz (Quiz Tab):

Interactive multiple-choice mini-game covering password safety, phishing, scams, and safe browsing.

Tracks real-time scores and provides immediate educational explanations after every question.
 Live Activity Log (Activity Log Tab):

Tracks and displays a chronological history of recent user actions (e.g., tasks added, reminders scheduled, quiz attempts, and chat interactions).

Accessible both via the dedicated tab and by asking the chatbot "What have you done?" or "Activity log".

 Project Architecture

WinFormsApp1/
├── Data/
│   ├── DbConfig.cs            # MySQL database connection configuration
│   └── TaskRepo.cs            # CRUD database operations using MySqlConnector
├── Database/
│   └── setup.sql              # SQL script to initialize database and tasks table
├── Models/
│   └── TaskItem.cs            # Data model representing a cybersecurity task
├── Services/
│   ├── ActivityLogger1.cs     # Tracks and retrieves recent user activities
│   ├── ChatBotEngine.cs       # Core response routing and conversation engine
│   ├── FuzzyMatcher.cs        # Keyword similarity and typo tolerance logic
│   ├── NlpServices.cs         # Intent recognition and keyword extraction
│   ├── QuizServices.cs        # Quiz questions, scoring, and answer validation
│   ├── ReminderParser.cs      # Extracts dates from natural language inputs
│   └── TaskDescription.cs     # Formats and structures task descriptions
├── images/
│   └── logo.png               # Application branding logo
├── voice/
│   └── greetings.wav          # Startup welcome audio clip
├── Form1.cs                   # Main UI logic and event handlers
└── Form1.Designer.cs          # Windows Forms GUI layout and controls


⚙️ Setup & Installation

1. Prerequisites

Visual Studio 2022 with the .NET desktop development workload.

MySQL Server (e.g., MySQL Workbench, XAMPP, or WAMP).

NuGet Package: MySqlConnector.

2. Database Configuration

Open your MySQL client and execute the following SQL script to create the database and table:

CREATE DATABASE IF NOT EXISTS cyberbot_db;
USE cyberbot_db;

CREATE TABLE IF NOT EXISTS tasks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    reminder_date DATETIME NULL,
    is_completed BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


Open Data/DbConfig.cs in your project and verify that your server credentials match your local MySQL setup.

3. Running the Application

Open WinFormsApp1.sln in Visual Studio 2022.

Restore NuGet packages if prompted (MySqlConnector).

Press Start (F5) to build and run the application.

isted YouTube link here before submission]
