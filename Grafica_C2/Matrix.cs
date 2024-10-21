using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafica_C2
{
    internal class Matrix
    {
        /*TODO
         * what you want :D
         */
        float[,] values;

        public static Matrix Empty;
        public int n { get { return values.GetLength(0); } }
        public int m { get { return values.GetLength(1); } }

        public Matrix(string fileName) 
        {
            string buffer;
            List<string> data = new List<string>();
            TextReader textReader = new StreamReader(fileName);
            while ((buffer = textReader.ReadLine()) != null)
                data.Add(buffer);
            textReader.Close();

            int n = data.Count;
            int m = data[0].Split(' ').Length;
            values = new float[n,m];

            for (int i = 0; i < n; i++)
            {
                string[] local = data[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    values[i,j] = float.Parse(local[j]);
                }
            }
        }

        public Matrix(int n, int m)
        {
            values = new float[n,m];
        }

        public static Matrix operator + (Matrix A, Matrix B)
        {
            if((A.n != B.n) || (A.m != B.m))  
                return Matrix.Empty;
            else
            {
                Matrix toR = new Matrix(A.n, A.m);
                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    {
                        toR.values[i, j] = A.values[i, j] + B.values[i, j];
                    }
                }
                return toR;
            }
        
        }

        public List<string> View()
        {
            List<string> toR = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string buffer = "";
                for (int j = 0; j < m; j++)
                {
                    buffer += values[i, j] + " ";
                }
                toR.Add(buffer);
            }
            return toR;
        }

        public static Matrix operator * (Matrix A, Matrix B)
        {
            if(A.m != B.n) 
                return Matrix.Empty;
            else
            {
                Matrix toR = new Matrix(A.n, B.m);
                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < B.m; j++)
                    {
                        toR.values[i, j] = 0;
                        for (int k = 0; k < A.m; k++)
                            toR.values[i, j] += A.values[i, k] * B.values[k, j];
                    }
                }
                return toR;
            }
        }
    }
}
