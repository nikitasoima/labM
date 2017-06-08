using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabM
{
    class Program
    {
        static void Main(string[] args)
        {
               Matrix Matrix1 =  new Matrix(new double[,] {  { 12, 2, -3 }, 
                                                             { -9, 9, 11 }, 
                                                             { 0, -2, 14 }});

               Matrix Matrix2 = new Matrix(new double[,] {  { 1, 5, 7 }, 
                                                             { -7, 2, 8 }, 
                                                             { -2, -1,4 } });

               Matrix Matrix3 = new Matrix(new double[,] {  { 0, 0, 0 }, 
                                                             { 0, 0, 0 }, 
                                                             { 0, 0, 0 } });

               Console.WriteLine("1 - Сложить матрицы" + "\n" + "2 - Отнять матрицы" + "\n" + "3 - Умножить матрицы" + "\n" + "4 - Транспонировать матрицу");
               Console.Write("Введите команду: ");
               int command = Convert.ToInt32(Console.ReadLine());

               switch (command)
               {
                   case 1:

                       Matrix mAdd = Matrix3.AddMatrix(Matrix1, Matrix2);
                       for (int i = 0; i < 3; i++)
                       {
                           for (int j = 0; j < 3; j++)
                           {
                               Console.Write(mAdd[i, j] + " ");
                           }
                           Console.WriteLine();

                       }
                       break;
                   case 2:
                       Matrix mRemove = Matrix3.RemoveMatrix(Matrix1, Matrix2);
                       for (int i = 0; i < 3; i++)
                       {
                           for (int j = 0; j < 3; j++)
                           {
                               Console.Write(mRemove[i, j] + " ");
                           }
                           Console.WriteLine();

                       }

                       break;
                   case 3:
                       Matrix mMulti = Matrix3.MultiplyMatrix(Matrix1, Matrix2);
                       for (int i = 0; i < 3; i++)
                       {
                           for (int j = 0; j < 3; j++)
                           {
                               Console.Write(mMulti[i, j] + " ");
                           }
                           Console.WriteLine();
                       }
                       break;
                   case 4:
                       Matrix matrix = Matrix1.Transpose();

                       for (int i = 0; i < 3; i++)
                       {
                           for (int j = 0; j < 3; j++)
                           {
                               Console.Write(matrix[i, j] + " ");
                           }
                           Console.WriteLine();
                       }
                       break;
               }

               Console.ReadKey();
        }
    }
}
