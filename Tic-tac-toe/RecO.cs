using System.Linq;

namespace KrestikiNoliki
{
    public partial class Program
    {
        static void recO(int coun)//coun число оставшихся вопросов
        {
            int ind1, ind2;
            if (coun <= 0)//останов рекурсии, для этого требуется проверять наличие вопросов
            {
                vin['N']++;//победа недостигнута
            }
            else
            {
                for (int i = 0; i < count.Count(); i++)//пройтись по массиву ? 
                {
                    if (count[i][0] != -1)
                    {
                        mass[count[i][0], count[i][1]] = 'O'; // поставить в какой-то нолик и вызвать проверку победы
                        //Print();
                        ind1 = count[i][0];
                        ind2 = count[i][1];
                        count[i][0] = -1;
                        count[i][1] = -1;
                        coun--;

                        if (pobeda() == true)
                        {
                            mass[ind1, ind2] = '?';
                            count[i][0] = ind1;
                            count[i][1] = ind2;
                            coun++;
                        }
                        else
                        {
                            recX(coun);// если не победа то вызвать рекурс для Х
                            mass[ind1, ind2] = '?';
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