using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrarySort
{
    //Class - User
    public class User: IComparable
    {
        public string _name;
        public int _age;

        public User(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public int CompareTo(object obj)
        {
            if (obj is User)
            {
                return this._name.CompareTo((obj as User)._name);  // compare user names
            }
            throw new ArgumentException("Object is not a User");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            // Unsorted Arrays
            int[] intArray = new int[5] { 8, 10, 2, 6, 3 };
            string[] stringArray = new string[5] { "X", "B", "Z", "Y", "A" };
            User[] users = new User[3] { new User("Betty", 23), 
                                                          new User("Susan", 20),
                                                          new User("Lisa", 25) };

            Console.WriteLine("Array Sort Using ? Methods");

            // Write Unsorted int array
            Console.WriteLine("Unsorted Int Array");
            foreach (int i in intArray) Console.Write(i + " ");
            Console.WriteLine();

            // Write Sorted Int Array
            Console.WriteLine("Sort Using .Sort() Function");
            Array.Sort(intArray);
            foreach (int i in intArray) Console.Write(i + " ");
            Console.WriteLine();

            // Write Unsorted String Array
            Console.WriteLine("Unsorted String Array");
            foreach (string str in stringArray) Console.Write(str + " ");
            Console.WriteLine();

            // Write Sorted String Array
            Console.WriteLine("Sorted String Array");
            Array.Sort(stringArray);
            foreach (string str in stringArray) Console.Write(str + " ");
            Console.WriteLine();

            // Write Unsorted Custom Array
            Console.WriteLine("Unsorted Custom Array");
            foreach (User user in users)
            {
                Console.WriteLine(user._name + " " + user._age);
            }
            Console.WriteLine();

            // Sort By Name using Delegate (Represents the method that compares two objects of the same type).
            Console.WriteLine("Sort By Name Using Delegate");
            Array.Sort(users, delegate (User user1, User user2)
            {
                return user1._name.CompareTo(user2._name);
            });
            foreach (User user in users)
            {
                Console.WriteLine(user._name + " " + user._age + " ");
            }
            Console.WriteLine();

            // Sort By Age using Delegate
            Console.WriteLine("Sort By Age Using Delegate");
            Array.Sort(users, delegate (User user1, User user2)
            {
                return user1._age.CompareTo(user2._age);
            });
            foreach (User user in users)
            {
                Console.WriteLine(user._name + " " + user._age + " ");
            }
            Console.WriteLine();

            // Sort By Name using IComparable.
            Console.WriteLine("Sort By Name using IComparable");
            Array.Sort(users);
            foreach (User user in users)
            {
                Console.WriteLine(user._name + " " + user._age + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Press Any Key To Continue . . ");
            Console.ReadKey();

            // Write Unsorted Custom Array
        }
    }
}
