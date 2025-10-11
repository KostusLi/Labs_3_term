using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Matrix
{
    public int M { get; private set; }
    public int N { get; private set; }
    public int[][] matrix { get; set; }
    public string name { get; set; }

    public Matrix(int m, int n, string name)
    {
        M = m;
        N = n;
        this.name = name;

        matrix = new int[m][];
        for (int i = 0; i < m; i++)
            matrix[i] = new int[n];
    }

    public int this[int i, int j]
    {
        get => matrix[i][j];
        set => matrix[i][j] = value;
    }

    public override string ToString()
    {
        string str = "";

        for(int i=0; i<M; i++)
        {
            for(int j=0; j<N; j++)
            {
                str += this.matrix[i][j]+" ";
            }
            str += '\n';
        }

        return $"Matrix \"{name}\" ({M}x{N}):\n{str}";
    }
}
