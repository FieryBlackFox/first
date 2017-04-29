using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLinq
{
    public partial class Program
    {
        public static bool TaskTwo1(int Number, int Group)
        { 
            var StudentOurGroup = 
                from Stud in Student//список студентов нужной группы
                where (Stud.groop == Group)
                select Stud;
            var Start =
                from Red in Redact
                select Red.idStart;
            var Finish =
                from Red in Redact
                select Red.idFinish;

            bool cont = true;
            int i;
            List<student> NeedStudent = new List<student>();//список студентов которые были в данной группе в данную сессию
            foreach (var stud in StudentOurGroup)//проходим по списку студентов
            {
                var stude1 = stud;//сохраняем студента
                while (Finish.Contains(stude1.id))//если были изменения (проверяем кем был)
                {
                    i = 0;
                    while (Finish.ElementAt(i) != stude1.id) i++;//ищем индекс
                    stude1 = Student.ElementAt(Start.ElementAt(i) - 1);
                    var MarkStud = 
                        from mark in MArks
                        where mark.idStudent == stude1.id
                        select mark;// и возвращаем его оценки
                    if (MarkStud.ElementAt(0).numberSession == Number && stude1.groop != Group)// если студент почему-то перевелся, он не в группе, но та сессия
                    {
                        cont = false;
                        break;
                    }
                }
                if (cont)// если он не в группе и у него та сессия, заново
                {
                    stude1 = stud; 
                    while (Start.Contains(stude1.id))// проверяем кто он был или есть
                    {
                        i = 0;
                        while (Start.ElementAt(i) != stude1.id) i++;
                        stude1 = Student.ElementAt(Finish.ElementAt(i) - 1);
                        var MarkStud =
                            from mark in MArks
                            where mark.idStudent == stude1.id
                            select mark;// и возвращаем его оценки
                        if (MarkStud.ElementAt(0).numberSession == Number && stude1.groop != Group)// если студент почему-то перевелся он не в группе, но та сессия
                        {
                            cont = false;
                            break;
                        }
                    }
                }
                if (cont)//если до сих пор все норм добавим именно его единоличного непереведенного студента
                {
                    NeedStudent.Add(stud);
                }
            }

            List<string> ALLsubject = new List<string>();//создаем список предметов

            foreach (var marks in MArks) //проходим по оценкам и выясняем те где группа и номер совпадают
            {
                if (Student.ElementAt(marks.idStudent - 1).groop == Group && marks.numberSession == Number) 
                {
                    ALLsubject.Add(marks.subject);// добавляем этот предмет
                    if (marks.status == "Не сдано") {// если не сдано
                        return false;
                    }
                }
            }
            
            var AllOneSubject = ALLsubject.Distinct();//возвращает неповторяющиеся элементы
            int subjectINT = AllOneSubject.Count();//узнаем кол-во предметов

            int INT;
            foreach (var stud in NeedStudent)// и используем всех студентов которые были в этой группе в эту сессию
            {
                INT = 0;
                foreach (var mark in MArks) 
                {
                    if (mark.idStudent == stud.id && mark.numberSession == Number) INT++;// и подсчитываем его предметы
                }
                
                if (INT != subjectINT) //студент сдавал не все предметы
                {
                    return false;
                }
            }

            return true;
        }
    }
}