using System.Linq;

namespace KrestikiNoliki
{
    public partial class Program
    { 
        static void recX(int coun)//coun число оставшихся вопросов
        {
            int ind1, ind2;
            if(coun <= 0)//останов рекурсии, для этого требуется проверять наличие вопросов
            {
                vin['N'] ++;//победа не достигнута
                //Print();
                //Console.WriteLine("__________________");
            }
            else
            {
                for (int i = 0; i < count.Count(); i++)//пройтись по массиву ? 
                {
                    if (count[i][0] != -1)
                    {
                        mass[count[i][0], count[i][1]] = 'X';// поставить в какой-то крестик и вызвать проверку победы
                        //Print();
                        ind1 = count[i][0];
                        ind2 = count[i][1];
                        count[i][0] = -1;
                        count[i][1] = -1;
                        coun--;

                        if (pobeda() == true)
                        {
                            mass[ind1, ind2] = '?';
                            //Console.WriteLine("_________________");
                            //Console.WriteLine("_________________");
                            //Print();
                            count[i][0] = ind1;
                            count[i][1] = ind2;
                            coun++;
                        }
                        else
                        {
                            recO(coun);// если не победа и есть вопросы, то вызвать рекурс для 0 с уменьшением кол-ва свободных
                            mass[ind1, ind2] = '?';
                            //Print();
                            count[i][0] = ind1;
                            count[i][1] = ind2;
                            coun++;
                        }
                    }
                }
            }
        }
    }
}