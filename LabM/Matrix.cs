using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabM
{
    class Matrix
    {

        double[,] elements;

        public Matrix(double[,] matrix)
        {
            this.elements = matrix;
        }
        public Matrix(double[] vector)
        {
            elements = new double[vector.Length, 1];

            for (int i = 0; i < vector.Length; i++)
                elements[i, 0] = vector[i];
        }

        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= RowCount ||
                    j < 0 || j >= ColumnCount)
                    throw new IndexOutOfRangeException();
                return elements[i, j];
            }
            set
            {
                if (i < 0 || i >= RowCount ||
                    j < 0 || j >= ColumnCount)
                    throw new IndexOutOfRangeException();
                elements[i, j] = value;
            }
        }

        public int RowCount
        {
            get
            {
                return elements.GetLength(0);
            }
        }
        public int ColumnCount
        {
            get
            {
                return elements.GetLength(1);
            }
        }
        

        public Matrix Transpose()
        {
            double[,] transposed = new double[ColumnCount, RowCount];

            for (int i = 0; i < ColumnCount; i++)
                for (int j = 0; j < RowCount; j++)
                    transposed[i, j] = this[j, i];

            return new Matrix(transposed);
        }

        public Matrix MultiplyMatrix(Matrix matrix1, Matrix matrix2)
        {
            double[,] result = new double[matrix1.RowCount, matrix2.ColumnCount];

            int rowCount = matrix1.RowCount,
                colCount = matrix2.ColumnCount;

            int length = matrix1.ColumnCount;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    result[i, j] = 0;
                    for (int p = 0; p < length; p++)
                        result[i, j] += matrix1[i, p] * matrix2[p, j];
                }
            }

            return result;
        }
        public Matrix AddMatrix(Matrix matrix1, Matrix matrix2)
        {
            double[,] matrix = new double[matrix1.RowCount, matrix1.ColumnCount];

            for (int i = 0; i < matrix1.RowCount; i++)
                for (int j = 0; j < matrix1.ColumnCount; j++)
                    matrix[i, j] = matrix1[i, j] + matrix2[i, j];

            return matrix;
        }

        public Matrix RemoveMatrix(Matrix matrix1, Matrix matrix2)
        {
            double[,] matrix = new double[matrix1.RowCount, matrix1.ColumnCount];

            for (int i = 0; i < matrix1.RowCount; i++)
                for (int j = 0; j < matrix1.ColumnCount; j++)
                    matrix[i, j] = matrix1[i, j] - matrix2[i, j];

            return matrix;
        }

        public static explicit operator double[,](Matrix matrix)
        {
            return matrix.elements;
        }
        public static explicit operator double[](Matrix matrix)
        {
            if (matrix.RowCount != 1 &&
                matrix.ColumnCount != 1)
                throw new InvalidCastException();

            double[] result = new double[Math.Max(matrix.RowCount, matrix.ColumnCount)];
            for (int i = 0; i < result.Length; i++)
                if (matrix.RowCount > 1)
                {
                    result[i] = matrix[i, 0];
                }
                else
                {
                    result[i] = matrix[0, i];
                }

            return result;
        }
        public static implicit operator Matrix(double[,] elements)
        {
            return new Matrix(elements);
        }
        public static implicit operator Matrix(double[] elements)
        {
            return new Matrix(elements);
        }
    }
}
