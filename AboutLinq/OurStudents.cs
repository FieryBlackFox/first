using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLinq
{
    public partial class Program
    {//оценка : ID предмет оценка статус номер сессии idстудента
        public static void GiveStudents()
        {
            Student.Add(new student(1, "Студентов", "Студент", "Студентович", 161));
            MArks.Add(new marks(1, "ООП", 5, "Сдано", 1, 1));
            MArks.Add(new marks(2, "Матан", 5, "Сдано", 1, 1));
            MArks.Add(new marks(3, "Алгебра", 4, "Не сдано", 1, 1));
            MArks.Add(new marks(4, "Матан", 4, "Сдано", 2, 1));
            MArks.Add(new marks(5, "ООП", 4, "Сдано", 2, 1));

            Student.Add(new student(2, "Фиитова", "Фиита", "Фиитовна", 161));
            MArks.Add(new marks(6, "ООП", 5, "Сдано", 1, 2));
            MArks.Add(new marks(7, "Алгебра", 4, "Сдано", 1, 2));
            MArks.Add(new marks(8, "Матан", 5, "Сдано", 1, 2));
            MArks.Add(new marks(9, "ООП", 5, "Сдано", 2, 2));

            Student.Add(new student(3, "Рандомов", "Рандом", "Рандомович", 233));
            MArks.Add(new marks(10, "ООП", 5, "Сдано", 3, 3));
            MArks.Add(new marks(11, "Алгебра", 4, "Сдано", 3, 3));
            MArks.Add(new marks(12, "Матан", 5, "Сдано", 3, 3));
            MArks.Add(new marks(13, "ООП", 5, "Сдано", 4, 3));

            Student.Add(new student(4, "Программистов", "Программист", "Программистович", 233));
            MArks.Add(new marks(14, "ООП", 5, "Сдано", 3, 4));
            MArks.Add(new marks(15, "Алгебра", 4, "Сдано", 3, 4));
            MArks.Add(new marks(16, "Матан", 5, "Сдано", 3, 4));
            MArks.Add(new marks(17, "ООП", 5, "Сдано", 4, 4));

            DateTime d = new DateTime(2014, 11, 06);
            Redact.Add(new redact(1, 1, 3, d));
        }
    }
}