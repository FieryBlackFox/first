using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLinq
{
    public partial class Program
    {
        public static void TaskOne1(string surname, string name, string fathername)
        {
            var IdStudent =
                from IdStud in Student
                where (IdStud.surname == surname) && (IdStud.name == name) && (IdStud.fathername == fathername)
                select IdStud;
            if (IdStudent.Count() != 0)
            {
                int end = 1;
                List<int> OurStudent = new List<int>();
                OurStudent.Add(IdStudent.ElementAt(0).id);

                do
                {
                    end = OurStudent.Count();
                    OurStudent =
                               (from RedStud in Redact
                                where !OurStudent.Contains(RedStud.idStart) && OurStudent.Contains(RedStud.idFinish)
                                select RedStud.idStart).Concat(OurStudent).ToList();
                    OurStudent =
                               (from RedStud in Redact
                                where OurStudent.Contains(RedStud.idStart) && !OurStudent.Contains(RedStud.idFinish)
                                select RedStud.idFinish).Concat(OurStudent).ToList();
                } while (end != OurStudent.Count());

                var AllMarks =
                    from mark in MArks
                    where OurStudent.Contains(mark.idStudent)
                    select mark;

                foreach (var Marks in AllMarks)
                {
                    Console.WriteLine(Student[Marks.idStudent - 1].surname + " " + Student[Marks.idStudent - 1].name + " " + Student[Marks.idStudent - 1].fathername + " " + Marks.subject + " " + Marks.status + " c оценкой: " + Marks.Marks + " в сесии номер: " + Marks.numberSession);
                }
            }
            else 
            {
                Console.WriteLine("Данного студента не существует");
            }
        }
    }
}