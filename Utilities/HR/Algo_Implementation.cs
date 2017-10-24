using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.HR
{
    public class Algo_Implementation
    {
        public static void Test()
        {
            //GradingStudents();
            AppleAndOrange();
        }

        private static void AppleAndOrange()
        {
            string[] tokens_s = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int t = Convert.ToInt32(tokens_s[1]);
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] apple_temp = Console.ReadLine().Split(' ');
            int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
            string[] orange_temp = Console.ReadLine().Split(' ');
            int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);

            if (s < 1 || s > 100000 || t < 1 || t > 100000 || a < 1 || a > 100000 || b < 1 || b > 100000 || m < 1 || m > 100000 || n < 1 || n > 100000)
                throw new Exception("Invalid arguments passed. No value can be less than 1 or greater than 100000.");

            if (a > s || a > t || a >b)
                throw new Exception("invalid argument");

            if (s > t || s > b)
                throw new Exception("invalid argument");

            if (t > b)
                throw new Exception("invalid argument");

            int appleCount = 0;
            int orangeCount = 0;

            foreach(var d in apple)
            {
                if (d < -100000 || d > 100000)
                    throw new Exception("invalid argument");

                int pos = a + d;
                
                if (pos >= s && pos <= t)
                    appleCount++;

            }

            foreach (var d in orange)
            {
                if (d < -100000 || d > 100000)
                    throw new Exception("invalid argument");

                int pos = b + d;

                if (pos >= s && pos <= t)
                    orangeCount++;
            }

            Console.WriteLine(appleCount);
            Console.WriteLine(orangeCount);

        }

        private static void GradingStudents()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 1 || n > 60)
                throw new Exception("Invalid number of students");

            int[] grades = new int[n];
            for (int grades_i = 0; grades_i < n; grades_i++)
            {
                int val = Convert.ToInt32(Console.ReadLine());
                if (val < 0 || val > 100)
                    throw new Exception("Invalid grade.");

                grades[grades_i] = val;
            }
            if (n != grades.Length)
                throw new Exception("number of students and number of grades dont match.");

            int[] result = solve(grades);
            Console.WriteLine(String.Join("\n", result));
        }

        static int[] solve(int[] grades)
        {
            int[] result = new int[grades.Length];
            for(int i=0;i<grades.Length;i++)
            {
                int grade = grades[i];
                if (grade < 38)
                    result[i] = grade;
                else
                {
                    int roundedVal = GetNextMultipleOf5(grade);
                    if (roundedVal - grade < 3)
                        result[i] = roundedVal;
                    else
                        result[i] = grade;

                }
            }

            return result;
        }

        static int GetNextMultipleOf5(int n)
        {
            int remainder = n % 5;
            return n + (5 - remainder);
        }
    }
}
