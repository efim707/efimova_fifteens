using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteens_2_3
{
    class Game
    {
        public readonly int[,] Field; //
        protected int size;
        protected Point[] points;

        public int Length { get { return size; } }

        protected Game(params int[] values)
        {
            this.CheckRestriction(values);


            size = (int)Math.Sqrt(values.Length); // инициализация
            Field = new int[size, size];
            points = new Point[values.Length];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int value = values[i * size + j];
                    Field[i, j] = value;
                    points[value] = new Point(j, i);
                }
            }
        }

        public int this[int x, int y] //индексатор- доступ к элементам по их индексу
        {
            get
            {
                return Field[x, y];
            }
        }

        protected Point GetLocation(int value) // метод, возвращающий месторасположение 
        {
            try
            {
                return points[value];
            }
            catch
            {
                throw new Exception("Такого значения нет в игре");
            }
        }

        protected void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        protected void swap(ref Point a, ref Point b)
        {
            Point t = a;
            a = b;
            b = t;
        }

        public virtual void Shift(int value) //передвижение 
        {
            Point locV = GetLocation(value);
            Point loc0 = GetLocation(0);

            if (!((locV.X == loc0.X || locV.Y == loc0.Y)
                && Math.Abs(locV.X - loc0.X) <= 1
                && Math.Abs(locV.Y - loc0.Y) <= 1))
            {
                throw new Exception("Эту фишку нельзя перемещать");
            }

            swap(ref Field[locV.Y, locV.X], ref Field[loc0.Y, loc0.X]);
            swap(ref points[0], ref points[value]);
        }



        protected void CheckRestriction(params int[] values) // Проверка ограничений
        {
            if (Math.Sqrt(values.Length) != (int)Math.Sqrt(values.Length))
            {
                throw new ArgumentException("Передано число параметров, не являщееся квадратом целого числа");
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < 0) throw new ArgumentException("В массиве не может быть отрицательных чисел");
            }

            int[] copy = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                copy[i] = values[i];
            }
            Array.Sort(copy);

            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i] != i) throw new ArgumentException("Исходный массив содержит повторяющиеся числа");
            }
        }

    }
}

