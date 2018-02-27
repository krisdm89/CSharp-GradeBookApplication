using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int totalStudents = Students.Count;
            if(totalStudents < 5)
            {
                throw new Exception("Ranked Grading requires a minimum of 5 students to work");
            }

            int betterStudents = Students.Where(s => s.AverageGrade >= averageGrade).ToList().Count;

            double percentage = ((double)betterStudents / (double)totalStudents);

            if(percentage <= 0.20)
            {
                return 'A';
            }
            else if (percentage <= 0.40)
            {
                return 'B';
            }
            else if (percentage <= 0.60)
            {
                return 'C';
            }
            else if (percentage <= 0.80)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
