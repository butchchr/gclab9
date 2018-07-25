﻿using System;
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
            List<string> students = new List<string> { "Nat Allison", "Sam Smith", "Kyle Silva", "Santi Martin", "Gustavo Mcgee", "Ron Keel", "Meghan Burke", "Flo Carr", "Kari Frank", "Madi Mark"};
            List<string> state = new List<string> { "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York ", "North Carolina", "North Dakota", "Oklahoma"};
            List<string> color = new List<string> { "Baby Powder", "Lawn", "Blueberry", "Bubble Gum", "Cedar Chest", "Cherry", "Jelly Bean", "Leather Jacket", "Lemon", "Licorice"};
            List<string> number = new List<string> { "1.11", "2.27", "3.14", ".44", "51", "64", "762", "89", "96", "1 Billion" };

            bool y = true;
            while (y)
            {
                //Read or add
                Console.WriteLine("Welcome to the class of random students with random likes, would you like to learn about them or add one?" + "\n" + "Enter 'learn' or 'add'");
                string learnOrAdd = Console.ReadLine();

                if (IsAdd(learnOrAdd) == true)
                {
                    Console.WriteLine("You picked add! Please Enter a name for your student:");
                    string newStudent = Console.ReadLine();
                    if (IsNOW(newStudent))
                    {
                        students.Add(newStudent); 
                    }

                    Console.WriteLine("Assign them a favorite state");
                    string newState = Console.ReadLine();
                    if (IsNOW(newState))
                    {
                        students.Add(newState);
                    }

                    Console.WriteLine("Now they need a favorite '94-'95 Crayola Magic Scent crayon color:");
                    string newColor = Console.ReadLine();
                    if (IsNOW(newColor))
                    {
                        color.Add(newColor);
                    }

                    Console.WriteLine("Finally lets assign them a favorite random number");
                    string newNumber = Console.ReadLine();
                    if (IsNOW(newNumber))
                    {
                        number.Add(newNumber);
                    }

                    Console.WriteLine($"You entered student {newStudent}");
                    Console.WriteLine($"They are Student Number {students.Count-1}");
                    Console.WriteLine($"Their favorite state and capital is {newState}");
                    Console.WriteLine($"Their favorite color is {newColor}");
                    Console.WriteLine($"Their favorite number is {newNumber}");
                    Console.WriteLine("Thank you for adding to our random class");
                }

                else if (IsAdd(learnOrAdd) == false)
                {
                    Console.WriteLine($"This is the classroom of randoms." + "\n" + "Please enter 1-{students.count-1} to learn about one of them!");
                    string user = Console.ReadLine();

                    if (!IsInRange(user))
                    {
                        int userInt = int.Parse(user);
                        Console.WriteLine("You picked student " + students[userInt - 1] + "!" + "\n" + "Would you like to know their favorite State & Capital city or their favorite '94-'95 Crayola Magic Scent crayon color? or favorite number" + "\n" + "Please enter 'state' or 'color' or 'number' for more!");
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

        //method to check for null or white space
        static bool IsNOW(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        //Method to catch 0 and out of range
        static bool IsInRange(string word)
        {

            if (!string.IsNullOrWhiteSpace(word))
            {
                
                int num;
                int.TryParse(word, out num);
                if (num > 0 && num <= 11)
                {
                    return false;
                }
            }
            return true;
        }

        //did user enter requested text "state"
        static bool IsState(string input)
        {
            string lower = input.ToLower();
            if (lower == "state")
            {
                return true;
            }
            return false;
        }

        //did user enter requested text "color"
        static bool IsColor(string input)
        {
            string lower = input.ToLower();
            if (lower == "color")
            {
                return true;
            }
            return false;
        }

        //did user enter requested text "color"
        static bool IsNumber(string input)
        {
            string lower = input.ToLower();
            if (lower == "number")
            {
                return true;
            }
            return false;
        }

        static bool IsAdd (string input)
        {
            string lower = input.ToLower();
            if (lower == "add")
            {
                return true;
            }
            return false;
        }
    }
}
