


# WinFormsApp1

## Overview

WinFormsApp1 is a simple Windows Forms chatbot-style application that helps users learn basic cybersecurity tips, including topics such as passwords, phishing/scams, and privacy. The user interface is implemented in `Form1.cs`, and the project targets .NET 8 and C# 12.

## Prerequisites

Before you begin, ensure you have the following installed:

- Visual Studio 2022 (or later) with the .NET desktop development workload
- .NET 8 SDK

## Setup

To set up the project, follow these steps:

1. Clone the repository.
2. Open the solution in Visual Studio: `WinFormsApp1.sln`.
3. Restore NuGet packages (Visual Studio will usually do this automatically).
4. Ensure the following resource folders and files are present in the project directory:
   - `voice/greetings.wav` (greeting sound played on startup)
   - `images/logo.png` (logo shown in the main form)

If those files are missing, the app will log a debug message but will continue to run.

## Build & Run

To build and run the application:

- Press F5 (Debug) or Ctrl+F5 (Run without debugging) in Visual Studio.
- The app opens the main form, which automatically plays the greeting (if present) and displays the logo.

## Usage

Interacting with the chatbot is straightforward:

- Type your message into the input box and press Enter or click the send button.
- The chatbot recognizes keywords like `password`, `scam`, and `privacy`, providing relevant tips.
- You can say "my name is <YourName>" to let the app remember your name for personalized replies.
- To receive follow-up suggestions on the last topic discussed, ask for "give me another tip" or similar phrases.

## Project Structure (key files)

The key files in the project are as follows:

- `Form1.cs` - Contains the main UI logic and chatbot processing.
- `Form1.Designer.cs` - Designer-generated code for UI layout.
- `Form1.resx` - Resource file for the form.

## Project Standards

This repository enforces formatting and contribution rules through an `.editorconfig` and `CONTRIBUTING.md`. If these files are missing, they will be added. Contributors must follow the rules defined in these files for naming, formatting, commit message style, and pull request structure. Typical expectations include:

- Consistent indentation and naming conventions as defined in `.editorconfig`.
- Unit tests and clear commit messages for non-trivial changes.
- A short, descriptive PR template described in `CONTRIBUTING.md`.

Please follow these standards when making changes or opening pull requests.

## Coding Standards & Contribution

This project enforces team standards via an `.editorconfig` and a `CONTRIBUTING.md`. These files will be created if missing and must be followed by contributors. Adhere to the rules in those files for naming, formatting, and commit conventions.

If you plan to contribute, please follow these steps:

1. Fork the repository.
2. Create a feature branch.
3. Follow the rules outlined in `.editorconfig` and `CONTRIBUTING.md`.
4. Open a pull request describing your changes.

## Troubleshooting

If you encounter issues, consider the following troubleshooting tips:

- If audio does not play, confirm that `voice/greetings.wav` exists and is a valid WAV file.
- If the logo does not appear, ensure that `images/logo.png` exists and is a valid PNG.
- Check the Output/Debug window in Visual Studio for logged messages from `PlayGreeting` and `DisplayLogo`.

## License

This project is provided under the MIT License. See `LICENSE` for details.


