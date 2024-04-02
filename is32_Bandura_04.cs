using System;

static class ExtensionMethods
{
    public static void PrintMatrix(this Matrix arr)
    {
        for (int i = 0; i < arr.GetMatrix.GetLength(1); i++)
        {
            for (int j = 0; j < arr.GetMatrix.GetLength(0); j++)
            {
                Console.Write(arr.GetMatrix[i, j] + ", ");
            }

            Console.WriteLine();
        }
    }

    public static void PrintIntList(this List<int> list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ,");
        }
    }
}

class Matrix
{
    private byte[,] matrix;
    private List<int> visited = new List<int>();

    public Matrix (int size)
    {
        matrix = new byte[size, size];
    }

    public void MatrixInitialisation(string initialisationMethod, Random random)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (i > j)
                {
                    matrix[i, j] = matrix[j, i];
                }
                else
                {
                    switch (initialisationMethod)
                    {
                        case "k":
                            Console.Write($"Element {i}{j}: ");
                            byte value;
                            if (byte.TryParse(Console.ReadLine(), out value))
                            {
                                matrix[i, j] = value;
                            }
                            break;

                        case "r":
                            matrix[i, j] = (byte)random.Next(0, 2);
                            break;

                        default:
                            Console.WriteLine("smth went wrong...");
                            break;
                    }
                }
            }
        }
    }

    public void DFSRealisation(int vertix)
    {
        if (!visited.Contains(vertix))
        {
            visited.Add(vertix);
            Console.Write(vertix + " ,");
            for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
            {
                if (matrix[vertix - 1, i] == 1)
                {
                    matrix[vertix - 1, i] = 0;
                    matrix[i, vertix - 1] = 0;
                    DFSRealisation(i + 1);
                }
            }
        }
    }

    public byte[,] GetMatrix { get => matrix; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Amount of graph vertices: ");
        int amount = int.Parse(Console.ReadLine());
        Matrix matrix = new Matrix(amount);

        Console.Write("(r)andom or (k)eyboard: ");
        string matrixInitialisationMethod = Console.ReadLine();

        Random random = new Random();
        matrix.MatrixInitialisation(matrixInitialisationMethod, random);

        matrix.PrintMatrix();

        Console.Write("1st vertix: ");
        string startVertix = Console.ReadLine();

        Console.WriteLine();
        matrix.DFSRealisation(int.Parse(startVertix));
    }
}
