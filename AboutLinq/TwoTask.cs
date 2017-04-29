using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLinq
{
    public partial class Program
    {
        public static bool TaskTwo(int Number, int Group)
        {
            var StudGroupsWeNeed =
                from Stud in Student
                where Stud.groop == Group
                select Stud;

            foreach (var Stud in StudGroupsWeNeed)
            {
                var ConsistMark =
                    from Mark in MArks
                    where (Mark.idStudent == Stud.id && Mark.numberSession == Number && Mark.subject == "Алгебра")
                    select Mark;
                if (ConsistMark.Count() == 0)
                {
                    return false;
                }
                if (ConsistMark.ElementAt(0).status == "Не сдано")
                {
                    return false;
                }
            }
            return true;
        }
    }
}