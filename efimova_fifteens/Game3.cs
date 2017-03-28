using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteens_2_3
{
    class Game3 : Game2
    {
        private List<int> history;

        public Game3(params int[] values) : base(values)
        {
            history = new List<int>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            history.Add(value);
        }


        public void RollBack(int count)
        {
            if (count > history.Count)
                throw new ArgumentException("Некорректное количество шагов");

            int lastMove = 0;
            for (int i = 0; i < count; i++)
            {
                lastMove = history.Last();
                history.Remove(lastMove);
                base.Shift(lastMove);
            }
        }


        public void PrintHistory()
        {
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine("Ход {0}, костяшка {1}", i + 1, history[i]);
            }
        }
    }
}
