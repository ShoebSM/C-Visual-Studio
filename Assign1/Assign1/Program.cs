/*  Assignment 1 - CSCI 473 - Hutchins
 *  Shoeb Mohammed z1700231
 *  Reid Wixon z1693990
 *  Harika Bandi z1782521
 *  Pratik Patel z1751854
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1
{
    //Implements person class, contains strings Name and OfficeNumber
    //Implements IComparable interface
    public class Person  : IComparable
    {
        private String name;
        private String officeNum;

    //Initializing Constructor
        public Person(String N, String oN)
        {
            Name = N;
            OfficeNum = oN;
        }
    //Properties
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String OfficeNum
        {
            get { return officeNum; }
            set { officeNum = value; }
        }
        //Prints Person name and officeNum
        //Returns void
        public void printPerson()
        {
            Console.WriteLine("Name:{0} Office Num:{1}", this.name.PadRight(10), this.officeNum.PadRight(10));
        }

        //Implements CompareTo method of iComparable class
        //Accepts object OBJ 
        //Returns -1 0 or 1
        public int CompareTo(object OBJ)
        {
            Person obj = (Person)OBJ;
            return String.Compare(this.name, obj.name);
        }
    } //End of class Person 
    class Program
    {
        public static Person [] people = new Person[20];
        public static int InUse = 0;

        //Searches people array by name
        //Accepts string query, returns void
        public static void search(String query)
        {
            //List<Person> matches = new List<Person>();
            bool found = false;
            foreach (Person X in people)
            {
                if (X != null)
                {
                    if (X.Name.Contains(query))
                    {
                        X.printPerson();
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("The name {0} was not found", query);
            }
        }
        //Searches people array by officeNum
        //Accepts string query, returns void
        public static void search2(String query)
        {
            //List<Person> matches = new List<Person>();
            bool found = false;
            foreach (Person X in people)
            {
                if (X != null)
                {
                    if (X.OfficeNum.Contains(query))
                    {
                        X.printPerson();
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("The Office Number {0} was not found", query);
            }
        }

        static void Main(string[] args)
        {
            //Reads Names and Office Numbers from text file
            using (StreamReader SR = new StreamReader("data1.txt"))
            {
                String readName;
                String readNum;
                readName = SR.ReadLine();
                //while !EOF
                while (readName != null)
                {
                    readNum = SR.ReadLine();
                    people[InUse] = new Person(readName, readNum);
                    InUse++;
                    readName = SR.ReadLine();
                }
            }

        

            //Switch case content goes here
            Console.WriteLine("Enter any Menu Option to Proceed:");
            Console.WriteLine("A:Print List");
            Console.WriteLine("B:Add an Entry");
            Console.WriteLine("C:Search for Name");
            Console.WriteLine("D:Search for Office Entry");
            Console.WriteLine("E:Sort List");
            Console.WriteLine("F:Quit");

            String input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("The choice is {0}:", input);
            
            while (input != "F")
            { 
            switch (input)
            {
                      case "A": //Print List
                      case "a":
                    //Iterates through people array and prints entries
                    foreach (Person X in people) 
                    {
                            if (X != null)
                            {
                                X.printPerson();
                            }          
                    }
                    break;
                case "B": //Add an Entry
                case "b":
                    Console.WriteLine("Enter desired name:");
                    String enterName = Console.ReadLine();
                    Console.WriteLine("Enter office number:");
                    String enterNum = Console.ReadLine();
                    people[InUse] = new Person(enterName, enterNum);
                    InUse++;
                        Console.WriteLine("In Use: {0}", InUse);
                        Console.WriteLine("Entry has been added");
                    break;

                  case "C": //Search by Name
                  case "c":
                        Console.WriteLine("Enter name to search");
                        String query = Console.ReadLine();
                        search(query);
                    break;

                    case "D": //Search by OfficeNum
                    case "d":
                        Console.WriteLine("Enter OfficeNum to Search");
                         query = Console.ReadLine();
                        search2(query);
                    break;
                case "E": //Sort array
                case "e":
                    Array.Sort(people);
                        Console.WriteLine("List Sorted");
                    break;
                default:
                    Console.WriteLine("Not one of the choices");
                    break;
            }       //End of switch
                //Loops you back to menu options after selection
                Console.WriteLine();
                Console.WriteLine("Enter any Menu Option to Proceed:");
                Console.WriteLine("A:Print List");
                Console.WriteLine("B:Add an Entry");
                Console.WriteLine("C:Search for Name");
                Console.WriteLine("D:Search for Office Entry");
                Console.WriteLine("E:Sort List");
                Console.WriteLine("F:Quit");

                input = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("The choice is {0}:", input);

            } // End of While
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
        }
    }
}
