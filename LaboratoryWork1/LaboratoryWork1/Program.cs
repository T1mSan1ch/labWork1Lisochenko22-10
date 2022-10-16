using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Formatters;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

// в целом про девятый пункт, насколько дотошно его дделать

namespace spaghetticode
{
    class JustAClass
    {
        public static void Main()
        {
            Console.WriteLine("Это лабораторная работа №1. \nТут представлено решение 9 задачь.\nЗадания 1-5 и 9 в виде функций");
            while (true)
            {
                Console.WriteLine("Чтобы увидеть решение нужной задачи \nпередай в консоль TaskN, \nгде N нужный номер.");
                string task = Console.ReadLine();
            
                switch (task)
                {
                    case "Task1":
                        TaskOne();
                        break;
                    case "Task2":
                        TaskTwo();
                        break;
                    case "Task3":
                        TaskThree();
                        break;
                    case "Task4":
                        TaskFour();
                        break;
                    case "Task5":
                        TaskFive();
                        break;
                    case "Task9":
                        TaskNine();
                        break;
                    default:
                        Console.WriteLine("Неверный формат ввода");
                        break;
                }
            }
        }
        public static void TaskOne()
        {
            Console.WriteLine("Ввыберите формат ввода файла(file/keyboard)");
            string choise = Console.ReadLine();
            int[] array;
            if (choise == "file")
                array = ReadFileArr();
            else
                array = InputArray();
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }
        public static void TaskTwo()
        {
            Console.WriteLine("Этот массив будет отсортирован и будут выведены Min и Max значения");
            int[] array = InputArray();
            array = Sortirovka(array);

            Console.Write("Минимальное: ");
            var min = int.MaxValue;
            foreach (var item in array)
                if (item < min) min = item;
            int indOfMin = Array.IndexOf(array, min);
            Console.WriteLine($"Значение {min}, индекс {indOfMin}");

            Console.Write("Максимальное: ");
            var max = int.MinValue;
            foreach (var item in array)
                if (item > max) max = item;
            int indOfMax = Array.IndexOf(array, max);
            Console.WriteLine($"Значение {max}, индекс {indOfMax}");

            string mas = "";
            int lengthOfArray = array.Length;
            for (int i = 0; i < lengthOfArray; i++)
                mas = mas + Convert.ToInt64(array[i])+ " ";
            //это строка должна выводиться по условию

            Console.WriteLine("Отсортированный массив: " + mas);
        }
        public static void TaskThree()
        {
            Console.WriteLine("Ввыберите формат ввода файла(file/keyboard)");
            string choise = Console.ReadLine();
            int[,] matrix;
            if (choise == "file")
                matrix = ReadFileMat();
            else
                matrix = InputMatrix(); 
            int rows = matrix.GetUpperBound(0) + 1;    // количество строк
            int columns = matrix.Length / rows;        // количество столбцов
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        public static void TaskFour()
        {
            int[,] matrix = InputMatrix();

            int rows = matrix.GetUpperBound(0) + 1;    // количество строк
            int columns = matrix.Length / rows;        // количество столбцов

            int iMaxIndex = 0;
            int jMaxIndex = 0;
            int iMinIndex = rows;
            int jMinIndex = columns;

            int maxOfMatrix = int.MinValue;
            int minOfMatrix = int.MaxValue;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > maxOfMatrix)
                    {
                        maxOfMatrix = matrix[i, j];
                        iMaxIndex = i;
                        jMaxIndex = j;
                    }
                    else if (matrix[i, j] < minOfMatrix)
                    {
                        minOfMatrix = matrix[i, j];
                        iMinIndex = i;
                        jMinIndex = j;
                    }
                }
            }
            Console.WriteLine($"Максимальный элемент массива {maxOfMatrix}и его индекс [{iMaxIndex},{jMaxIndex}]");
            Console.WriteLine($"Минимальный элемент массива {minOfMatrix}и его индекс [{iMinIndex},{jMinIndex}]");
        }
        public static void TaskFive()
        {
            Console.WriteLine("Ввыберите формат ввода файла(file/keyboard)");
            string choise = Console.ReadLine();
            int[][] numbers;
            if (choise == "file")
                numbers = ReadFileJagArr();
            else
                numbers = JaggedArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
                Console.WriteLine();
            }
        }
        public static void TaskNine()
        {
            int[] array = InputArray();
            var random = new Random();
            array[random.Next(array.Length)] = random.Next();
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }
        public static int[] InputArray()
        {
            Console.WriteLine("Введите длину массива");
            int lengthOfArray1 = 0;
            while((Int32.TryParse(Console.ReadLine(), out lengthOfArray1)) != true)
            {
                Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
            }
            int[] array = new int[lengthOfArray1];
            int temporaryNuber = lengthOfArray1 + 1;
            Console.WriteLine("Вводите элементы массива");
            for (int i = 0; i < lengthOfArray1; i++)
            {
                temporaryNuber = temporaryNuber - 1;
                Console.WriteLine($"Осталось ввести {temporaryNuber} эл. массива");
                while ((Int32.TryParse(Console.ReadLine(), out array[i])) != true)
                {
                    Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
                }
            }
            return array;
        }
        public static int[] ReadFileArr()
        {
           
            Console.WriteLine("передайте путь (без двойных кавычек) к файлу с массиву");
            string path = Console.ReadLine();
            
            string[] array = File.ReadAllLines(path);
            int[] ints = array.Select(int.Parse).ToArray();
            return ints;
        }
        public static int[,] ReadFileMat()
        {
            Console.WriteLine("передайте путь (без двойных кавычек) к файлу с матрецей");
            string path = Console.ReadLine();
            string[] lines = File.ReadAllLines(path);
            //int[,] matrix = new int[lines.GetLength(0), lines.GetLenght(1)]; просто вариация на тему
            int[,] matrix = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    matrix[i, j] = Convert.ToInt32(temp[j]);
            }
            return matrix;
        }
        public static int[][] ReadFileJagArr()
        {
            string path = Console.ReadLine();
            string[] rows = File.ReadAllLines(path);
            int[][] array = new int[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbers = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    array[i][j] = int.Parse(numbers[j]);
                    Console.Write("{0} ", array[i][j]);
                }
                Console.WriteLine();
            }
            return array;
        }
        public static int[,] InputMatrix()
        {
            Console.WriteLine("Введите ширину матрицы");
            //int wightOfMatrix = Convert.ToInt32(Console.ReadLine());
            int wightOfMatrix;
            while ((Int32.TryParse(Console.ReadLine(), out wightOfMatrix)) != true)
            {
                Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
            }
            Console.WriteLine("Введите высоту матрицы");
            int hightOfMatrix;// = Convert.ToInt32(Console.ReadLine());
            while ((Int32.TryParse(Console.ReadLine(), out hightOfMatrix)) != true)
            {
                Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
            }
            int[,] matrix = new int[hightOfMatrix, wightOfMatrix];
            for (int i = 0; i < hightOfMatrix; i++)
            {
                for (int j = 0; j < wightOfMatrix; j++)
                {
                    Console.WriteLine($"Введите элемент массива с индексом [{i}, {j}]");
                    //matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    while ((Int32.TryParse(Console.ReadLine(), out matrix[i, j])) != true)
                    {
                        Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
                    }
                }
            }
            return matrix;
        }
        public static int[][] JaggedArray()
        {
            Console.WriteLine("Ведите длину зубчатого массива");
            //int lenghtOfJaaggedArray = Convert.ToInt32(Console.ReadLine());
            int lenghtOfJaaggedArray;
            while ((Int32.TryParse(Console.ReadLine(), out lenghtOfJaaggedArray)) != true)
            {
                Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
            }
            int[][] jagArr = new int[lenghtOfJaaggedArray][];

            for (var i = 0; i < lenghtOfJaaggedArray; i++)
            {
                Console.WriteLine($"Длина внутреннего массива {i+1}");
                //int a = Convert.ToInt32(Console.ReadLine()); //длина внутреннего массива
                int a;
                while ((Int32.TryParse(Console.ReadLine(), out a)) != true)
                {
                    Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
                }
                jagArr[i] = new int[a];
                for (var j = 0; j < a; j++)
                {
                    Console.WriteLine($"Введите элемент №{j} внутреннего массива");
                    while ((Int32.TryParse(Console.ReadLine(), out jagArr[i][j])) != true)
                    {
                        Console.WriteLine("Вы ввели не число, невозможно перевести в int, попробуйте снова");
                    }
                }
            }
            return jagArr;
        }
        public static int[] QuickSort(int[] a, int i, int j)
        { 
            if (i < j)
            {
                int q = Partition(a, i, j);
                a = QuickSort(a, i, q);
                a = QuickSort(a, q + 1, j);
            }
            return a;
        }
        private static int Partition(int[] a, int p, int r)
        {
            int x = a[p];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                    j--;
                while (a[j] > x);
                do
                    i++;
                while (a[i] < x);
                if (i < j)
                {
                    int tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
                else
                    return j;
            }
        }
        public static int[] Sortirovka(int[] array1)
        {
            int[] array = array1;
            Console.WriteLine("Будем проводить сортировку?(yes/no)");
            string yesNo = Console.ReadLine();
            if (yesNo == "no")
                return array;
            if (yesNo == "yes")
            {
                Console.WriteLine("Собственная сорировка или Array.Sort \n Введите 1 или 2 соответственно");
                string oneOrTwo = Console.ReadLine();
                if (oneOrTwo == "1")
                {
                    array = QuickSort(array,0,array.Length - 1);
                    return array;
                }
                if (oneOrTwo == "2")
                {
                    Array.Sort(array);
                    return array;
                }
            }
            return array;
        }
    }
}

