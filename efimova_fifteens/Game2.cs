using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteens_2_3
{
    class Game2 : Game
    {
        public Game2(params int[] values) : base(values) { }


        protected void Randomize()
        {
            Random gen = new Random();
            int[] values = new int[Field.Length];
            for (int i = 0; i < values.GetLength(0); i++)
            {
                if (i != values.Length - 1)
                {
                    values[i] = i + 1;
                }
            }
            int index = 0;

            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    index = gen.Next(0, Field.Length);
                    for (int k = 0; k < Field.Length; k++)
                    {
                        while ((values[index] == values[k]) && (values[index] == Int32.MaxValue))
                        {
                            index = gen.Next(0, values.Length);
                        }
                    }
                    Field[i, j] = values[index];
                    values[index] = Int32.MaxValue;
                }
            }
        }

        public bool YouAreWin()
        {
            bool state = true;
            int[] t = new int[Field.Length];
            int temp = 0;
            foreach (var i in Field)
            {
                t[temp] = i;
                temp++;
            }
            for (int i = 0; i < t.Length - 1; i++)
            {
                if ((i != t.Length - 2) && (t[i] > t[i + 1]))
                {
                    state = false;
                }
                if (t[t.Length - 1] != 0)
                {
                    state = false;
                }
            }
            return state;
        }

    }
}
