using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        public class Matrix
        {
            public double[,] matrix;
            public int Row = 0, Col = 0;
            //конструктор
            public Matrix(int row, int col)
            {
                matrix = new double[row, col];
                Row = row; Col = col;
                d1 = row;
                d2 = col;
            }

            //доступ к элементу по индексам
            public double this[int i, int j]//индексатор
            {
                get { return matrix[i, j]; }
                set { matrix[i, j] = value; }
            }

            // возвращает массив соответствующий указанной строке матрицы
            public double[] GetRow(int row)
            {
                if (row >= Row) throw new IndexOutOfRangeException("Индекс строки не принадлежит массиву.");
                double[] ret = new double[Col];
                for (int i = 0; i < Col; i++)
                    ret[i] = matrix[row, i];

                return ret;
            }
            // заполняет указанную строку матрицы значениями из массива
            public void SetRow(double[] values, int row)
            {
                if (row >= Row) throw new IndexOutOfRangeException("Индекс строки не принадлежит массиву.");
                for (int i = 0; i < (Col > values.Length ? values.Length : Col); i++)
                    matrix[row, i] = values[i];
            }

            double[] SubArray(double[] A, double[] B)
            {
                double[] ret = (double[])A.Clone();
                for (int i = 0; i < (A.Length > B.Length ? A.Length : B.Length); i++)
                    ret[i] -= B[i];
                return ret;
            }

            double[] MulArrayConst(double[] array, double number)
            {
                double[] ret = (double[])array.Clone();
                for (int i = 0; i < ret.Length; i++)
                    ret[i] *= number;
                return ret;
            }

            //вывод матрицы
            public void PrintMatrix()
            {
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                        Console.Write("{0}  ", this[i, j]);
                    Console.Write("\n");
                }

            }
            private int d1;//объект динам. метода
            private int d2;//объект динам. метода
            public void din1()//динамический метод
            {
                Console.WriteLine("Я динамический метод класса Matrix");
                Console.WriteLine("Мои поля {0},{1}", d1, d2);
            }
            public static void stat1()//статический метод 
            {
                Console.WriteLine("Я статический метод класса Matrix");
            }
        }
        class Matrix_1 : Matrix
        {

            public Matrix_1(int row, int col) : base(row, col) { }
            //возведение в степень
            public static Matrix operator ^(Matrix_1 first, int pow)
            {
                Matrix matr = new Matrix(first.Row, first.Col);
                matr = first;
                for (int z = 1; z < pow; z++)
                {
                    Matrix bufer = new Matrix(first.Row, first.Col);
                    for (int i = 0; i < first.Row; i++)
                    {
                        for (int j = 0; j < first.Row; j++)
                        {
                            double sum = 0;
                            for (int r = 0; r < first.Row; r++)
                                sum += matr[i, r] * first[r, j];
                            bufer[i, j] = sum;
                        }
                    }
                    matr = bufer;
                }
                return matr;
            }

        }
        class client//подкласс
        {
            public client(int row, int col)//конструктор
            {
                owner = new Matrix(row, col);
            }
            Matrix owner;

            static void Main(string[] args)
            {
                Console.WriteLine("Введите размерность первой матрицы:\n");
                int N = Convert.ToInt32(Console.ReadLine());
                int M = Convert.ToInt32(Console.ReadLine());
                Matrix_1 first = new Matrix_1(N, M);//обьект класса
                Console.WriteLine("Введите элементы матрицы:\n");
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                    {
                        first[i, j] = double.Parse(Console.ReadLine());

                    }
                Console.WriteLine("Введите размерность второй матрицы:\n");
                int K = Convert.ToInt32(Console.ReadLine());
                int L = Convert.ToInt32(Console.ReadLine());
                Matrix second = new Matrix(K, L);//обьект класса
                Console.WriteLine("Введите элементы матрицы:\n");
                for (int i = 0; i < K; i++)
                    for (int j = 0; j < L; j++)
                    {
                        second[i, j] = double.Parse(Console.ReadLine());

                    }
                Console.WriteLine("Введите степень:\n");
                int pow = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Первая матрица:\n\n");
                first.PrintMatrix();
                Console.WriteLine("\n\nВторая матрица:\n\n");
                second.PrintMatrix();
                Console.ReadKey();
            }
        }
    }
}