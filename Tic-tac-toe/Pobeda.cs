
namespace KrestikiNoliki
{
    public partial class Program
    {
        static bool pobeda()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((mass[i, 0] == mass[i, 1]) && (mass[i, 1] == mass[i, 2]) && ((mass[i,0] == 'X') || (mass[i,0] == 'O')))
                {
                    vin[mass[i,0]] ++;
                    return true;
                }
                else if ((mass[0, i] == mass[1, i]) && (mass[1, i] == mass[2, i]) && ((mass[0, i] == 'X') || (mass[0, i] == 'O')))
                {
                    vin[mass[0, i]] ++;
                    return true;
                }
            }
            if (((mass[0, 0] == mass[1, 1] && mass[1, 1] == mass[2, 2]) || (mass[0, 2] == mass[1, 1] && mass[1, 1] == mass[2, 0])) && ((mass[1, 1] == 'X') || (mass[1, 1] == 'O')))
            {
                vin[mass[1, 1]] ++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}