using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLinq
{
    public partial class Program
    {
        public static void TaskOne(string surname, string name, string fathername)
        {
            var IdStudent =
                from IdStud in Student
                where (IdStud.surname == surname) && (IdStud.name == name) && (IdStud.fathername == fathername)
                select new { IdStud.id, IdStud.groop };
            if (IdStudent.Count() != 0)
            {
                var MarksSubjectStudent =
                    from Marks in MArks
                    orderby Marks.subject ascending
                    orderby Marks.numberSession ascending
                    join StudID in IdStudent on Marks.idStudent equals StudID.id
                    select Marks;
                var v = IdStudent.ElementAt(0);
                Console.WriteLine(surname + " " + name + " " + fathername + " из группы " + v.groop);
                foreach (var Marks in MarksSubjectStudent)
                {
                    Console.WriteLine(Marks.subject + " " + Marks.status + " c оценкой: " + Marks.Marks + " в сесии номер: " + Marks.numberSession);
                }
            }
            else
            {
                Console.WriteLine("Данного студента не существует");
            }
        }
    }
}