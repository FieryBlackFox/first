using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace findTemplate
{
    public static class FindTemplate
    {
        public static SortedSet<Border> SetOfFoundTemplates(this string str, string template)
        {
            List<string> listTemplate = ListTemplate(template);
            SortedSet<Border> Answers = new SortedSet<Border>();
            ContainsTemplate(str, listTemplate, ref Answers);
            if (template[0] == '*')
            {
                for (int i = 0; i < Answers.Count(); i++)
                {
                    for (int j = 0; j < Answers.ElementAt(i).first; j++)
                    {
                        Answers.Add(new Border(j, Answers.ElementAt(i).last));
                    }
                }
            }
            if (template[template.Length - 1] == '*')
            {
                for (int i = 0; i < Answers.Count(); i++)
                {
                    for (int j = Answers.ElementAt(i).last + 1; j < str.Count(); j++)
                    {
                        Answers.Add(new Border(Answers.ElementAt(i).first, j ));
                    }
                }
            }
            return Answers;

        }

        public static void ContainsTemplate(string str, List<string> template, ref SortedSet<Border> Answers, int PieceTempl = 0, int FirstInd = 0, int startInd = 0)
        {
            for (int i = FirstInd; i <= str.Length - template[PieceTempl].Length; i++)
            {
                if (str.Substring(i, template[PieceTempl].Length) == template[PieceTempl])
                {
                    if (PieceTempl == 0)
                    {
                        startInd = i;
                    }
                    if (PieceTempl != template.Count - 1)
                    {
                        ContainsTemplate(str, template, ref Answers, PieceTempl + 1, i + template[PieceTempl].Length, startInd);
                    }
                    else
                    {
                        Answers.Add(new Border(startInd, i + template[PieceTempl].Length - 1));
                    }
                }
            }
        }

        public static List<string> ListTemplate(string template)
        {
            string str = "";
            List<string> listTemplate = new List<string>();
            while (template.Length != 0)
            {
                if (template[0] != '*')
                {
                    str += template[0];
                    template = template.Substring(1);
                }
                else
                {
                    if (str.Length != 0)
                    {
                        listTemplate.Add(str);
                        str = "";
                    }
                    template = template.Substring(1);
                }
            }
            if (str != "")
            {
                listTemplate.Add(str);
            }
            return listTemplate;
        }
    }
}