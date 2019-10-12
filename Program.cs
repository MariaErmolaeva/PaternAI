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
            Console.WriteLine("Введите количество элементов в массиве: ");


            Presentor pres = new Presentor(5, 5);

            Console.WriteLine("\nВыберите один из вариантов: \n1.Добавить элемент\n2.Удалить элемент\n3.Показать массив");
            string Answer = "";

            while (Answer != "0")
            {
                Answer = Console.ReadLine();
                int answer;

                if (Int32.TryParse(Answer, out answer) == true)
                {
                    if (answer > 0 && answer < 4)
                    {
                        switch (answer)
                        {
                            case 1:
                                pres.Add();

                                break;
                            case 2:

                                pres.Delete();
                                break;
                            case 3:

                                pres.GetMassiv();
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
        int[,] Massiv;

        public Presentor(int row, int column)
        {
            Random rnd = new Random();

            Massiv = new int[row, column];

            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    Massiv[i, j] = rnd.Next(40);
        }


        public void Add()
        {

        }

        public void Delete()
        {

        }

        public void GetMassiv()
        {

        }
    }
}

