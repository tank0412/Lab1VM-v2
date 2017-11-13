using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1VM_v2
{
    class Program
    {
        public static double[,] Digits = new double[20, 20];
        public static int Size = 0;
        public static Double Tochnost = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер");
            Size = Convert.ToInt32(Console.ReadLine());
            //i - СТРОКИ
            // J - СТОЛБЦЫ
            Console.WriteLine("Введите матрицу");
            for (int i = 0; i < Size; ++i) {
                for (int j = 0; j < Size + 1; ++j)
                {
                    Digits[i, j] = Convert.ToInt32(Console.ReadLine());
                }
             }
            Console.WriteLine("Введите погрешность");
            Tochnost = Convert.ToDouble(Console.ReadLine());
            DoJob.Do();


        }
    }
    class DoJob
    {
        public static double[] PreviousX = new double[20];
        public static double[] NextX = new double[20];
        public static int Iterations = 0;
        public static void Do() {
            Console.WriteLine("TODO: DoJob.Do()");
            diagonalDominating();
            for (int i = 0; i < Program.Size; ++i)
            {
                PreviousX[i] = 0;
                NextX[i] = 0;
            }

            while (true) {
                // if () break;
                Iterations++;

                if (Iterations % 2 != 0)
                {
                    //NextX[0] = (Program.Digits[0, Program.Size] + (-1) * Program.Digits[0, 1] * PreviousX[1] + (-1) * Program.Digits[0, 2] * PreviousX[2]) / Program.Digits[0, 0];
                    for (int i = 1; i < Program.Size; ++i)
                    {
                        NextX[i] += Program.Digits[i, Program.Size];
                        for (int j = 1; j < Program.Size; ++j) {
                            NextX[i] += Program.Digits[i, j] * PreviousX[1];
                        }
                        NextX[i] /= Program.Digits[i, 0];
                    }
                }
                else
                {
                    //PreviousX[0] = (Program.Digits[0, Program.Size] + (-1) * Program.Digits[0, 1] * NextX[1] + (-1) * Program.Digits[0, 2] * NextX[2]) / Program.Digits[0, 0];
                    for (int i = 1; i < Program.Size; ++i)
                    {
                        PreviousX[i] += Program.Digits[i, Program.Size];
                        for (int j = 1; j < Program.Size; ++j)
                        {
                            PreviousX[i] += Program.Digits[i, j] * NextX[1];
                        }
                        PreviousX[i] /= Program.Digits[i, 0];
                    }
                }

            }


        }

        public static bool diagonalDominating()
        {
            double sum = 0;

            for (int i = 0; i < Program.Size; i++)
                for (int j = 0; j < Program.Size + 1; j++)
                    if (i != j)
                        sum += Math.Abs(Program.Digits[i, j]);


            for (int i = 0; i < Program.Size; i++)
                if (Math.Abs(Program.Digits[i, i]) < sum)
                {
                    Console.WriteLine("Диагональное преобладание ОТСУТСТВУЕТ");
                    Console.WriteLine(Math.Abs(Program.Digits[i, i]));
                    Console.WriteLine(sum);
                    return false;
                }
            Console.WriteLine("Диагональное преобладание ПРИСУТСТВУЕТ");
            return true;
        }
    }
}
