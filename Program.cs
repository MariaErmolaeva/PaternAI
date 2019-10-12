using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Main()
        {
		//test for github
            Presentor pres = new Presentor(5);
            Console.WriteLine("\nВыберите один из вариантов: \n1.Добавить элемент\n2.Удалить элемент\n3.Показать массив\n4.Сортировать");
            string Answer = "";
            while (Answer != "0")
            {
                Answer = Console.ReadLine();
                int answer;
                if (Int32.TryParse(Answer, out answer) == true)
                {
                    if (answer > 0 && answer < 5)
                    {
                        switch (answer)
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
                                int[] massiv = pres.Massiv;
                                for (int j = 0; j < massiv.Length; j++)
                                    Console.WriteLine(massiv[j].ToString());
                                Console.WriteLine();
                                break;
                            case 4:
                                pres.Sort();
                                Console.WriteLine("\nУспешно\n");
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

    public class Presentor
    {
        public int[] Massiv;

        public Presentor(int row)
        {
            Random rnd = new Random();

            Massiv = new int[row];

            for (int i = 0; i < row; i++)
                Massiv[i] = rnd.Next(40);
        }

        public void Add(int value)
        {
            int lenght = Massiv.Length + 1;

            Array.Resize(ref Massiv, lenght);

            Massiv[lenght - 1] = value;
        }

        public void Delete(int index)
        {
            int lenght = Massiv.Length;

            for (int i = index; i < lenght - 1; i++)
            {
                Massiv[i] = Massiv[i + 1];
            }

            Array.Resize(ref Massiv, lenght - 1);
        }

        public void Sort()
        {
            for (int i = 0; i < Massiv.Length - 2; i++)
            {
                int j = i;
                while (j < Massiv.Length - 2)
                {
                    if (j % 2 == 0)
                    {
                        if (Massiv[j] < Massiv[j + 2])
                        {
                            int temp = Massiv[j + 2];
                            Massiv[j + 2] = Massiv[j];
                            Massiv[j] = temp;
                        }
                    }
                    j++;
                }
            }
        }

	public void Sort_Odd()
        {
            for (int i = 0; i < Massiv.Length - 2; i++)
            {
                int j = i;
                while (j < Massiv.Length - 2)
                {
                    if (j % 2 != 0)
                    {
                        if (Massiv[j] < Massiv[j + 2])
                        {
                            int temp = Massiv[j + 2];
                            Massiv[j + 2] = Massiv[j];
                            Massiv[j] = temp;
                        }
                    }
                    j++;
                }
            }
        }
    }
}


