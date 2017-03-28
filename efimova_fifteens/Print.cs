using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteens_2_3
{
    class Print
    {
        public static void Printing(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write("{0}\t", field[i, j]);

                }
                Console.WriteLine();
            }
        }
    }
}
