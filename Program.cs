using System;


namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            View views = new View();
            views.Main();
        }
    }

    public class View
    {
        int countMassiv = 0;
        public void Main()
        {
            Console.WriteLine("Введите размер массива: ");
            try
            {
                if (Int32.TryParse(Console.ReadLine(), out countMassiv) == true)
                {
                    Presentor pres = new Presentor(countMassiv);

                    Console.WriteLine("\nВыберите один из вариантов: \n1.Добавить элемент\n2.Удалить элемент\n3.Вывести одномерный массив\n4.Сортировать одномерный\n5.Вывести двумерный массив\n6.Добавить строку в двумерный");
                    string answer = "";

                    while (answer != "0")
                    {
                        answer = Console.ReadLine();
                        int answer_;

                        if (Int32.TryParse(answer, out answer_) == true)
                        {
                            if (answer_ > 0 && answer_ < 7)
                            {
                                switch (answer_)
                                {
                                    case 1:
                                        Console.WriteLine("Введите число: ");
                                        int value;
                                        if (Int32.TryParse(Console.ReadLine(), out value) == true)
                                        {
                                            pres.Add(value);
                                            Console.WriteLine("Успешно\n");
                                        }
                                        else
                                            Console.WriteLine("Некорректное число\n");
                                        break;
                                    case 2:
                                        Console.WriteLine("\nВведите индекс элемента: ");
                                        int index;

                                        if (Int32.TryParse(Console.ReadLine(), out index) == true)
                                        {
                                            pres.Delete(index);
                                            Console.WriteLine("\nУспешно");
                                        }
                                        else
                                            Console.WriteLine("\nНекорректное число");
                                        break;
                                    case 3:
                                        Console.WriteLine();
                                        int[] massiv = pres.massiv;
                                        for (int j = 0; j < massiv.Length; j++)
                                            Console.WriteLine(massiv[j].ToString());
                                        Console.WriteLine();
                                        break;
                                    case 4:
                                        pres.Sort();
                                        Console.WriteLine("\nУспешно\n");
                                        break;
                                    case 5:
                                        Console.WriteLine();
                                        int[,] massiv_2 = pres.massiv_2;
                                        for (int i = 0; i < massiv_2.GetLength(0); i++)
                                        {
                                            for (int j = 0; j < massiv_2.GetLength(1); j++)
                                                Console.Write(massiv_2[i, j].ToString() + "  ");
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 6:
                                        Console.WriteLine("Введите индекс строки: ");

                                        if (Int32.TryParse(Console.ReadLine(), out index) == true)
                                        {
                                            if (pres.massiv_2.GetLength(0) > index + 1)
                                            {
                                                pres.Add_String(index);
                                                Console.WriteLine("Успешно\n");
                                            }
                                            else
                                                Console.WriteLine("Выход за границы массива");
                                        }
                                        else
                                            Console.WriteLine("Некорректный индекс");
                                        break;
                                }
                            }
                            else
                                Console.WriteLine("\nНет такой команды");
                        }
                        else
                            Console.WriteLine("\nНет такой команды");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Некорректно введен размер массива");
            }
        }
    }

    public class Presentor
    {
        public int[,] massiv_2;

        public int[] massiv;

       // public int[][] massiv_3; 

        public Presentor(int row)
        {
            Random rnd = new Random();

            massiv = new int[row];

            for (int i = 0; i < row; i++)
                massiv[i] = rnd.Next(40);

            massiv_2 = new int[row, row];

            for (int i = 0; i < row; i++)
                for (int j = 0; j < row; j++)
                    massiv_2[i, j] = rnd.Next(50);

            /*massiv_3 = new int[row][];

            int N = 3;
            for (int i = 0; i < row; i++)
            {
                massiv_3[i] = new int[N];
                for (int j = 0; j < N; j++)
                {
                    massiv_3[i][j] = rnd.Next(40);
                }
                N++;
            }
            */
        }

        public void Add(int value)
        {
            //добавление элемента в конец массива
            int lenght = massiv.Length + 1;
            Array.Resize(ref massiv, lenght);
            massiv[lenght - 1] = value;
        }

        public void Delete(int index)
        {
            //удаление элемента по индексу
            int length = massiv.Length;
            for (int i = index; i < length - 1; i++)
                massiv[i] = massiv[i + 1];
            Array.Resize(ref massiv, length - 1);
        }

        public void Sort()
        {
            //сортировка четных элементов (по четным индексам)
            for (int i = 0; i < massiv.Length - 2; i++)
            {
                int j = i;
                while (j < massiv.Length - 2)
                {
                    if (j % 2 == 0)
                    {
                        if (massiv[j] < massiv[j + 2])
                        {
                            int temp = massiv[j + 2];
                            massiv[j + 2] = massiv[j];
                            massiv[j] = temp;
                        }
                    }
                    j++;
                }
            }
        }

        public void Sort_Odd()
        {
            //по нечетным
            for (int i = 0; i < massiv.Length - 2; i++)
            {
                int j = i;
                while (j < massiv.Length - 2)
                {
                    if (j % 2 != 0)
                    {
                        if (massiv[j] < massiv[j + 2])
                        {
                            int temp = massiv[j + 2];
                            massiv[j + 2] = massiv[j];
                            massiv[j] = temp;
                        }
                    }
                    j++;
                }
            }
        }

        public void Delete_Fist_Element()
        {
            //удаление первого четного элемента 0 или 2
            for (int i = 0; i < massiv.Length - 1; i++)
            {
                int temp = massiv[i + 1];
                massiv[i] = temp;
            }
            int lenght = massiv.Length - 1;
            Array.Resize(ref massiv, lenght);
        }

        public void Add_String(int index)
        {
            //добавить строку с заданным номером
            int length_row = massiv_2.GetLength(0);
            int length_column = massiv_2.GetLength(1);

            int[,] temp = new int[length_row, length_row];

            temp = massiv_2;
            massiv_2 = new int[length_row + 1, length_column];

            for (int i = 0; i < length_row + 1; i++)
            {
                if (index > i)
                {
                    for (int j = 0; j < length_column; j++)
                        massiv_2[i, j] = temp[i, j];
                }
                else
                {
                    if (index == i)
                    {
                        for (int j = 0; j < length_column; j++)
                            massiv_2[i, j] = 0;
                    }
                    else
                    {
                        if (index < i)
                        {
                            for (int j = 0; j < length_column; j++)
                                massiv_2[i, j] = temp[i - 1, j];
                        }
                    }
                }
            }
        }
    }
}



