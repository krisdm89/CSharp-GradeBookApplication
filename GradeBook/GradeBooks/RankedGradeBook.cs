using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int totalStudents = Students.Count;
            if(totalStudents < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work");
            }

            int betterStudents = Students.Where(s => s.AverageGrade >= averageGrade).ToList().Count;
            double percentage = ((double)betterStudents / (double)totalStudents);

            if(percentage <= 0.20){ return 'A'; }
            else if (percentage <= 0.40){ return 'B'; }
            else if (percentage <= 0.60){ return 'C'; }
            else if (percentage <= 0.80){ return 'D'; }
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
