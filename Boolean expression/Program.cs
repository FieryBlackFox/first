using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Search7
{
    public class Program
    {
        static private List<string> vyr;//логическое выражение
        static private List<bool> Variables;//лист перебираемых переменных до N, с N для подсчитанных временных выражений
        static private string[] str;
        static private bool b = false;
        public Program()
        {
            vyr = new List<string>();
            Variables = new List<bool>();
            b=false;
        }
        static void Main(string[] args)
        {
            int N=Convert.ToInt32(Console.ReadLine());
            
            str = Console.ReadLine().Split();
            Program p = new Program();
            p.Search(str, N);
            if (b == true)
            {
                Console.WriteLine("true");
            }
            else 
            {
                Console.WriteLine("false");
            }

            Console.ReadKey();
            
        }
        public bool Search(string[] strt, int N)
        {
            str = strt;
            vyr = new List<string>(str);
            Variables = new List<bool>();//лист перебираемых переменных до N, с N для подсчитанных временных выражений

            for(int i=0; i<N; i++)
            {
                Variables.Add(false);
            }

            recSearch(N - 1);
            return b;
        }

        static void recSearch(int N)
        {
            if (N == -1)
            {
                vyr = new List<string>(str);
                recParentheses(0);
                if (Variables[Convert.ToInt32(vyr[0])] == true)
                {
                    b = true;
                    return;
                }
            }
            else 
            {
                Variables[N] = true;
                recSearch(N - 1);
                Variables[N] = false;
                recSearch(N - 1);
            }
            
        }

        static void recParentheses(int nBegin)//сюда будут подаваться индексы первого элемента
        {
            if (vyr.Count() > 1)
            {
                if (vyr.Contains("("))//если выражение содержит открывающуюся скобку
                {
                    int nEnd;
                    nBegin = vyr.LastIndexOf("(");//индекс начала, это последняя открывающаяся
                    vyr.RemoveAt(nBegin);//удаляем ее
                    nEnd = vyr.IndexOf(")", nBegin);//индекс конца, это первая закрывающаяся после открывающейся
                    vyr.RemoveAt(nEnd);//удаляем ее
                    nEnd -= 2;//переносим индекс конца на конец получившегося выражения
                    recNOT(nBegin, nEnd);//отправляем конечное выражение в рекурсию по NOT
                }
                else
                {
                    recNOT(0, vyr.Count() - 1);//отправляем первоначальное выражение в рекурсию по NOT
                }
            }
        }

        static void recNOT(int nBegin, int nEnd)
        {
            if (vyr.Count() > 1)
            {
                if (vyr.IndexOf("not", nBegin, nEnd - nBegin + 1) != -1)
                {
                    int nNot = vyr.LastIndexOf("not", nEnd, nEnd - nBegin + 1);//индекс оператора not
                    vyr.RemoveAt(nNot);//удаляем его
                    nEnd--;//переносим индекс конца на конец получившегося выражения
                    Variables.Add(!Variables[Convert.ToInt32(vyr[nNot])]);//добавляем значение получившееся отрицанием переменной в лист
                    vyr[nNot] = Convert.ToString(Variables.Count() - 1);//меняем номер используемой переменной в выражении
                    
                    recNOT(nBegin, nEnd);//продолжаем рекурсию по NOT
                }
                else
                {
                    recAnd(nBegin, nEnd);//отправляем конечное выражение в рекурсию по AND
                }
            }
        }

        static void recAnd(int nBegin, int nEnd)
        {
            if (vyr.Count() > 1)
            {
                if (vyr.IndexOf("and", nBegin, nEnd - nBegin + 1) != -1)
                {
                    int nAnd = vyr.IndexOf("and", nBegin, nEnd - nBegin + 1);//индекс оператора AND
                    vyr.RemoveAt(nAnd);//удаляем его
                    nEnd--;//переносим индекс конца на конец получившегося выражения
                    Variables.Add(Variables[Convert.ToInt32(vyr[nAnd - 1])] && Variables[Convert.ToInt32(vyr[nAnd])]);//добавляем в лист значение получившееся операцией AND
                    vyr.RemoveAt(nAnd);//удаляем второй множитель
                    nEnd--;//переносим индекс конца на конец получившегося выражения
                    vyr[nAnd - 1] = Convert.ToString(Variables.Count() - 1);//меняем номер используемой переменной в выражении

                    recAnd(nBegin, nEnd);//продолжаем рекурсию по AND
                }
                else
                {
                    recOr(nBegin, nEnd);//отправляем конечное выражение в рекурсию по OR
                }
            }
        }

        static void recOr(int nBegin, int nEnd)
        {
            if (vyr.Count() > 1)
            {
                if (vyr.IndexOf("or", nBegin, nEnd - nBegin + 1) != -1)
                {
                    int nOr = vyr.IndexOf("or", nBegin, nEnd - nBegin + 1);//индекс оператора OR
                    vyr.RemoveAt(nOr);//удаляем его
                    nEnd--;//переносим индекс конца на конец получившегося выражения
                    Variables.Add(Variables[Convert.ToInt32(vyr[nOr - 1])] || Variables[Convert.ToInt32(vyr[nOr])]);//добавляем в лист значение получившееся операцией OR
                    vyr.RemoveAt(nOr);//удаляем второе слагаемое
                    nEnd--;//переносим индекс конца на конец получившегося выражения
                    vyr[nOr - 1] = Convert.ToString(Variables.Count() - 1);//меняем номер используемой переменной в выражении

                    recOr(nBegin, nEnd);//продолжаем рекурсию по OR
                }
                else
                {
                    recParentheses(0);//возвращение к скобкам
                }
            }
        }
    }
}