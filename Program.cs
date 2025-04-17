using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;

namespace ST10382483_Jordan_Reddy_PROG6221
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start playing music in a separate thread
            Thread musicThread = new Thread(PlayMusic);
            musicThread.IsBackground = true;
            musicThread.Start("C:\\Users\\reddy\\source\\repos\\ST10382483 Jordan Reddy PROG6221\\ST10382483 Jordan Reddy PROG6221\\official_anita_baker_x_rich_gang_sweet_lifestyle_soundsbydonta_blend_aac_70837.wav"); // Pass the filename


            // Display ASCII title screen
            Console.WriteLine(@"  ____      _                                        _ _         
 / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _ 
| |  | | | | '_ \ / _ \ '__/ __|/ _ \/ __| | | | '__| | __| | | |
| |__| |_| | |_) |  __/ |  \__ \  __/ (__| |_| | |  | | |_| |_| |
 \____\__, |_.__/ \___|_|  |___/\___|\___|\__,_|_|  |_|\__|\__, |
      |___/       _   _           _                        |___/ 
  ___| |__   __ _| |_| |__   ___ | |_                            
 / __| '_ \ / _` | __| '_ \ / _ \| __|                           
| (__| | | | (_| | |_| |_) | (_) | |_                            
 \___|_| |_|\__,_|\__|_.__/ \___/ \__|                            ");

            // Prompt to continue
            Console.WriteLine("\nPress any key to begin...");
            Console.ReadKey(); // Waits for any key press before continuing

            // Call the student dictionary method
            RunStudentDictionaryProgram(); // Runs the second section of the code
        }

        static void PlayMusic(object filenameObject)
        {
            // Variables
            string filename = (string)filenameObject;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename); // Construct the correct file path

            // Making sure that the file does in fact exist 
            if (File.Exists(filePath))
            {
                SoundPlayer musicPlayer = new SoundPlayer(filePath);
                musicPlayer.Play(); // Play the music (non-blocking)
                // musicPlayer.PlayLooping(); // Optional: uncomment to loop music
            }
            else
            {
                Console.WriteLine($"Intro not available at the moment. Please check: {filePath}");
            }

        }

        static void RunStudentDictionaryProgram()
        {
            // Ask the user for their name
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine()?.Trim();

            // Keep prompting until a valid (non-empty) name is entered
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Name cannot be empty. Please enter your name:");
                userName = Console.ReadLine()?.Trim();
            }

            // Greet the user and explain the purpose of the program
            Console.WriteLine($"\nHi, {userName}! if you want to talk about cybersecurity reply with (cybersecurity) or just say hi to have a conversation.");
            Console.WriteLine("Type 'exit' anytime to end the chat.\n");

            // Dictionary storing cybersecurity-related topics and explanations
            Dictionary<string, string> topics = new(StringComparer.OrdinalIgnoreCase)
    {
        { "phishing", "Phishing:\nTricks users into giving up sensitive info through fake emails or websites that look real." },
        { "password safety", "Password Safety:\nUse strong, unique passwords. Avoid reusing passwords and consider using a password manager." },
        { "safe browsing", "Safe Browsing:\nBe cautious online. Avoid suspicious links, and always look for 'https' in URLs." },
        { "input validation", "Input Validation:\nA technique to prevent attacks like SQL injection by cleaning and validating user input." }
    };

            // Dictionary storing casual conversation responses
            Dictionary<string, string> smallTalk = new(StringComparer.OrdinalIgnoreCase)
    {
        { "hello", "Hey there!  How can I help you today?" },
        { "hi", "Hi! I’m here if you want to chat or learn something." },
        { "how are you?", "I’m doing great — just chilling in the console " },
        { "what's up", "Not much! Just hanging out, ready to chat cybersecurity " },
        { "tell me something", "Fun fact: The first computer virus was created in 1986 and was called 'Brain' " }
    };

            // Start the conversation loop
            while (true)
            {
                Console.WriteLine("\nWhat would you like to talk about now?");
                string userInput = Console.ReadLine()?.Trim();

                // Handle empty input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("I didn’t quite catch that. Please type something.");
                    continue;
                }

                // Exit condition
                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                    userInput.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nGoodbye, {userName}! Stay safe online ");
                    break;
                }

                // Respond with cybersecurity topic if matched
                if (topics.TryGetValue(userInput, out string topicInfo))
                {
                    Console.WriteLine($"\n{topicInfo}");
                }
                // Respond with small talk message if matched
                else if (smallTalk.TryGetValue(userInput, out string casualResponse))
                {
                    Console.WriteLine($"\n{casualResponse}");
                }
                // Special keyword to list available cybersecurity topics
                else if (userInput == "cybersecurity")
                {
                    Console.WriteLine("the key problems in cyber security are:" +
                        "\nphishing" +
                        "\npassword safety" +
                        "\nsafe browsing" +
                        "\ninput validation");
                }
                // Fallback response if input doesn’t match any known command
                else
                {
                    Console.WriteLine("\nI didn’t quite understand that. Try a topic like 'phishing', or say 'hello'.");
                }
            }
        }


    }
}