using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegularExpression_Assignment13
{
    internal class Program
    {
        static void Main(string[] args)
        {         
                // Prompt user to enter text
                Console.WriteLine("Enter a piece of text or paragraph:");
                string inputText = Console.ReadLine();

                // Call methods to process and display results
                int wordCount = CountWords(inputText);
                Console.WriteLine($"Word Count: {wordCount}");

                string[] emailAddresses = GetEmailAddresses(inputText);
                Console.WriteLine($"Email Addresses: {string.Join(", ", emailAddresses)}");

                string[] mobileNumbers = ExtractMobileNumbers(inputText);
                Console.WriteLine($"Mobile Numbers: {string.Join(", ", mobileNumbers)}");

                Console.WriteLine("Enter a custom regular expression:");
                string customRegexPattern = Console.ReadLine();
                string[] customRegexMatches = PerformCustomRegexSearch(inputText, customRegexPattern);
                Console.WriteLine($"Custom Regex Matches: {string.Join(", ", customRegexMatches)}");
            }

            static int CountWords(string text)
            {
                // Use Regex to count words (sequences of characters separated by spaces)
                MatchCollection matches = Regex.Matches(text, @"(\b\w+\b)");
                return matches.Count;
            }
            static string[] GetEmailAddresses(string text)
            {
                // Use Regex to find email addresses in the text
                MatchCollection matches = Regex.Matches(text, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
                return GetMatchValues(matches);
            }
            static string[] ExtractMobileNumbers(string text)
            {
                // Use Regex to extract mobile numbers (10 digits)
                MatchCollection matches = Regex.Matches(text, @"\b\d{10}\b");
                return GetMatchValues(matches);
            }
            static string[] PerformCustomRegexSearch(string text, string pattern)
            {
                // Use Regex to perform custom search based on user-provided pattern
                MatchCollection matches = Regex.Matches(text, pattern);
                return GetMatchValues(matches);
            }
            static string[] GetMatchValues(MatchCollection matches)
            {
                // Helper method to extract values from MatchCollection
                string[] values = new string[matches.Count];
                for (int i = 0; i < matches.Count; i++)
                {
                    values[i] = matches[i].Value;
                }
                return values;
            }
        }
    }

