using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class HR_Algo_Implementation
    {
        public static void Test()
        {
            GradingStudents();

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
