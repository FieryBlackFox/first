using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLinq
{
    public partial class Program
    {
        private static List<marks> MArks = new List<marks>();
        private static List<student> Student = new List<student>();
        private static List<redact> Redact = new List<redact>();
        static void Main(string[] args)
        {
            GiveStudents();
            

            //1
            Console.WriteLine("1  Вывести все оценки студента: ");
            string name, surname, fathername;
            Console.WriteLine("Введите ФИО студента: ");
            string[] str = Console.ReadLine().Split();
            surname = str[0];
            name = str[1];
            fathername = str[2];

            TaskOne(surname, name, fathername);
            Console.WriteLine();
            //

            //1*
            Console.WriteLine("1*  Вывести все оценки студента с учетом изменений: ");
            Console.WriteLine("Введите ФИО студента: ");
            str = Console.ReadLine().Split();
            surname = str[0];
            name = str[1];
            fathername = str[2];

            TaskOne1(surname, name, fathername);
            Console.WriteLine();
            //

            //2
            Console.WriteLine("2  Узнать сдала ли группа Алгебру в нужную сессию: ");
            Console.WriteLine("Введите номер сессии: ");
            int Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер группы: ");
            int Group = Convert.ToInt32(Console.ReadLine());

            if (TaskTwo(Number, Group) == true)
            {
                Console.WriteLine("Группа номер {0} сдала алгебру в {1} сессии успешно", Group, Number);
            }
            else 
            {
                Console.WriteLine("Группа номер {0} не сдала алгебру в {1} сессии", Group, Number);
            }
            Console.WriteLine();
            //
            
            //2*
            Console.WriteLine("2*  Узнать сдала ли группа всю сессию: ");
            Console.WriteLine("Введите номер сессии: ");
            Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер группы: ");
            Group = Convert.ToInt32(Console.ReadLine());

            if (TaskTwo1(Number, Group) == true)
            {
                Console.WriteLine("Группа номер {0} сдала сессию номер {1} успешно", Group, Number);
            }
            else
            {
                Console.WriteLine("Группа номер {0} не сдала сессию номер {1}", Group, Number);
            }
            Console.WriteLine();
            //
            Console.ReadKey();            
        }
    }
    class student
    {
        public int id;
        public string surname;
        public string name;
        public string fathername;
        public int groop;
        public student(int id, string surname, string name, string fathername, int groop)
        { 
            this.id = id;
            this.surname = surname;
            this.name = name;
            this.fathername = fathername;
            this.groop = groop;
        }
    }
    
    class marks
    { 
        public int idMarks;
        public string subject;
        public int Marks;
        public string status;
        public int numberSession;
        public int idStudent;
        public marks(int idMarks, string subject, int Marks, string status, int numberSession, int idStudent)
        { 
            this.idMarks = idMarks;
            this.subject = subject;
            this.Marks = Marks;
            this.status = status;
            this.numberSession = numberSession;
            this.idStudent = idStudent;
        }
    }

    class redact
    {
        public int idRedact;
        public int idStart;
        public int idFinish;
        public DateTime date;
        public redact(int idRedact, int idStart, int idFinish, DateTime date)
        {
            this.idRedact = idRedact;
            this.idStart = idStart;
            this.idFinish = idFinish;
            this.date = date;
        }
    }
}