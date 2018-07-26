using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gclab8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string> { "Nat Allison", "Sam Smith", "Kyle Silva", "Santi Martin", "Gustavo Mcgee", "Ron Keel", "Meghan Burke", "Flo Carr", "Kari Frank", "Madi Mark" };
            List<string> state = new List<string> { "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York ", "North Carolina", "North Dakota", "Oklahoma" };
            List<string> color = new List<string> { "Baby Powder", "Lawn", "Blueberry", "Bubble Gum", "Cedar Chest", "Cherry", "Jelly Bean", "Leather Jacket", "Lemon", "Licorice" };
            List<string> number = new List<string> { "1.11", "2.27", "3.14", ".44", "51", "64", "762", "89", "96", "1 Billion" };

            bool y = true;
            while (y)
            {
                //Read or add
                Console.WriteLine("Welcome to the class of random students with random likes, would you like to learn about them or add one?\nEnter 'learn' or 'add'");
                string learnOrAdd = Console.ReadLine();

                if (IsAdd(learnOrAdd))
                {
                    string newStudent = PromptAndAdd(students, "You picked add! Please Enter a name for your student:");

                    string newState = PromptAndAdd(state,"Assign them a favorite state");
                    
                    string newColor = PromptAndAdd(color, "Now they need a favorite '94-'95 Crayola Magic Scent crayon color:");

                    string newNumber = PromptAndAdd(number, "Finally lets assign them a favorite random number");
                    
                    Console.WriteLine($"You entered student {newStudent}");
                    Console.WriteLine($"They are Student Number {students.Count}");
                    Console.WriteLine($"Their favorite state and capital is {newState}");
                    Console.WriteLine($"Their favorite color is {newColor}");
                    Console.WriteLine($"Their favorite number is {newNumber}");
                    Console.WriteLine("Thank you for adding to our random class");
                }
                else if (IsLearn(learnOrAdd))
                {
                    Console.WriteLine($"This is the classroom of randoms.\nPlease enter 1 - {students.Count} to learn about one of them!");
                    string user = Console.ReadLine();

                    int userInt;
                    bool num1 = int.TryParse(user, out userInt);

                    if (IsInRange(userInt, students.Count))
                    {
                        Console.WriteLine($"You picked student {students[userInt - 1]}!\nWould you like to know their favorite State or their favorite '94-'95 Crayola Magic Scent crayon color? or favorite number\nPlease enter 'state' or 'color' or 'number' for more!");
                        string userTwo = Console.ReadLine();

                        if (IsState(userTwo))
                        {
                            Console.WriteLine(state[userInt - 1]);
                        }

                        if (IsColor(userTwo))
                        {
                            Console.WriteLine(color[userInt - 1]);
                        }

                        if (IsNumber(userTwo))
                        {
                            Console.WriteLine(number[userInt - 1]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sorry Bud, that is an invaild input");
                }

                //continue y/n
                bool invalid = true;
                while (invalid)
                {
                    Console.WriteLine("Give it another go? (y/n):");
                    ConsoleKeyInfo pressed = Console.ReadKey();
                    Console.WriteLine();
                    bool isY = pressed.Key == ConsoleKey.Y;
                    bool isN = pressed.Key == ConsoleKey.N;

                    invalid = !isY && !isN;
                    y = isY;
                }
            }
        }

        //Method to catch 0 and out of range
        static bool IsInRange(int num, int studentLength)
        {
            return num > 0 && num <= studentLength;
        }

        //checks to see if two values are equal 
        static bool IsWords(string input1, string input2)
        {
            return input1.ToLower() == input2.ToLower();
        }

        //did user enter requested text "state"
        static bool IsState(string input)
        {
            return IsWords(input, "state");
        }

        //did user enter requested text "color"
        static bool IsColor(string input)
        {
            return IsWords(input, "color");
        }

        //did user enter requested text "number"
        static bool IsNumber(string input)
        {
            return IsWords(input, "number");
        }

        //did user enter "add"
        static bool IsAdd(string input)
        {
            return IsWords(input, "add");
        }

        //did user enter "learn"
        static bool IsLearn(string input)
        {
            return IsWords(input, "learn");
        }
        
        //prompt user for valid input and adds it to the list
        static string PromptAndAdd(List<string> items, string prompt)
        { 
            string item;
            do
            {
                Console.WriteLine(prompt);
                item = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(item));

            items.Add(item);
            return item; 
        }
    }
}
