using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perenos
{
    public partial class Program
    {
        public static bool perenos(string str, int N)
        {
            bool b = true;
            int t;//  n для подсчета занятых символов в строке
            if (n + str.Length < N - 4)// смотрим умещается ли слово на строке и можно ли перенести следующее
            {
                ch = ch.Insert(ch.Length, str);// вместо пут
                ch += " ";
                n += str.Length + 1;//увеличиваем n 
                return true;//возвращаем true
            }
            else if ((n + str.Length >= N - 4) && (n + str.Length <= N))
            {
                ch = ch.Insert(ch.Length, str);
                //ch += '\n';
                ch += Environment.NewLine;
                n = 0;//обнуляем n
                return true;//возвращаем true
            }
            else //if (n + str.Length > N)
            {
                t = N - n - 3;//элемент с которого проверяется возможность переноса
                if (t >= 0)
                {
                    while (b == true) 
                    {
                        if ((NotVoice.Contains(str[t]) == true) && (Voice.Contains(str[t + 1]) == true) && (Voice.Contains(str[t + 2]) == true) && (NotVoice.Contains(str[t + 3]) == true))
                        {
                            ch = ch.Insert(ch.Length, str.Substring(0, t + 2));
                            ch += '-';//добавляем перенос
                            ch += Environment.NewLine;
                            //ch += '&';//добавляем перевод карретки
                            str = str.Substring(t + 2, str.Length - t - 2);//уменьшаем str
                            n = 0;//обнуляем n
                            b = false;//брейкаем все
                            return perenos(str, N);//кидаем str обратно пусть укладывается
                        }
                        else if ((NotVoice.Contains(str[t]) == true) && (Voice.Contains(str[t + 1]) == true) && (NotVoice.Contains(str[t + 2]) == true))
                        {
                            ch = ch.Insert(ch.Length, str.Substring(0, t + 2));
                            ch += "-";//добавляем перенос
                            ch += Environment.NewLine;
                            // ch += '&'; ;//добавляем перевод карретки
                            str = str.Substring(t + 2, str.Length - t - 2);//уменьшаем str
                            n = 0;//обнуляем n
                            b = false;//брейкаем все
                            return perenos(str, N);//кидаем str обратно пусть укладывается
                        }
                        else//если строка не положилась
                        {
                            if (t > 0)//у нас тут еще t-шечка которую мы уменьшаем при t > 0
                            {
                                t--;//и дальше
                                n = 0;
                            }
                            else if ((t == 0) && (n != 0))//а если n!=0 переводим каретку, обнуляем n и идем дальше
                            {
                                n = 0;
                                ch += Environment.NewLine;
                                //ch += '&'; ;
                                return perenos(str, N);
                            }
                            else //if ((t == 0) && (n == 0))//но если на этом этапе t-шечка == 0 и не переносится, то если и n == 0, то возврашаем false
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
                return false;
            }
        }
    }
}