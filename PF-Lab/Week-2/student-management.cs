using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Messaging;

namespace chlg1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int arraySize = 10;  // array size
            // data structs
            Student[] studentData = new Student[arraySize];
            int stdCount = 0;
            // other
            bool showTop3 = false;
            while (true)
            {
                Console.Clear();  // for refreshing display
                string opt = menu();
                if (opt == "1")
                {
                    Console.Clear();  // for refreshing display
                    studentData[stdCount] = addStudentData();
                    stdCount++;  // added a user
                }
                else if (opt == "2")
                {
                    Console.Clear();  // for refreshing display
                    showStudentsData(studentData, stdCount);
                }
                else if (opt == "3")
                {
                    Console.Clear();  // for refreshing display
                    showTop3 = aggregateCalculator(studentData, stdCount);
                }
                else if (opt == "4")  // if we have calculated aggrgt then we can show topStudents
                {
                    Console.Clear();  // for refreshing display
                    if (showTop3)
                        topStudents(studentData, stdCount);
                    else
                        error("First calculate the aggregate");
                }
                else if (opt == "5")
                {
                    Console.Clear();  // for refreshing display
                    return; // terminating program
                }
                else
                {
                    // error case 
                }
            }
        }
        static Student addStudentData()
        {
            // getting required input
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Matric Marks: ");
            float matric = float.Parse(Console.ReadLine());

            Console.Write("Enter Name Fsc Marks: ");
            float fsc = float.Parse(Console.ReadLine());

            Console.Write("Enter Ecat Marks: ");
            float ecat = float.Parse(Console.ReadLine());
            success("Student added successfully...");
            // returning new student with values intialized
            return new Student(name, matric, fsc, ecat);
        }
        static void showStudentsData(Student[] stds, int count)
        {
            // header
            Console.WriteLine("Name\tMatric\tFsc\tEcat");
            // displaying req data
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine($"{stds[i].stdName}\t{stds[i].matric}\t{stds[i].fsc}\t{stds[i].ecat}");
            }
            pressAnyKey();
        }
        static bool aggregateCalculator(Student[] stds, int count)
        {
            // total marks
            const int matricFull = 1100;
            const int fscFull = 1100;
            const int ecatFull = 1100;
            // calculations
            for (int i = 0; i < count; ++i)
            {
                float calculatedValue = (stds[i].matric/matricFull * (30/100)) + (stds[i].fsc / fscFull * (60 / 100)) + (stds[i].ecat / ecatFull * (10 / 100));
                stds[i].aggregate = calculatedValue;  // storing after complete caculation
            }
            success("Successfully calculated the aggregate");
            return true;   // now we can use top3 func
        }
        static void topStudents(Student[] stds, int count)
        {
            const int size = 3;  // no of std we want to show
            // sorting arr using func
            sortArrayByMax(stds, count);

            // displaying the top 3 students
            Console.WriteLine("Top 3 Students:");
            Console.WriteLine("Name\tAggregate");
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine($"{stds[i].stdName}\t{stds[i].aggregate}");
            }
            pressAnyKey();
        }
        static void sortArrayByMax(Student[] arr, int size)
        {
            for (int i = 0; i < size - 1; ++i)
            {
                // Find the index of the maximum element in the unsorted portion
                int maxIndex = i;
                for (int j = i + 1; j < size; ++j)
                {
                    if (arr[j].aggregate > arr[maxIndex].aggregate)
                    {
                        maxIndex = j;
                    }
                }
                // Swap the maximum element with the first element of the unsorted portion
                swapString(ref arr[i].stdName, ref arr[maxIndex].stdName);
                swapFloat(ref arr[i].aggregate, ref arr[maxIndex].matric);
                swapFloat(ref arr[i].aggregate, ref arr[maxIndex].fsc);
                swapFloat(ref arr[i].aggregate, ref arr[maxIndex].ecat);
                swapFloat(ref arr[i].aggregate, ref arr[maxIndex].aggregate);
            }
        }
        static void swapString(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }
        static void swapFloat(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }
        static string menu()
        {
            // menu items
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show Students");
            Console.WriteLine("3. Calculate Aggregate");
            Console.WriteLine("4. Top Students");
            Console.WriteLine("5. Exit");
            // input
            Console.Write("Select option: ");
            return Console.ReadLine();
        }
        static void success(string message)
        {
            // displays success msg specified at call
            Console.WriteLine(message);
            pressAnyKey();
        }
        static void error(string message)
        {
            // displays an error msg specified at call
            Console.WriteLine(message);
            pressAnyKey();
        }
        static void pressAnyKey()
        {
            // used for stopping execution
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
